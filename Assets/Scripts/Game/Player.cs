using System.Collections;
using UnityEngine;


public class Player : MonoBehaviour
{
    // Rod status.
    float rodAngleSpeed;
    float maxRopeLength;
    float rodSpeed;

    Vector3 ropeCurrentPos;

    // Rod var & component.
    bool goBack, nextFishing, startRot;
    IEnumerator putDownTheRope;
    private LineRenderer lineRenderer;


    void Awake()
    {
        lineRenderer = transform.GetChild(0).GetComponent<LineRenderer>();
        SetLineRendererPosition(Vector3.zero);
    }

    void OnEnable()
    {   
        // Rigister to GM. (Let Gm to change the rod type, see the change rod type on this script's line 129.)
        GameManager.Instance.RigisterPlayer(this);
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
        GoBackDetact(maxRopeLength * -1);

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

        GameManager.Instance.UnRigisterPlayer();
    }

    void RotateRod()
    {
        // Rotate the rod.
        if(startRot)
        {   
            if (transform.GetChild(0).rotation.z >= 0.3f)
                rodAngleSpeed *= -1;
            else if (transform.GetChild(0).rotation.z <= -0.3f)
                rodAngleSpeed *= -1;

            transform.GetChild(0).Rotate(transform.rotation.x, transform.rotation.y, 0.1f * rodAngleSpeed);
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
                ropeCurrentPos = startPos += new Vector3(0, 200f * Time.fixedDeltaTime * rodSpeed, 0);
            }
            else
            {
                ropeCurrentPos = startPos -= new Vector3(0, 200f * Time.fixedDeltaTime * rodSpeed, 0);
                GameManager.Instance.SetRopePoint(Mathf.Sin(-Mathf.Deg2Rad * transform.GetChild(0).rotation.z * 180 / 1.56f) * ropeCurrentPos.y, Mathf.Cos(Mathf.Deg2Rad * transform.GetChild(0).rotation.z * 180 / 1.56f) * ropeCurrentPos.y);
            }

            lineRenderer.SetPosition(1, ropeCurrentPos);
        }
    }

    //!!!---Important---!!!

    // Change the Rod's func.
    public void ChangeRodStatus(string rodName)
    {
        rodAngleSpeed = JsonReader.Instance.GetRodAngleSpeed(rodName);
        rodSpeed = JsonReader.Instance.GetRodSpeed(rodName);
        maxRopeLength = JsonReader.Instance.GetMaxRopeLength(rodName);
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
