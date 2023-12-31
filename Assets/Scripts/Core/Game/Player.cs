using System.Collections;
using Interface;
using Struct;
using UnityEngine;


public class Player : MonoBehaviour
{
    // Rod status.
    private JsonClass.Rod currentRod { get; set; }

    private Vector3 ropeCurrentPos;

    // Rod var & component.
    bool goBack, nextFishing, startRot;
    IEnumerator putDownTheRope;
    private LineRenderer lineRenderer;
    private float GoBackSpeedUP = 3.0f;


    void Awake()
    {
        lineRenderer = transform.GetChild(0).GetComponent<LineRenderer>();
        SetLineRendererPosition(Vector3.zero);
    }

    void OnEnable()
    {   
        // Set IEnumerator func and init fishing.
        SetFishing(true);
        putDownTheRope = PutDownTheRope();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the rod.
        RotateRod();

        // Rope max length detact.
        GoBackDetact( currentRod.MaxRopeLength * -1);

        // Fishing detact.
        if (Input.GetButtonDown("Fire1") && nextFishing)
        {
            SetLineRendererPosition(new Vector3(0, -100, -1));

            SetFishing(false);

            StartCoroutine(putDownTheRope);
        }
    }

    void OnDisable()
    {
        // Stop although is still fishing.
        StopCoroutine(putDownTheRope);
        putDownTheRope = null;

        // Clear rope and ropePos.
        SetLineRendererPosition(Vector3.zero);
        ropeCurrentPos = Vector3.zero;

    }

    void RotateRod()
    {
        // Rotate the rod.
        if(startRot)
        {   
            if (transform.GetChild(0).rotation.z >= 0.3f)
                currentRod.RodSpinSpeed *= -1;
            else if (transform.GetChild(0).rotation.z <= -0.3f)
                currentRod.RodSpinSpeed *= -1;

            transform.GetChild(0).Rotate(transform.rotation.x, transform.rotation.y, 0.1f * currentRod.RodSpinSpeed);
        }
    }

    void GoBackDetact(float endPos)
    {
        float ropeLimitWidth = Mathf.Sin(Mathf.Deg2Rad * transform.GetChild(0).rotation.z * 180 / 1.56f) * ropeCurrentPos.y;
        
        // Detact if the rope out the scene or get the fish.
        if(GameManager.Instance.GetIsGetFish() || ((ropeCurrentPos.y <= endPos + -100 || ropeLimitWidth >= 540 || ropeLimitWidth <= -540) && !goBack))
        {
            goBack = true;
            GameManager.Instance.SetIsGetFish(false);
        }
        // If the rope is back to start.
        else if (ropeCurrentPos.y >= -100 && goBack)
        {
            StopCoroutine(putDownTheRope);

            SetLineRendererPosition(Vector3.zero);

            goBack = false;
            SetFishing(true);
        }
    }

    IEnumerator PutDownTheRope()
    {
        Vector3 startPos = new Vector3(0, -100, -1);

        while(true)
        {
            yield return new WaitForFixedUpdate();

            if(goBack)
            {
                ropeCurrentPos = startPos += new Vector3(0, 200f * Time.fixedDeltaTime * currentRod.RopeDownSpeed*GoBackSpeedUP, 0);
            }
            else
            {
                ropeCurrentPos = startPos -= new Vector3(0, 200f * Time.fixedDeltaTime * currentRod.RopeDownSpeed, 0);
                GameManager.Instance.SetRopePoint(Mathf.Sin(-Mathf.Deg2Rad * transform.GetChild(0).rotation.z * 180 / 1.56f) * ropeCurrentPos.y, Mathf.Cos(Mathf.Deg2Rad * transform.GetChild(0).rotation.z * 180 / 1.56f) * ropeCurrentPos.y);
            }

            lineRenderer.SetPosition(1, ropeCurrentPos);
        }
    }

    //!!!---Important---!!!

    // Change the Rod's func.
    public void ChangeRodStatus(int rodID)
    {
        currentRod = RodBagData.GetTheRod(rodID);
    }

    //!!!---Important---!!!

    #region "Tools"
    void SetLineRendererPosition(Vector3 vector3)
    {
        lineRenderer.SetPosition(0, vector3);
        lineRenderer.SetPosition(1, vector3);
    }

    void SetFishing(bool value)
    {
        nextFishing = value;
        startRot = value;
    }
    #endregion

}
