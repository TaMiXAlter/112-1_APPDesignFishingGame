namespace Struct
{
    //class 才能更改(set)
    public class JsonClass
    {
        [System.Serializable]
        public class EquipmentNow
        {
            public int RodID;
            public int Money;
        }
            
        [System.Serializable]
        public class FishOwnsNum
        {
            public string Name;
            public int Price;
            public int Num;
        }
        
        [System.Serializable]
        public class Rod
        {
            public int ID;
            public string Name;
            public float RopeDownSpeed;
            public float MaxRopeLength;
            public float RodSpinSpeed;
            public int Durability;
        }
    }
}