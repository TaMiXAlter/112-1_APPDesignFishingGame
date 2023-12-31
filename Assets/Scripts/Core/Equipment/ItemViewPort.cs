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
        spawnEquipmentButton(0);
    }

    private void OnDisable()
    {
        
    }

    //這是遞迴
    void spawnEquipmentButton(int ID)
    {
        //檢查是否跟現在一樣
        int nextID = ID + 1;
        if (ID == RodBagData.GetRodNow())
        {
            spawnEquipmentButton(nextID);
            return;
        }

        JsonClass.Rod rod = RodBagData.GetTheRod(ID);
        //結束
        if (rod == null)
        {
            SetLenth(gridHright*(ID-1));
            return;
        };
        
        EquipmentButton _equipmentButton = Instantiate(_equipmentButtonBase,transform).GetComponent<EquipmentButton>();
        
        _equipmentButton.Init(ID);
        _equipmentButton.SetupText(rod.Name,rod.RopeDownSpeed,rod.MaxRopeLength,rod.RodSpinSpeed);
        
        spawnEquipmentButton(nextID);
    }

    void SetLenth(float bottom)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, -bottom);
    }
}
