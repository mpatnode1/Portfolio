public class TextChunks
{
    List<string> textChunkStorage;

    public TextChunks(string filePath)
    {
        textChunkStorage = new List<string>();
        StreamReader sr = new StreamReader(filePath);

        textChunkStorage.Add(sr.ReadLine());

        while (sr.Peek() != -1)
        {
            textChunkStorage.Add(sr.ReadLine());
        }
    }

    public void Run()
    {
        foreach (string line in textChunkStorage)
        {
            Console.WriteLine(line);
        }
    }
}