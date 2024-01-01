using UnityEngine;

public class FishPool : MonoBehaviour
{
    public GameObject normalFish;

    void Awake()
    {
        for(int i = transform.childCount; i < 5; i++)
        {
            GameObject tempGameobject = Instantiate<GameObject>(normalFish, this.transform);
            tempGameobject.transform.localPosition = new Vector3 (Random.Range(-400,400), Random.Range(-1000, -500), 0);
        }
    }
    
    void Update()
    {
        if(transform.childCount < 5)
        {
            SpawnAtRandomPlace();
        }
    }
    void SpawnAtRandomPlace()
    {
        GameObject tempGameobject = Instantiate<GameObject>(normalFish, this.transform);
        if (Random.Range(0, 2) == 0)
        {
            tempGameobject.transform.localPosition = new Vector3 (-580, Random.Range(-1000, -500), 0);
        }
        else
        {
            tempGameobject.transform.localPosition = new Vector3 (580, Random.Range(-1000, -500), 0);
        }

    }
}
