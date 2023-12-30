using UnityEngine;


namespace Core
{
    public abstract class MySingleton<T> : MonoBehaviour where T : Component
    {

        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance != null) return instance;
                instance = FindObjectOfType<T>();
                if (instance != null) return instance;
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                instance = obj.AddComponent<T>();
                return instance;
            }
        }
    }
}