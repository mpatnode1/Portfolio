
public class Decisions 
{
    public string PlayerName;
    public char HistoryDecision;
    public int Score;
    public char DimeDecision;
    public char RingUpChoiceThree;
    public int ScoreAdjustment(int ScoreChangeAmount)
    {
        Score += ScoreChangeAmount;
        Console.WriteLine($"[{ScoreChangeAmount} POINTS GAINED]");
        Console.WriteLine($"CURRENT SCORE: {Score}");
        return Score;
    }

}