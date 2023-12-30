using UnityEngine;
using System.IO;
using System.Collections.Generic;

#region "Json"
[System.Serializable]
class RodsData
{
    public List<Rod> Rod;
}

[System.Serializable]
class Rod
{
    public string Name;
    public float RopeDownSpeed;
    public float MaxRopeLength;
    public float RodAngleSpeed;
    public bool IsOwn;
}

[System.Serializable]
class FishsData
{
    public FishOwnsNum[] FishOwnsNum;
}

[System.Serializable]
class FishOwnsNum
{
    public string Name;
    public int Price;
    public int Num;
}
#endregion

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

    string GetJsonText(string jsonName)
    {
        return File.ReadAllText(Application.dataPath + "/Data/" + jsonName);
    }


    #region "Rod"
    // Get if the target rod is Own.
    public bool GetRodIsOwn(string rodName)
    {
        string jsonData = GetJsonText("FishingRodTypes.json");
        RodsData root = JsonUtility.FromJson<RodsData>(jsonData);

        bool isOwn = false;
        foreach (Rod rod in root.Rod)
        {
            if(rod.Name == rodName)
                isOwn = rod.IsOwn;
        }
        return isOwn;
    }

    public void SetRodIsOwn(string rodName, bool rodIsOwn)
    {
        string jsonData = GetJsonText("FishingRodTypes.json");
        RodsData root = JsonUtility.FromJson<RodsData>(jsonData);

        foreach (Rod rod in root.Rod)
        {
            if(rod.Name == rodName)
                rod.IsOwn = rodIsOwn;
        }

        string json = JsonUtility.ToJson(root, true);
        
        using (StreamWriter sr = new StreamWriter(Application.dataPath + "/Data/FishingRodTypes.json"))
        {
            sr.WriteLine(json);
            sr.Close();
        }
    }

    // Get the target rod's speed.
    public float GetRodSpeed(string rodName)
    {
        string jsonData = GetJsonText("FishingRodTypes.json");
        RodsData root = JsonUtility.FromJson<RodsData>(jsonData);

        float temp = 0;
        foreach (Rod rod in root.Rod)
        {
            if(rod.Name == rodName)
                temp = rod.RopeDownSpeed;
        }
        return temp;
    }

    public float GetMaxRopeLength(string rodName)
    {
        string jsonData = GetJsonText("FishingRodTypes.json");
        RodsData root = JsonUtility.FromJson<RodsData>(jsonData);

        float temp = 0;
        foreach (Rod rod in root.Rod)
        {
            if(rod.Name == rodName)
                temp = rod.MaxRopeLength;
        }
        return temp;
    }

    public float GetRodAngleSpeed(string rodName)
    {
        string jsonData = GetJsonText("FishingRodTypes.json");
        RodsData root = JsonUtility.FromJson<RodsData>(jsonData);

        float temp = 0;
        foreach (Rod rod in root.Rod)
        {
            if(rod.Name == rodName)
                temp = rod.RodAngleSpeed;
        }
        return temp;
    }

    // For gacha.
    public List<string> GetAllRod()
    {
        string jsonData = GetJsonText("FishingRodTypes.json");
        RodsData root = JsonUtility.FromJson<RodsData>(jsonData);

        List<string> tempList = new List<string>();
        foreach (Rod rod in root.Rod)
        {
            tempList.Add(rod.Name);
        }

        return tempList;
    }
    #endregion


    #region "FishBag"
    // Get the target fish's price.
    public int GetFishPrice(string fishName)
    {
        string jsonData = GetJsonText("FishBag.json");
        FishsData root = JsonUtility.FromJson<FishsData>(jsonData);

        int temp = 0;
        foreach (FishOwnsNum fish in root.FishOwnsNum)
        {
            if(fish.Name == fishName)
                temp = fish.Price;
        }
        return temp;
    }

    // Get the target fish's own number.
    public int GetFishNum(string fishName)
    {
        string jsonData = GetJsonText("FishBag.json");
        FishsData root = JsonUtility.FromJson<FishsData>(jsonData);

        int temp = 0;
        foreach (FishOwnsNum fish in root.FishOwnsNum)
        {
            if(fish.Name == fishName)
                temp = fish.Num;
        }
        return temp;
    }

    public void SetFishNum(string fishName, int fishNum)
    {
        string jsonData = GetJsonText("FishBag.json");
        FishsData root = JsonUtility.FromJson<FishsData>(jsonData);

        foreach (FishOwnsNum fish in root.FishOwnsNum)
        {
            if(fish.Name == fishName)
                fish.Num = fishNum;
        }

        string json = JsonUtility.ToJson(root, true);
        
        using (StreamWriter sr = new StreamWriter(Application.dataPath + "/Data/FishBag.json"))
        {
            sr.WriteLine(json);
            sr.Close();
        }
    }

    // For Fish generate.
    public List<string> GetAllFish()
    {
        string jsonData = GetJsonText("FishBag.json");
        FishsData root = JsonUtility.FromJson<FishsData>(jsonData);

        List<string> tempList = new List<string>();
        foreach (FishOwnsNum fish in root.FishOwnsNum)
        {
            tempList.Add(fish.Name);
        }

        return tempList;
    }
    #endregion
}
