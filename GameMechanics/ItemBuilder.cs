using System.Runtime.InteropServices;

namespace TheWorld.GameMechanics;
using static TheWorld.Helpers;

public record ItemBuilder
{
    private string _name;
    private string _description;
    /// <summary>
    /// Start an Item from a name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    
    public static ItemBuilder FromName(string name) => 
        new ItemBuilder() { _name = ValidateString(name) };
    /// <summary>
    /// Set the description of the item. 
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    public ItemBuilder WithDescription(string description) =>
        this with { _description = ValidateString(description) };
//seomtheing different, inject gamedata
    public string Build(GameData gameData)
    {
        var item = new Item(_name, _description);
        if (gameData.TryAddItem(item))
            return _name;
        return null;
    }
}