namespace TheWorld.GameMechanics.StockEntities;

public static class StockItems
{
    public static string? Knife(GameData gameData) =>
        ItemBuilder.FromName("Knife")
            .WithDescription("A big knife")
            .Build(gameData);
    
}