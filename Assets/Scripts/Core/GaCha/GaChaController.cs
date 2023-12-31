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

    private readonly string[] names = new string[3] { "NormalFishingRod" ,"RareFishingRod","SuperRareFishingRod"};
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
        JsonClass.Rod newRod = gaChaRod();
        print(newRod.Name);
        print(newRod.RopeDownSpeed);
        print(newRod.RodSpinSpeed);
        ShowtheRod.text = newRod.Name + "\n Speed: " + newRod.RopeDownSpeed + "\n length: " + newRod.MaxRopeLength +
                          "\n Spin: " + newRod.RodSpinSpeed;
        RodBagData.AddRod(newRod);
   }

    JsonClass.Rod gaChaRod()
    {
        JsonClass.Rod outputrod = new JsonClass.Rod();
        string getthepriceName = names[Random.Range(0,2)];
        GaChaRodBase gacharod = GaChaData.GetRodBaseTypes(getthepriceName);
        outputrod.Name = getthepriceName;
        
        print(Random.Range(gacharod.RopeDownSpeedMin, gacharod.RopeDownSpeedMax));
        print(gacharod.RopeDownSpeedMin);
        
        outputrod.RopeDownSpeed = Random.Range(gacharod.RopeDownSpeedMin, gacharod.RopeDownSpeedMax);
        outputrod.MaxRopeLength = Random.Range(gacharod.RopeLengthMin, gacharod.RopeLengthMax);
        outputrod.RodSpinSpeed = gacharod.RodSpinSpeed;

        return outputrod;
    }
}
