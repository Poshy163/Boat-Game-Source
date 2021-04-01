using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighScores : MonoBehaviour
{
    private string fileName = "HighScores.txt";
    protected string LocalFilePath;

    private void Start()
    {
        LocalFilePath = Application.dataPath + "\\" + fileName;
        CheckFile();
        ReadFile();
    }

    #region ScoreSaving
    public Dictionary<string,string> SaveList = new Dictionary<string,string>();
    public void CheckFile()
    {        
        if(!File.Exists(LocalFilePath))
        {
            StreamWriter fileWriter = new StreamWriter(LocalFilePath);
            fileWriter.Close();
            Debug.Log("The file " + fileName + " does not exist. Makeing a new one!",this);
        }      
    }
    public void WriteData(string name, double tscore)
    {
        if(name == "NULL")
            return;
       string score = tscore.ToString();
        if(!SaveList.ContainsKey(name.ToUpper()))
          SaveList.Add(name,"1000000");  
        if(SaveList.ContainsKey(name) && double.Parse(SaveList[name]) >= tscore)
          SaveList[name] = score;
        StreamWriter fileWriter = new StreamWriter(LocalFilePath);
        fileWriter.Write($"{SaveList.Count.ToString()}+\n");
        foreach(KeyValuePair<string,string> entry in SaveList)
        {            
            fileWriter.Write($"{entry.Key}:{entry.Value}\n");
        }       
        fileWriter.Close();
    }
    public void ReadFile()
    {
        try
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
        catch
        {

        }
    }
    static string ReadSpecificLine(string filePath, int lineNumber)
    {
        string content = null;
        try
        {
            using(StreamReader file = new StreamReader(filePath))
            {
                for(int i = 1; i < lineNumber;i++)
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
    #endregion
}
