
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
    private Image _image;
    private JsonClass.Rod Myrod { get;set; }

    private void Awake()
    {
        equipButton = gameObject.GetComponent<Button>();
        _text = gameObject.GetComponentInChildren<TMP_Text>();
        _image = GetComponent<Image>();
    }

    public void Init(JsonClass.Rod rod)
    {
        Texture2D tempTexture2D = Resources.Load("EquipmentBase") as Texture2D;
        _image.sprite = Sprite.Create(tempTexture2D, new Rect(0, 0, tempTexture2D.width, tempTexture2D.height), new Vector2(0.5f ,0.5f));

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
