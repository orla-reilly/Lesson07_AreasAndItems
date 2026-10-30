namespace TheWorld.GameMechanics;


/// <summary>
/// A thing in the world.
/// </summary>
public record Item
{
    //internal Item(string name, string description)
    //{
    //    Id = name;
    //    Name = name;
    //    Description = description;
    //}
    
    /// <summary>
    /// The item's key in the GameData.  It starts out as the name, and can be anything unique.
    /// </summary>
    public string Id { get; init; }

    /// <summary>
    /// The name must be provided at construction time.
    /// It is what the player reads.
    /// </summary>
    public string Name { get; init; } = string.Empty;
    
    /// <summary>
    /// This is the interesting description of the item, which is shown to the player when they examine it.
    /// </summary>
    public string Description { get; init; } = string.Empty;

    /// <summary>
    /// Sometimes it is ok to expose a constructor, but not always. 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    internal Item(string name, string description)
    {
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Returns a description of the item.
    /// TODO: This is a very simple implementation.  Its gonna get a lot more exciting soon ;)
    /// </summary>
    public string Examine() => $"You see {Name}.  {Description}";
}
