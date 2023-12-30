using System.Collections.Generic;
using Core;
using Interface;
using UnityEngine;

public class GameManager : MySingleton<GameManager>
{
    // Player parameter.
    private Player player;
    private Vector2 ropePoint;
    private bool isGetFish;
    // GameManager parameter.
    private int currentRodID = 0; //TODO:remove this in future 
    private void Update()
    {
        // Testing change the rod
        // if(player != null && Input.GetKeyDown(KeyCode.Q))
        //     if (RodBagData.GetRodDurability(rodStrings.Find(rod => rod == "NormalFishingRod")) >0)
        //     {
        //         currentRodType = rodStrings.Find(rod => rod == "NormalFishingRod");
        //         player.ChangeRodStatus(currentRodType);
        //         Debug.Log("Change to NormalFishingRod");
        //     }
        //     else
        //         Debug.Log("NormalFishingRod Not Own");
        //
        // else if (player != null && Input.GetKeyDown(KeyCode.E))
        //     if (RodBagData.GetRodDurability(rodStrings.Find(rod => rod == "FishingRod1")) >0)
        //     {
        //         currentRodType = rodStrings.Find(rod => rod == "FishingRod1");
        //         player.ChangeRodStatus(currentRodType);
        //         Debug.Log("Change to FishingRod1");
        //     }
        //     else
        //         Debug.Log("FishingRod1 Not Own");
    }


    #region "Rigister player"
    public void RigisterPlayer(Player temp)
    {
        player = temp;
        // Let GM to switch the rod type when player rigister.
        player.ChangeRodStatus(currentRodID);
    }

    public void UnRigisterPlayer()
    {
        player = null;
    }
    #endregion


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
