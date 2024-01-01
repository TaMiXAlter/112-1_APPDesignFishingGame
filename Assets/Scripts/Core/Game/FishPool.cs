using UnityEngine;

public class FishPool : MonoBehaviour
{
    public GameObject normalFish;

    void Awake()
    {
        for(int i = transform.childCount; i < 5; i++)
        {
            GameObject tempGameobject = Instantiate<GameObject>(normalFish, this.transform);
            tempGameobject.transform.localPosition = new Vector3 (Random.Range(-440, 440), Random.Range(-1000, -500), 0);
        }
    }
    
    void Update()
    {
        if(transform.childCount <= 2)
        {
            for(int i = 2; i < 5; i++)
            {
                GameObject tempGameobject = Instantiate<GameObject>(normalFish, this.transform);
                tempGameobject.transform.localPosition = new Vector3 (Random.Range(-440, 440), Random.Range(-1000, -500), 0);
                tempGameobject.SetActive(false);
                tempGameobject.SetActive(true);
            }
        }
    }
}
