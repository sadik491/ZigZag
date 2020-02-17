using UnityEngine;


public class BallControl : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    bool started;
    
    float screenWidth;

    void Start()
    {
        started = false;
        screenWidth = Screen.width;
    }

   
    void Update()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).position.x < screenWidth)
                {
                    //left
                    rb.velocity = new Vector3(speed * Time.deltaTime, 0, speed * Time.deltaTime);
                }
                else
                {
                    //right
                    rb.velocity = new Vector3(-100f * Time.deltaTime, 0, speed * Time.deltaTime);
                }
            }
        }

        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(0, 0, speed * Time.deltaTime);
                started = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            SwitchDirection();
        }
        

    }

    private void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed * Time.deltaTime);
        }
    }
}
