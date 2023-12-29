using System.Collections;
using UnityEngine;


public class Player : MonoBehaviour
{
    private LineRenderer lineRenderer;

    IEnumerator putDownTheRope;

    Vector3 ropeCurrentPos;

    float rodPlusAngle = 0.1f;

    float rodSpeed;

    bool goBack, nextFishing, startRot;


    void Awake()
    {
        lineRenderer = transform.GetChild(0).GetComponent<LineRenderer>();

        SetLineRendererPosition(Vector3.zero);

        putDownTheRope = PutDownTheRope();
        rodSpeed = JsonReader.Instance.GetRodSpeed("NormalFishingRod");

        SetFishing(true);
    }

    // Update is called once per frame
    void Update()
    {
        GetFish();
        // Rotate the rod.
        RotateRod();

        // Rope max length detact.
        GoBackDetact(-1280f);

        // Fishing detact.
        if (Input.GetButtonDown("Fire1") && nextFishing)
        {
            StartCoroutine(putDownTheRope);

            SetLineRendererPosition(new Vector3(0, -100, -1));

            SetFishing(false);
        }
    }

    void RotateRod()
    {
        if(startRot)
        {   
            if (transform.GetChild(0).rotation.z >= 0.3f)
                rodPlusAngle*=-1;
            else if (transform.GetChild(0).rotation.z <= -0.3f)
                rodPlusAngle*=-1;

            transform.GetChild(0).Rotate(transform.rotation.x, transform.rotation.y, rodPlusAngle);
        }
    }

    void GoBackDetact(float endPos)
    {
        float ropeLength = Mathf.Sin(Mathf.Deg2Rad * transform.GetChild(0).rotation.z * 180 / 1.56f) * ropeCurrentPos.y;
        
        // Detact if the rope out the scene.
        if((ropeCurrentPos.y <= endPos || ropeLength >= 540 || ropeLength <= -540) && !goBack)
        {
            GetFish();
            goBack = true;
        }
        // If the rope is go back.
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
                ropeCurrentPos = startPos += new Vector3(0, 200f * Time.fixedDeltaTime * rodSpeed, 0);
            else
            {
                ropeCurrentPos = startPos -= new Vector3(0, 200f * Time.fixedDeltaTime * rodSpeed, 0);
            }

            lineRenderer.SetPosition(1, ropeCurrentPos);
        }
    }

    void GetFish()
    {
        Debug.DrawRay(transform.GetChild(0).position, -transform.GetChild(0).up, Color.green);
        //RaycastHit2D hit;
        if(Physics2D.Raycast(ropeCurrentPos, Vector2.down, 1, 1 << 5))
            Debug.Log("HitUI");
    }

    //!!!---Important---!!!

    // Change the Rod's func.
    public void ChangeSpeed(string rodName)
    {
        rodSpeed = JsonReader.Instance.GetRodSpeed(rodName);
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
