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

    public string JsonText(string jsonName)
    {
        return File.ReadAllText(Application.dataPath + "/Data/" + jsonName);
    }
}
