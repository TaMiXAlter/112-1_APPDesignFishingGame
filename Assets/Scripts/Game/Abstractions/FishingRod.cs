using System.Collections.Generic;
using UnityEngine;

namespace FishingRods
{
    #region "Json"
    [SerializeField]
    class Root
    {
        public List<Value> NormalFishingRod;
    }

    [SerializeField]
    class Value
    {
        public int Speed;
    }
    #endregion
    
    
    public abstract class FishingRod : MonoBehaviour
    {
        protected FishingRod(){}

        public abstract void Display();
    }
}
