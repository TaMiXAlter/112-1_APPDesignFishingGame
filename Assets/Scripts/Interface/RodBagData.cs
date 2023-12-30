using Struct;
using UnityEngine;

namespace Interface
{
    public static class RodBagData
    {
        private const string RodBagPath = "RodBag.json";

        
        public static JsonClass.Rod GetTheRod(int RodID)
        {
            string jsonData = JsonReader.Instance.GetJsonText(RodBagPath);
            AllMyRod root = JsonUtility.FromJson<AllMyRod>(jsonData);
            
            JsonClass.Rod myrod = new JsonClass.Rod();
            foreach (JsonClass.Rod rod in root.Rod)
            {
                if(rod.ID == RodID)
                    myrod = rod;
            }
            return myrod;
        }
        
        #region get/set Durability
        public static int GetRodDurability(int RodID)
        {
            string jsonData = JsonReader.Instance.GetJsonText(RodBagPath);
            AllMyRod root = JsonUtility.FromJson<AllMyRod>(jsonData);

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
            AllMyRod root = JsonUtility.FromJson<AllMyRod>(jsonData);

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
       

        #region GetControlAttributes

        public static float GetRodSpeed(int RodID)
        {
            string jsonData = JsonReader.Instance.GetJsonText(RodBagPath);
            AllMyRod root = JsonUtility.FromJson<AllMyRod>(jsonData);
            float temp = 0;
            foreach (JsonClass.Rod rod in root.Rod)
            {
                if(rod.ID == RodID)
                    temp = rod.RopeDownSpeed;
            }
            return temp;
        }

        public static float GetMaxRopeLength(int RodID)
        {
            string jsonData = JsonReader.Instance.GetJsonText(RodBagPath);
            AllMyRod root = JsonUtility.FromJson<AllMyRod>(jsonData);

            float temp = 0;
            foreach (JsonClass.Rod rod in root.Rod)
            {
                if(rod.ID == RodID)
                    temp = rod.MaxRopeLength;
            }
            return temp;
        }
        
        public static float GetRodSpinSpeed(int RodID)
        {
            string jsonData = JsonReader.Instance.GetJsonText(RodBagPath);
            AllMyRod root = JsonUtility.FromJson<AllMyRod>(jsonData);

            float temp = 0;
            foreach (JsonClass.Rod rod in root.Rod)
            {
                if(rod.ID == RodID)
                    temp = rod.RodSpinSpeed;
            }
            return temp;
        }
        #endregion

        
    }
}