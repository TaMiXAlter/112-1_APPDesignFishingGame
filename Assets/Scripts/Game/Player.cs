using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private LineRenderer lineRenderer;

    IEnumerator fishing;

    Vector3 rodPos;
    Vector3 currentPos;

    float rotAngle = 0.1f;

    bool goBack, nextFishing, startRot;

    // Start is called before the first frame update
    void Awake()
    {
        lineRenderer = transform.GetChild(0).GetComponent<LineRenderer>();

        lineRenderer.SetPosition(0, transform.GetChild(0).position);
        lineRenderer.SetPosition(1, transform.GetChild(0).position);

        rodPos = transform.GetChild(0).position;

        fishing = PutDownTheRope();

        nextFishing = true;
        startRot = true;
    }

    // Update is called once per frame
    void Update()
    {
        RotateRod();

        GoBackDetact(-34);

        if (Input.GetButtonDown("Fire1") && nextFishing)
        {
            StartCoroutine(fishing);
            nextFishing = false;
            startRot = false;
        }
    }

    void RotateRod()
    {
        if(startRot)
        {   
            if (transform.GetChild(0).rotation.z >= 0.3f)
            {
                rotAngle*=-1;
            }
            else if (transform.GetChild(0).rotation.z <= -0.3f)
            {
                rotAngle*=-1;
            }

            transform.GetChild(0).Rotate(transform.rotation.x, transform.rotation.y, rotAngle);
        }
    }

    void GoBackDetact(float endPos)
    {
        if(currentPos.y <= endPos && !goBack)
        {
            goBack = true;
        }
        else if (currentPos.y >= rodPos.y && goBack)
        {
            StopCoroutine(fishing);

            goBack = false;

            nextFishing = true;
            startRot = true;
        }
    }

    IEnumerator PutDownTheRope()
    {
        Vector3 startPos = rodPos;
        while(true)
        {
            yield return new WaitForFixedUpdate();

            if(goBack)
                currentPos = startPos += new Vector3(0, 20f * Time.fixedDeltaTime, 0);
            else
                currentPos = startPos -= new Vector3(0, 20f * Time.fixedDeltaTime, 0);

            lineRenderer.SetPosition(1, currentPos);
        }
    }
}
