using System.Linq;
using Struct;
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

            GaChaRodBase temp = new GaChaRodBase() ;
            foreach (var Base in root.Bases.Where(rod => rod.Name == TypeName))
            {
                temp = Base;
            }
            
            return temp;
        }
    }
}