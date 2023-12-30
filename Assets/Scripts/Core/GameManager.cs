using System.Collections.Generic;
using System.ComponentModel;
using Core;
using UnityEngine;
using View;

public class GameManager : MySingleton<GameManager>
{
    // Player parameter.
    private Player player;
    private Vector2 ropePoint;
    private bool isGetFish;

    // GameManager parameter.
    private List<string> rodStrings;
    private string currentRodType;
    private void Awake()
    {
        rodStrings = JsonReader.Instance.GetAllRod();

        // Var is the type you want to change.
        currentRodType = rodStrings.Find(rod => rod == "NormalFishingRod");
    }

    private void Update()
    {
        // Testing change the rod
        if(player != null && Input.GetKeyDown(KeyCode.Q))
            if (JsonReader.Instance.GetRodIsOwn(rodStrings.Find(rod => rod == "NormalFishingRod")))
            {
                currentRodType = rodStrings.Find(rod => rod == "NormalFishingRod");
                player.ChangeRodStatus(currentRodType);
                Debug.Log("Change to NormalFishingRod");
            }
            else
                Debug.Log("NormalFishingRod Not Own");

        else if (player != null && Input.GetKeyDown(KeyCode.E))
            if (JsonReader.Instance.GetRodIsOwn(rodStrings.Find(rod => rod == "FishingRod1")))
            {
                currentRodType = rodStrings.Find(rod => rod == "FishingRod1");
                player.ChangeRodStatus(currentRodType);
                Debug.Log("Change to FishingRod1");
            }
            else
                Debug.Log("FishingRod1 Not Own");
    }


    #region "Rigister player"
    public void RigisterPlayer(Player temp)
    {
        player = temp;
        // Let GM to switch the rod type when player rigister.
        player.ChangeRodStatus(currentRodType);
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
