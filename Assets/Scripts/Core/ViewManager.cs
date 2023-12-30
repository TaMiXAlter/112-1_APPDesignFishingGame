using System;
using System.Collections.Generic;
using Core;
using UnityEngine;
using View;

namespace Controller
{
    public class ViewManager:MySingleton<ViewManager>
    {
        [SerializeField] private ViewBase WelcomeView,GamePlayView,ShopView,EquipmentView,GaChaView;
        private ViewBase _instanceView { get; set; }
        private ViewBase _previousView;
        private void Start()
        {
            HideAllView();
            
            _instanceView = WelcomeView;
            _instanceView.Show();
            _instanceView.Initialize(this);
        }

        private void OnDisable()
        {
            foreach (var VARIABLE in FindObjectsOfType<ViewBase>())
            {
                VARIABLE.EndUpView();
            }
        }


        #region ViewController
        
        private void NextView(ViewBase nextView)
        {
            
            _previousView = _instanceView;
            _instanceView = nextView;
            
            _previousView.Hide();
            _instanceView.Show();
            _instanceView.Initialize(this);
        }

        public void GoToGamePlayView() => NextView(GamePlayView);
        public void GoToShopView() => NextView(ShopView);
        public void GoToEquipmentView() => NextView(EquipmentView);
        public void GoTOGaChaView() => NextView(GaChaView);

        public void PreviousView()
        {
            _instanceView.Hide();
            _previousView.Show();

            _instanceView = _previousView;
        }


        private static void HideAllView()
        {
            foreach (var VARIABLE in FindObjectsOfType<ViewBase>())
            {
                VARIABLE.Hide();
            }
             
        }
        #endregion
    }
}