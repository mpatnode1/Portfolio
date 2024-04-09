static class Util{
const int MaxEndingNumber = 4;

 public static void EndingSequence(int EndingNumber, Decisions decisions)
    {
        Console.WriteLine($"At least for now, your quest at Magic Burger Palace has come to an end, {decisions.PlayerName}.");
        Console.WriteLine($"You scored {decisions.Score}");
        Console.WriteLine($"Game Ending {EndingNumber} of {MaxEndingNumber}");
        Environment.Exit(0);
    }
}