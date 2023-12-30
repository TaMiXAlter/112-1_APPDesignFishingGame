using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Struct;


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
    
    #region "OwningRod"
    // Get if the target rod is Own.
    private const string RodBagPath = "RodBag.json";

    public int GetRodDurability(string rodName)
    {
        string jsonData = GetJsonText(RodBagPath);
        AllMyRod root = JsonUtility.FromJson<AllMyRod>(jsonData);

        int myDurability = 0;
        foreach (JsonClass.Rod rod in root.Rod)
        {
            if(rod.Name == rodName)
                myDurability = rod.Durability;
        }
        return myDurability;
    }
    public void SetRodIsOwn(string rodName, int delta)
    {
        string jsonData = GetJsonText(RodBagPath);
        AllMyRod root = JsonUtility.FromJson<AllMyRod>(jsonData);

        foreach (JsonClass.Rod rod in root.Rod)
        {
            if (rod.Name == rodName)
            {
                rod.Durability += delta;
            }
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
        string jsonData = GetJsonText(RodBagPath);
        AllMyRod root = JsonUtility.FromJson<AllMyRod>(jsonData);

        float temp = 0;
        foreach (JsonClass.Rod rod in root.Rod)
        {
            if(rod.Name == rodName)
                temp = rod.RopeDownSpeed;
        }
        return temp;
    }

    public float GetMaxRopeLength(string rodName)
    {
        string jsonData = GetJsonText(RodBagPath);
        AllMyRod root = JsonUtility.FromJson<AllMyRod>(jsonData);

        float temp = 0;
        foreach (JsonClass.Rod rod in root.Rod)
        {
            if(rod.Name == rodName)
                temp = rod.MaxRopeLength;
        }
        return temp;
    }
    
    public float GetRodSpinSpeed(string rodName)
    {
        string jsonData = GetJsonText(RodBagPath);
        AllMyRod root = JsonUtility.FromJson<AllMyRod>(jsonData);

        float temp = 0;
        foreach (JsonClass.Rod rod in root.Rod)
        {
            if(rod.Name == rodName)
                temp = rod.RodSpinSpeed;
        }
        return temp;
    }
    #endregion

    #region GaChaRodBase

    private const string RodBasePath = "FishingRodBaseTypes.json";

    public GaChaRodBase GetRodBaseTypes(string TypeName)
    {
        string jsonData = GetJsonText(RodBasePath);
        AllGaChaRodBase root = JsonUtility.FromJson<AllGaChaRodBase>(jsonData);

        GaChaRodBase temp = new GaChaRodBase() ;
        foreach (var Base in root.Bases.Where(rod => rod.Name == TypeName))
        {
            temp = Base;
        }

        return temp;
    }

    #endregion

    #region "FishBag"
    // Get the target fish's price.
    public int GetFishPrice(string fishName)
    {
        string jsonData = GetJsonText("FishBag.json");
        FishsData root = JsonUtility.FromJson<FishsData>(jsonData);

        int temp = 0;
        foreach (JsonClass.FishOwnsNum fish in root.FishOwnsNum)
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
        foreach (JsonClass.FishOwnsNum fish in root.FishOwnsNum)
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

        foreach (JsonClass.FishOwnsNum fish in root.FishOwnsNum)
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
        foreach (JsonClass.FishOwnsNum fish in root.FishOwnsNum)
        {
            tempList.Add(fish.Name);
        }

        return tempList;
    }
    #endregion
}
