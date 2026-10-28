using System.Text;

namespace TheWorld.GameMechanics;

/// <summary>
/// A place in the world.
/// </summary>
public record Area
{
    /// <summary>
    /// The name must be provided at construction time.
    /// It is also the area's key in the GameData.
    /// </summary>
    public string Name { get; init; } = string.Empty;
    /// <summary>
    /// This is the interesting description of the area, which is shown to the player when they enter it.
    /// </summary>
    public string Description { get; init; } = string.Empty;

    /// <summary>
    /// Creatures that live in this area are listed here, by name.
    /// This is a reference to the Creature, not the Creature itself, so that we can look it up in the GameData.
    /// </summary>
    public IReadOnlyList<string> Creatures { get; init; } = [];

    /// <summary>
    /// Items that are in this area are listed here, by name.
    /// This is a reference to the Item, not the Item itself, so that we can look it up in the GameData.
    /// </summary>
    public IReadOnlyList<string> Items { get; init; } = [];

    /// <summary>
    /// TODO: this will come later, because self-reference is WILD.
    /// </summary>
    public IReadOnlyList<string> Neighbors { get; init; } = [];

    /// <summary>
    /// Sometimes it is ok to expose a constructor, but not always.  
    /// This one is for the builder, which is trusted to do the right thing.  
    /// The public Create is Lesson 5's factory, which checks the numbers it's handed.  
    /// The internal Create is for CreatureBuilder, and it trusts the builder
    /// </summary>
    /// <param name="name"></param>
    internal Area(string name) { Name = name; }

    /// <summary>
    /// Returns a description of the area and its contents.
    /// </summary>
    /// <returns></returns>
    public string LookAround()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"You are in {Name}.");
        sb.AppendLine(Description);
        if (Creatures.Any()) //if any creatures around
        {
            sb.AppendLine("You see the following creatures:");
            foreach (var creature in Creatures)
            {
                sb.AppendLine($"- {creature}"); // add = append
            } // name the creatures existing in surroundings
        }
        if (Items.Any()) // if items
        {
            sb.AppendLine("You see the following items:");
            foreach (var item in Items)
            {
                sb.AppendLine($"- {item}");
            }//name items
        }
        return sb.ToString(); // equivalent to Builder.Build
    }
}