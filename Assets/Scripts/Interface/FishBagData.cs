using System.Collections.Generic;
using System.IO;
using Struct;
using UnityEngine;

namespace Interface
{
    public class FishBagData
    {
            // Get the target fish's price.
            public static int GetFishPrice(string fishName)
            {
                string jsonData = JsonReader.Instance.GetJsonText("FishBag.json");
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
            public static int GetFishNum(string fishName)
            {
                string jsonData = JsonReader.Instance.GetJsonText("FishBag.json");
                FishsData root = JsonUtility.FromJson<FishsData>(jsonData);
        
                int temp = 0;
                foreach (JsonClass.FishOwnsNum fish in root.FishOwnsNum)
                {
                    if(fish.Name == fishName)
                        temp = fish.Num;
                }
                return temp;
            }
        
            public static void SetFishNum(string fishName, int fishNum )
            {
                string jsonData = JsonReader.Instance.GetJsonText("FishBag.json");
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
            public static List<string> GetAllFish()
            {
                string jsonData = JsonReader.Instance.GetJsonText("FishBag.json");
                FishsData root = JsonUtility.FromJson<FishsData>(jsonData);
        
                List<string> tempList = new List<string>();
                foreach (JsonClass.FishOwnsNum fish in root.FishOwnsNum)
                {
                    tempList.Add(fish.Name);
                }
        
                return tempList;
            }
    }
}