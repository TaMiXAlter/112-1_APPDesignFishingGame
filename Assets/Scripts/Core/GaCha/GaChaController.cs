using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using Struct;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class GaChaController : MonoBehaviour
{
    private TMP_Text showMoney,ShowtheRod;
    private Button gaChaButton;
    private Random _random;

    private string[] names = new[] { "NormalFishingRod" ,"RareFishingRod","SuperRareFishingRod"};
    void Awake()
    {
        ShowtheRod = transform.Find("GaChaRodBase").GetComponent<TMP_Text>();
        showMoney = transform.Find("ShowMoney").GetComponent<TMP_Text>();
        gaChaButton = transform.Find("GaChaButton").GetComponent<Button>();
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
        ShowtheRod.text = newRod.Name + "\n Speed: " + newRod.RopeDownSpeed + "\n length: " + newRod.MaxRopeLength +
                          "\n Spin: " + newRod.RodSpinSpeed;
        RodBagData.AddRod(newRod);
    }

    JsonClass.Rod gaChaRod()
    {
        JsonClass.Rod outputrod = new JsonClass.Rod();
        string getthepriceName = names[_random.Next(0, 2)];
        GaChaRodBase gacharod = GaChaData.GetRodBaseTypes(getthepriceName);
        outputrod.Name = getthepriceName;
        outputrod.RopeDownSpeed = _random.Next(gacharod.RopeDownSpeedMin, gacharod.RopeDownSpeedMax)/10;
        outputrod.MaxRopeLength = _random.Next(gacharod.RopeLengthMin, gacharod.RopeLengthMax);
        outputrod.RodSpinSpeed = gacharod.RodSpinSpeed;

        return outputrod;
    }
}
