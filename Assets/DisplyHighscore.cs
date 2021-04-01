using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using System.IO;

public class DisplyHighscore : MonoBehaviour
{
    public TMP_Text txt;
    private string fileName = "HighScores.txt";
    protected string LocalFilePath;
    public Dictionary<string,string> SaveList = new Dictionary<string,string>();

    public void ReadFile ()
    {
        if(File.Exists(LocalFilePath))
        {

            StreamReader str = new StreamReader(LocalFilePath);
            string[] count = str.ReadToEnd().Split('+');
            for(int i = 2;i <= int.Parse(count[0]) + 1;i++)
            {
                string[] info = ReadSpecificLine(LocalFilePath,i).Split(':');
                SaveList.Add(info[0],info[1]);
            }
            str.Close();
        }
    }

    private void Start ()
    {
        LocalFilePath = Application.dataPath + "\\" + fileName;
        ReadFile();
        LoadScores(SaveList);
    }
    void LoadScores(Dictionary<string,string> scorelist)
    {
        Dictionary<string,string> ordered = scorelist.OrderBy(x => x.Value).ToDictionary(x => x.Key,x => x.Value);
        try
        {
            txt.text =
                $"1. {ordered.ElementAt(0).Key} : {ordered.ElementAt(0).Value}s\n" +
                $"2. {ordered.ElementAt(1).Key} : {ordered.ElementAt(1).Value}s\n" +
                $"3. {ordered.ElementAt(2).Key} : {ordered.ElementAt(2).Value}s\n";
        }
        catch
        {
            txt.text = "Not enough scores yet for an update! keep playing!";
        }
        
    }
    static string ReadSpecificLine ( string filePath,int lineNumber )
    {
        string content = null;
        try
        {
            using(StreamReader file = new StreamReader(filePath))
            {
                for(int i = 1;i < lineNumber;i++)
                {
                    file.ReadLine();

                    if(file.EndOfStream)
                    {
                        break;
                    }
                }
                content = file.ReadLine();
            }
        }
        catch(IOException e)
        {
            Debug.Log(e.Message);
        }
        return content;

    }
}
