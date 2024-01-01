using System.Collections.Generic;
using Struct;
using UnityEngine;

namespace Struct
{
    
    [System.Serializable]
    public struct RodBagRoot
    {
        public JsonClass.EquipmentNow EquipmentNow;
        public List<JsonClass.Rod> Rod;
    }

    [System.Serializable]
    public struct FishsData
    {
        public JsonClass.FishOwnsNum[] FishOwnsNum;
    }

    #region GaCha

    [System.Serializable]
    public struct GaChaRodBase
    {
        public string Name;
        public  float RopeDownSpeedMin;
        public  float RopeDownSpeedMax;
        public  int RopeLengthMin;
        public int RopeLengthMax;
        public  int RodSpinSpeed;
        public  int DurabilityMax;
    }
    
    [System.Serializable]
    public struct AllGaChaRodBase
    {
        public List<GaChaRodBase> Rod;
    }

        #endregion
        
   
}