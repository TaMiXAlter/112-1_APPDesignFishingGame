using System;
using Interface;
using Struct;
using TMPro;
using UnityEngine;


namespace Controller.Shop
{
    public class ShopSystem:MonoBehaviour
    {
        private string[] AllFishsName = new string[] { "帶魚", "鯧魚", "鯛魚" , "橫帶石鯛","黃魚"};

        private UnityEngine.UI.Button _sellButton;
        private TMP_Text _tmpText;
        int MoneyGet = 0;
        private void Awake()
        {
            _sellButton = transform.Find("SellButton").GetComponent<UnityEngine.UI.Button>();
            _tmpText = transform.Find("TextUI").GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            string showText = "你的魚";
            MoneyGet = 0;
            foreach (var VARIABLE in AllFishsName)
            {
                showText += "\n"+VARIABLE +": "+ FishBagData.GetFishNum(VARIABLE);
                MoneyGet += FishBagData.GetFishNum(VARIABLE) * FishBagData.GetFishPrice(VARIABLE);
                
                FishBagData.SetFishNum(VARIABLE ,0);
            }
            _tmpText.text = showText +"\n 你賺到了: "+MoneyGet;
            _sellButton.onClick.AddListener(Sell);
        }

        private void OnDisable()
        {
            _sellButton.onClick.RemoveAllListeners();
        }
        
        void Sell()
        {
            RodBagData.SetRMoney(MoneyGet);
            ViewManager.Instance.PreviousView();
        }
    }
}