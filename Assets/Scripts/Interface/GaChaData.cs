using System.Linq;
using Struct;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Interface
{
    public class GaChaData
    {
        private const string RodBasePath = "FishingRodBaseTypes.json";

        public static GaChaRodBase GetRodBaseTypes(string TypeName)
        {
            string jsonData = JsonReader.Instance.GetJsonText(RodBasePath);
            AllGaChaRodBase root = JsonUtility.FromJson<AllGaChaRodBase>(jsonData);

            foreach (var VARIABLE in root.Rod)
            {
                if(VARIABLE.Name == TypeName) return VARIABLE;
            }
            Debug.Log("find no RodBase");
            return new GaChaRodBase();
        }
    }
}