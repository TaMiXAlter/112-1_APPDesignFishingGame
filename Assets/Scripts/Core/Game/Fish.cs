using System.Collections;
using System.Collections.Generic;
using Interface;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    RectTransform rt;

    Image fishImage;
    string fishType;

    float leftSide;
    float rightSide;
    float topSide;
    float bottomSide;

    private Rigidbody2D _rigidbody2D;

    private float speed = 100f;
    // Start is called before the first frame update
    void Awake()
    {
        rt = GetComponent<RectTransform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        fishImage = GetComponent<Image>();

        Rect rect = rt.rect;

        // Get the present rect status.
        leftSide = rt.anchoredPosition.x - rect.width / 2;
        rightSide = rt.anchoredPosition.x + rect.width / 2;
        topSide = rt.anchoredPosition.y + rect.height / 2;
        bottomSide = rt.anchoredPosition.y - rect.height / 2;

        if(topSide <= -450 && topSide > -750)
        {
            string[] fishes = new[] { "帶魚", "鯧魚", "鯛魚" };
             //fishImage = 
            fishType = fishes[Random.Range(0,3)] ;
        }
        else if(topSide <= -750 && topSide > -900)
        {
            //fishImage = 
            fishType = "黃魚";
        }
        else if(topSide <= -900)
        {
            //fishImage = 
            fishType = "橫帶石鯛";
        }

        Texture2D tempTexture2D;

        switch(fishType)
        {
            case "帶魚":
                tempTexture2D = Resources.Load("Trichiurus_lepturus") as Texture2D;
                fishImage.sprite = Sprite.Create(tempTexture2D, new Rect(0, 0, tempTexture2D.width, tempTexture2D.height), new Vector2(0.5f ,0.5f));
                break;
            case "鯧魚":
                tempTexture2D = Resources.Load("White_Pomfret") as Texture2D;
                fishImage.sprite = Sprite.Create(tempTexture2D, new Rect(0, 0, tempTexture2D.width, tempTexture2D.height), new Vector2(0.5f ,0.5f));
                break;
            case "鯛魚":
                tempTexture2D = Resources.Load("Sparidae") as Texture2D;
                fishImage.sprite = Sprite.Create(tempTexture2D, new Rect(0, 0, tempTexture2D.width, tempTexture2D.height), new Vector2(0.5f ,0.5f));
                break;
            case "黃魚":
                tempTexture2D = Resources.Load("Larimichthys_crocea") as Texture2D;
                fishImage.sprite = Sprite.Create(tempTexture2D, new Rect(0, 0, tempTexture2D.width, tempTexture2D.height), new Vector2(0.5f ,0.5f));
                break;
            case "橫帶石鯛":
                tempTexture2D = Resources.Load("Blue_Oplegnathus_fasciatus") as Texture2D;
                fishImage.sprite = Sprite.Create(tempTexture2D, new Rect(0, 0, tempTexture2D.width, tempTexture2D.height), new Vector2(0.5f ,0.5f));
                break;
        }
        
        speed = FishBagData.GetFishSpeed(fishType);

        if (transform.localPosition.x > 0) speed *= -1;
    }

    void swim()
    {
        if(transform.localPosition.x is > 600 or < -600) Destroy(gameObject);
        
        _rigidbody2D.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    private void Update()
    {

        // Checked if the rope is in the rect / get the fish.
        float ropePosX = GameManager.Instance.GetRopePoint().x;
        float ropePosY = GameManager.Instance.GetRopePoint().y;
        if(ropePosX >= leftSide && ropePosX <= rightSide && ropePosY >= bottomSide && ropePosY <= topSide)
        {
            // Write json plus one and save.
            FishBagData.SetFishNum(fishType, FishBagData.GetFishNum(fishType) + 1);
            Debug.Log("Get the " + fishType + "!");
            
            // Tell rod to go back.
            GameManager.Instance.SetIsGetFish(true);
            Destroy(this.gameObject);
        }

        swim();
    }
}
