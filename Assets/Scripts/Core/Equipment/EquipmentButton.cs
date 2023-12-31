
using Controller;
using Interface;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentButton : MonoBehaviour
{
    private Button equipButton;
    private TMP_Text _text;
    private int MyId { get;set; }

    private void Awake()
    {
        equipButton = gameObject.GetComponent<Button>();
        _text = gameObject.GetComponentInChildren<TMP_Text>();
    }

    public void Init(int SetId)
    {
        MyId = SetId;
        equipButton.onClick.AddListener(ButtonPress);
    }
    private void OnDisable()
    {
        print("dis");
        Destroy(this.gameObject);
    }
    private void ButtonPress()
    {
        RodBagData.SetRodNow(MyId);
        ViewManager.Instance.PreviousView();
        print(RodBagData.GetRodNow());
    }

    public void SetupText(string name,float Speed,float lenth,float spin)
    {
        string newtext = name + ": \n";
        newtext += "speed: " + Speed+"\n lenth :"+lenth+"\n spin:"+spin;
        _text.text = newtext;
    }
    
}
