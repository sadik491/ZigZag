using UnityEngine;

public class FloorCreator : MonoBehaviour
{
    public Transform floor;
    
    Vector3 lastPosition;
    float size;
    void Start()
    {
        lastPosition =transform.position;
        size = transform.localScale.x;

        for (int i = 0; i < 15; i++)
        {
            RandomFloor();
        }

        InvokeRepeating("RandomFloor", 2f, .2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.GetComponent<FollowCam>().gameOver)
        {
            CancelInvoke("RandomFloor");
        }
    }

    void RandomFloor()
    {
        int rand = Random.Range(0, 6);
        if (rand > 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastPosition;
        pos.x += size;
        lastPosition = pos;
        Instantiate(floor, pos, Quaternion.identity);
    }

    void SpawnZ()
    {
        Vector3 pos = lastPosition;
        pos.z += size;
        lastPosition = pos;
        Instantiate(floor, pos, Quaternion.identity);
    }
}
