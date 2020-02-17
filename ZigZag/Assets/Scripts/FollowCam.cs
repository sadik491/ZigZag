using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform ball;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ball.transform.position + offset;
    }
}
