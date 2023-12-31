using System;
using System.Collections.Generic;
using Core;
using Interface;
using UnityEngine;

public class GameManager : MySingleton<GameManager>
{
    // Player parameter.
    [SerializeField] private Player player;
    private Vector2 ropePoint;
    private bool isGetFish;
    // GameManager parameter.

    private void Awake()
    {
        print(RodBagData.GetRodNow());
        InitializationRod(RodBagData.GetRodNow());
    }

    private void InitializationRod(int SetupRodID)=>player.ChangeRodStatus(SetupRodID);


    #region "For fish check"
    public void SetRopePoint(float xPos, float yPos)
    {
        ropePoint = new Vector2(xPos, yPos);
    }

    public Vector2 GetRopePoint()
    {
        return ropePoint;
    }
    #endregion


    #region "For after get fish check"
    public void SetIsGetFish(bool value)
    {
        isGetFish = value;
    }

    public bool GetIsGetFish()
    {
        return isGetFish;
    }
    #endregion
}
