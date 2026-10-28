// Check it out! An Alias!
// I'm giving a "Name" to the type which represents a Function that takes a Random number generator and a Dice,
// and then Returns an Integer (presumably from a dice-roll, but that's up to the programmer).


global using DiceRollStrategy = System.Func<System.Random, TheWorld.GameMechanics.Dice, int>;

namespace TheWorld;
public static class Helpers
{
    /// <returns>The trimmed name, or "Blob" when there's nothing there but White-Space.</returns>
    public static string ValidateString(string name) =>
        name switch
        {
            var n when string.IsNullOrWhiteSpace(n) => "Blob",
            _ => name.Trim()
        };
    
}

