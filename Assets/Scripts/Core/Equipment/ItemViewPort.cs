using System.Collections;
using System.Collections.Generic;
using Interface;
using Struct;
using Unity.VisualScripting;
using UnityEngine;

public class ItemViewPort : MonoBehaviour
{
    public GameObject _equipmentButtonBase;
    public List<EquipmentButton> EquipmentButtons;
    private float gridHright = 350.0f;
    void Start()
    {
        spawnEquipmentButton(0);

    }
    //這是遞迴
    void spawnEquipmentButton(int ID)
    {
        JsonClass.Rod rod = RodBagData.GetTheRod(ID);
        //結束
        if (rod == null)
        {
            SetLenth(gridHright*(ID-1));
            return;
        };
        
        EquipmentButton _equipmentButton = Instantiate(_equipmentButtonBase,transform).GetComponent<EquipmentButton>();
        _equipmentButton.SetupText(rod.Name,rod.RopeDownSpeed,rod.MaxRopeLength,rod.RodSpinSpeed);
        _equipmentButton.Init(ID);
        EquipmentButtons.Add(_equipmentButton);
        if (ID == RodBagData.GetRodNow()) _equipmentButton.HighLight();
        int nextID = ID + 1;
        spawnEquipmentButton(nextID);
    }

    void SetLenth(float bottom)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, -bottom);
    }


    
}
