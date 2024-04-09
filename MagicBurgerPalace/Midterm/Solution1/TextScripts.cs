 public class DialogueText
{
    List<string> textStorage;

    public DialogueText(string filePath)
    {
        textStorage = new List<string>();
        StreamReader sr = new StreamReader(filePath);

        textStorage.Add(sr.ReadLine());

        while (sr.Peek() != -1)
        {
            textStorage.Add(sr.ReadLine());
        }
    }

        public void Run()
    {
        foreach (string line in textStorage)
        {
            Console.WriteLine(line);
            Console.ReadLine();
        }
    }
}
