using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject ball;
    public Vector3 offset;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            transform.position = ball.transform.position + offset;
        }
        
    }
}
