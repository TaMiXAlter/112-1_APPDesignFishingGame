using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

delegate void bePress(int myID);
public class EquipmentButton : MonoBehaviour
{
    private Button equipButton;
    private TMP_Text _text;
    private Image _image;
    public int MyId { get;set; }
    private bePress BePress;

    private void Awake()
    {
        equipButton = gameObject.GetComponent<Button>();
        _text = gameObject.GetComponentInChildren<TMP_Text>();
        _image = gameObject.GetComponent<Image>();
    }

    public void Init(int SetId)
    {
        MyId = SetId;
        if (equipButton == null)
        {
            print("no button");
        }
        equipButton.onClick.AddListener(ButtonPress);
    }

    private void Start()
    {
        
    }

    private void OnDisable()
    {
        equipButton.onClick.RemoveAllListeners();
    }
    private void ButtonPress()
    {
        BePress.Invoke(MyId);
        print(MyId);
    }

    public void SetupText(string name,float Speed,float lenth,float spin)
    {
        string newtext = name + ": \n";
        newtext += "speed: " + Speed+"\n lenth :"+lenth+"\n spin:"+spin;
        _text.text = newtext;
    }

    public void HighLight()
    {
        _image.color = Color.yellow; 
    }

    public void undoHighLight()
    {
        _image.color = Color.white;
    }
}
