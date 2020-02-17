using UnityEngine;


public class BallControl : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    bool gameOver;
    bool started;
    float screenWidth;
    public GameObject partical;

    void Start()
    {
        started = false;
        gameOver = false;
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
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            Camera.main.GetComponent<FollowCam>().gameOver = true;
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
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

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Daimond")
        {
            GameObject part = Instantiate(partical, col.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(part, 1f);
        }
    }
}
