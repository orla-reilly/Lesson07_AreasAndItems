namespace TheWorld.GameMechanics;

using static TheWorld.Helpers;

/// <summary>
/// Builds a <see cref="Creature"/> one part at a time.
///
/// Smaller than <see cref="PlayerBuilder"/>, on purpose.  A player is one of a
/// kind, so their numbers get rolled.  A creature comes from an archetype:
/// every goblin is built from the same goblin recipe, so its numbers get set
/// directly.
/// </summary>
public record CreatureBuilder
{
    // Default values for every part of a Creature, the same trick PlayerBuilder uses.
    private string? _id;
    private string _name = "Blob";
    private HealthPoints _healthPoints = HealthPoints.Create(1);
    private AbilityScore _abilities = AbilityScore.Create(10, 10, 10, 10, 10, 10)!;
    private int _experienceReward = 0;

    /// <summary>
    /// Does Nothing, except force every caller to start from FromName.
    /// </summary>
    private CreatureBuilder() { }

    /// <summary>
    /// Start with a FROM method.  A creature starts from the name of its archetype.
    /// </summary>
    public static CreatureBuilder FromName(string name) => new() { _name = ValidateString(name) };

    public static CreatureBuilder FromCreature(Creature creature) =>
        new()
        {
            _id = creature.ID,
            _name = creature.Name,
            _healthPoints = creature.HealthPoints,
            _experienceReward = creature.ExperienceReward,
            _abilities = creature.Abilities
        };
    public CreatureBuilder WithHealthPoints(HealthPoints hp) => this with { _healthPoints = hp };
    public CreatureBuilder WithAbilities(AbilityScore abilities) => this with { _abilities = abilities };
    public CreatureBuilder WithExperienceReward(int xp) => this with { _experienceReward = xp };
    public CreatureBuilder WithID(string id) => this with
    {
        _id = _id
        
    };
    
    /// <summary>
    /// Puts the creature together from whatever parts have been set.
    /// </summary>
    public Creature Build() =>
        Creature.Create(_name, _healthPoints, _abilities, _experienceReward) with {ID = _id ?? _name};

    public string? Build(GameData gameData)
    {
        var creature = Build();
        if (gameData.TryAddCreature(creature))
            return creature.ID;
        return null;
    }

   
}
