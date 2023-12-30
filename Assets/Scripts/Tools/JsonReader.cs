using UnityEngine;
using System.IO;
public class JsonReader
{
    private static JsonReader instance;
    public static JsonReader Instance
    {
        get
        {
            if(instance == null)
                instance = new JsonReader();
            return instance;
        }
    }

    public string GetJsonText(string jsonName)
    {
        return File.ReadAllText(Application.dataPath + "/Data/" + jsonName);
    }

    public void UpdatejsonFile(string NewJsonFile,string Path)
    {
        
        using (StreamWriter sr = new StreamWriter(Application.dataPath + "/Data/"+Path))
        {
            sr.WriteLine(NewJsonFile);
            sr.Close();
        }
    }
}
