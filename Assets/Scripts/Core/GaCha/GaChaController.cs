using System;
using Interface;
using Struct;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class GaChaController : MonoBehaviour
{
    private TMP_Text showMoney,ShowtheRod;
    private Button gaChaButton;

    private readonly string[] names = { "NormalFishingRod" ,"RareFishingRod","SuperRareFishingRod"};
    void Awake()
    {
        ShowtheRod = transform.Find("GaChaRodBase").GetComponent<TMP_Text>();
        showMoney = transform.Find("ShowMoney").GetComponent<TMP_Text>();
        gaChaButton = transform.Find("GachaButton").GetComponent<Button>();
    }

    private void OnEnable()
    {
        gaChaButton.onClick.AddListener(Gacha);
    }

    private void OnDisable()
    {
        gaChaButton.onClick.RemoveAllListeners();
    }

    // Update is called once per frame
    void Update()
    {
        showMoney.text = "Money: " + RodBagData.GetMoney();
    }

    void Gacha()
    {
        if( RodBagData.GetMoney() <100 ) {ShowtheRod.text = "you have no enough money"; return;}
        
        RodBagData.SetRMoney(-100);
        JsonClass.Rod newRod = gaChaRod();
        print(newRod.RopeDownSpeed);
        print(newRod.RodSpinSpeed);
        ShowtheRod.text = newRod.Name + "\n Speed: " + newRod.RopeDownSpeed + "\n length: " + newRod.MaxRopeLength +
                          "\n Spin: " + newRod.RodSpinSpeed;
        RodBagData.AddRod(newRod);
   }

    JsonClass.Rod gaChaRod()
    {
        JsonClass.Rod outputrod = new JsonClass.Rod();
        string GetThePriceName = names[Random.Range(0,3)];
        
        GaChaRodBase gacharod = GaChaData.GetRodBaseTypes(GetThePriceName);
        outputrod.Name = GetThePriceName;
        print(gacharod.RopeDownSpeedMin);
        
        outputrod.RopeDownSpeed = Random.Range(gacharod.RopeDownSpeedMin, gacharod.RopeDownSpeedMax);
        outputrod.MaxRopeLength = Random.Range(gacharod.RopeLengthMin, gacharod.RopeLengthMax);
        outputrod.RodSpinSpeed = gacharod.RodSpinSpeed;
        outputrod.ID = RodBagData.GetNewId();
        return outputrod;
    }
}
