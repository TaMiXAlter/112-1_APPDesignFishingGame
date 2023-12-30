using System.Collections;
using System.Collections.Generic;
using Interface;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Fish : MonoBehaviour
{
    RectTransform rt;

    Image fishImage;
    string fishType;

    float leftSide;
    float rightSide;
    float topSide;
    float bottomSide;
    // Start is called before the first frame update
    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        Rect rect = rt.rect;

        // Get the present rect status.
        leftSide = rt.anchoredPosition.x - rect.width / 2;
        rightSide = rt.anchoredPosition.x + rect.width / 2;
        topSide = rt.anchoredPosition.y + rect.height / 2;
        bottomSide = rt.anchoredPosition.y - rect.height / 2;

        if(topSide <= -450 && topSide > -750)
        {
            //fishImage = 
            fishType = "NormalFish";
        }
        else if(topSide <= -750 && topSide > -900)
        {
            //fishImage = 
            fishType = "RareFish";
        }
        else if(topSide <= -900)
        {
            //fishImage = 
            fishType = "SuperRareFish";
        }
    }

    // Update is called once per frame
    void Update()
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
    }
}
