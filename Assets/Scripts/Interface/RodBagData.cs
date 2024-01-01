using Struct;
using UnityEngine;

namespace Interface
{
    public static class RodBagData
    {
        private const string RodBagPath = "RodBag.json";

        public static int GetNewId()
        {
            string jsonData = JsonReader.Instance.GetJsonText(RodBagPath);
            RodBagRoot root = JsonUtility.FromJson<RodBagRoot>(jsonData);

            int newID = 0;
            foreach (var VARIABLE in root.Rod)
            {
                if (VARIABLE.ID == newID) newID = VARIABLE.ID + 1;
            }

            return newID;
        }

        #region Add/get
        public static JsonClass.Rod GetTheRod(int RodID)
        {
            string jsonData = JsonReader.Instance.GetJsonText(RodBagPath);
            RodBagRoot root = JsonUtility.FromJson<RodBagRoot>(jsonData);

            if (RodID > root.Rod.Count-1) { Debug.Log("Out of Rod Range"); return null; }
            
            JsonClass.Rod myrod = new JsonClass.Rod();
            foreach (JsonClass.Rod rod in root.Rod)
            {
                if(rod.ID == RodID)
                    myrod = rod;
            }
            return myrod;
        }
        public static RodBagRoot GetAllRod()
        {
            string jsonData = JsonReader.Instance.GetJsonText(RodBagPath);
            return JsonUtility.FromJson<RodBagRoot>(jsonData);
        }
        public static void AddRod(JsonClass.Rod newRod)
        {
            string jsonData = JsonReader.Instance.GetJsonText(RodBagPath);
            RodBagRoot root = JsonUtility.FromJson<RodBagRoot>(jsonData);
            
            root.Rod.Add(newRod);
            
            string json = JsonUtility.ToJson(root, true);
            
            JsonReader.Instance.UpdatejsonFile(json,RodBagPath);
        }
        #endregion
        #region get/set money

        public static int GetMoney()
        {
            string jsonData = JsonReader.Instance.GetJsonText(RodBagPath);
            RodBagRoot root = JsonUtility.FromJson<RodBagRoot>(jsonData);

            return root.EquipmentNow.Money;
        }
        
        public static void SetRMoney(int delta)
        {
            string jsonData = JsonReader.Instance.GetJsonText(RodBagPath);
            RodBagRoot root = JsonUtility.FromJson<RodBagRoot>(jsonData);

            root.EquipmentNow.Money += delta;
            
            string json = JsonUtility.ToJson(root, true);
            
            JsonReader.Instance.UpdatejsonFile(json,RodBagPath);
        }

        #endregion
        #region get/set RodNow

        public static int GetRodNowID()
        {
            string jsonData = JsonReader.Instance.GetJsonText(RodBagPath);
            RodBagRoot root = JsonUtility.FromJson<RodBagRoot>(jsonData);

            return root.EquipmentNow.RodID;
        }
        public static JsonClass.Rod GetRodNow ()
        {
            return GetTheRod(GetRodNowID());
        }
        public static void SetRodNowFromID(int NewID)
        {
            string jsonData = JsonReader.Instance.GetJsonText(RodBagPath);
            RodBagRoot root = JsonUtility.FromJson<RodBagRoot>(jsonData);

            root.EquipmentNow.RodID = NewID;
            
            string json = JsonUtility.ToJson(root, true);
            
            JsonReader.Instance.UpdatejsonFile(json,RodBagPath);
        }

        public static void SetRodNow(JsonClass.Rod rod)
        {
            SetRodNowFromID(rod.ID);
        }

        #endregion
        #region get/set Durability
        public static int GetRodDurability(int RodID)
        {
            string jsonData = JsonReader.Instance.GetJsonText(RodBagPath);
            RodBagRoot root = JsonUtility.FromJson<RodBagRoot>(jsonData);

            int myDurability = 0;
            foreach (JsonClass.Rod rod in root.Rod)
            {
                if(rod.ID == RodID)
                    myDurability = rod.Durability;
            }
            return myDurability;
        }
        public static void SetRodDurability(int RodID, int delta)
        {
            string jsonData = JsonReader.Instance.GetJsonText(RodBagPath);
            RodBagRoot root = JsonUtility.FromJson<RodBagRoot>(jsonData);

            foreach (JsonClass.Rod rod in root.Rod)
            {
                if (rod.ID == RodID)
                {
                    rod.Durability += delta;
                }
            }

            string json = JsonUtility.ToJson(root, true);
            
            JsonReader.Instance.UpdatejsonFile(json,RodBagPath);
        }

        #endregion
    }
}