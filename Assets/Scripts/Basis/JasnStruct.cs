using System.Collections.Generic;
using Struct;
using UnityEngine;

namespace Struct
{
    [System.Serializable]
    public struct AllMyRod
    {
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
        public  float RopeLengthMin;
        public float RopeLengthMax;
        public  float RodSpinSpeed;
        public  int DurabilityMax;
    }
    
    [System.Serializable]
    public struct AllGaChaRodBase
    {
        public List<GaChaRodBase> Bases;
    }

        #endregion
        
   
}