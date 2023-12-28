using System;
using Controller;
using UnityEngine;

namespace View
{
    public abstract class ViewBase : MonoBehaviour
    {
        public abstract void Initialize(ViewManager viewManager);
        public abstract void EndUpView();
        
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}
