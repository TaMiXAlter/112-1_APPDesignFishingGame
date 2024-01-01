using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using Struct;
using Unity.VisualScripting;
using UnityEngine;

public class ItemViewPort : MonoBehaviour
{
    public GameObject _equipmentButtonBase;
    private List<EquipmentButton> Equipments;
    private float gridHright = 350.0f;
    public EquipmentButton _CurrentRod;
    void OnEnable()
    {
        spawnEquipmentButton();
    }

    private void OnDisable()
    {
        
    }
    
    void spawnEquipmentButton()
    {
        foreach (var VARIABLE in RodBagData.GetAllRod().Rod)
        {
            if (VARIABLE != RodBagData.GetRodNow())
            {
                EquipmentButton _equipmentButton = Instantiate(_equipmentButtonBase,transform).GetComponent<EquipmentButton>();
                _equipmentButton.Init(VARIABLE);
                _equipmentButton.SetupText(VARIABLE.Name,VARIABLE.RopeDownSpeed,VARIABLE.MaxRopeLength,VARIABLE.RodSpinSpeed);
            }
        }
    }

    void SetLenth(float bottom)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, -bottom);
    }
}
