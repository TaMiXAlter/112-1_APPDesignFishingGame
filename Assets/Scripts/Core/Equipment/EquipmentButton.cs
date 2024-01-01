
using Controller;
using Interface;
using Struct;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentButton : MonoBehaviour
{
    private Button equipButton;
    private TMP_Text _text;
    private JsonClass.Rod Myrod { get;set; }

    private void Awake()
    {
        equipButton = gameObject.GetComponent<Button>();
        _text = gameObject.GetComponentInChildren<TMP_Text>();
    }

    public void Init(JsonClass.Rod rod)
    {
        Myrod = rod;
        equipButton.onClick.AddListener(ButtonPress);
    }
    private void OnDisable()
    {
        Destroy(this.gameObject);
    }
    private void ButtonPress()
    {
        GameManager.Instance.player.ChangeRodStatus(Myrod.ID);
        RodBagData.SetRodNow(Myrod);
        ViewManager.Instance.PreviousView();
        print(RodBagData.GetRodNowID());
    }

    public void SetupText(string name,float Speed,float lenth,float spin)
    {
        string newtext = name + ": \n";
        newtext += "speed: " + Speed+"\n lenth :"+lenth+"\n spin:"+spin;
        _text.text = newtext;
    }
    
}
