using System.Runtime.InteropServices;

namespace TheWorld.GameMechanics;
using static TheWorld.Helpers;

public record ItemBuilder
{
    private Item? _item;
    
    /// <summary>
    /// Start an Item from a name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    
    public static ItemBuilder FromName(string name) => 
        new ItemBuilder() { _item =new( ValidateString(name), string.Empty) };
    /// <summary>
    /// Set the description of the item. 
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    public ItemBuilder WithDescription(string description) =>
        this with { _item = _item with { Description = ValidateString(description) } };

    public ItemBuilder WithID(string id) => this with { _item = _item with { ID = id } };
//seomtheing different, inject gamedata
    public string? Build(GameData gameData)
    {
        
        if (gameData.TryAddItem(_item))
        {
            return _item.Name;
        }
        return null;
    }
}