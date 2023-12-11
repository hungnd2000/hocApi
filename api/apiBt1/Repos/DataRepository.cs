using apiBt1.Models;
using System.Text;
using System.Text.Json;

namespace apiBT1.Repos;
public class DataRepository
{
    readonly string filePath;

    public DataRepository(IConfiguration config)
    {
        filePath = config["OutputFilePath"];
    }

    public void SaveData(string data)
    {
        using (var stream = new FileStream(path: filePath, FileMode.Append,FileAccess.Write))
        {
            byte[] info = new UTF8Encoding(true).GetBytes(data +"\n");
            stream.Write(info, 0, info.Length);
        }
    }

    public List<Text> ReadData()
    {
        if (File.Exists(filePath))
        {
            List<Text> listText = new List<Text>();
            
            // M? FileStream và StreamReader ?? ??c t?p tin
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                // ??c t?ng dòng và hi?n th? nó
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    listText.Add(JsonSerializer.Deserialize<Text>(line));
                }
            }
            return listText;
        }
        else
        {
            Console.WriteLine("File does not exist.");
            return null;
        }
    }
}