using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public Swipe swipeControl;
    public Rigidbody rb;
    public GameManager gameManager;
    public bool enableBordersLimitation = false;

    public float moveSpeed = 1000;
    public float slideSpeed = 500;
    public float swipeSpeed;
    public float limitationBordersOffset = 2f;

    private Vector3 desiredPosition;

    void Update()
    {
        if (enableBordersLimitation)
        {
            var dist = (transform.position.y - Camera.main.transform.position.y);

            var leftLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
            var rightLimitation = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

            //var upLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).z;
            //var downLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).z;

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, rightLimitation - limitationBordersOffset, leftLimitation + limitationBordersOffset),
                transform.position.y,
                transform.position.z);
        }
    }

    void FixedUpdate()
    {
        //rb.AddForce(new Vector3(0, 0.1f, moveSpeed * Time.deltaTime), ForceMode.Impulse);
        var forceMode = ForceMode.VelocityChange;

        var velocity = new Vector3(-slideSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey("left"))
        {
            // Debug.Log("LEFT");
            // rb.AddForce(velocity, forceMode);
        }
        else if (Input.GetKey("right"))
        {
            // rb.AddForce((-1) * velocity, forceMode);
        }
        else if (swipeControl.SwipeLeft)
        {
            // rb.AddForce(velocity * swipeSpeed, forceMode);
        }
        else if (swipeControl.SwipeRight)
        {
            // rb.AddForce((-1) * velocity * swipeSpeed, forceMode);
        }

        // Check whether object on surface
        if (transform.position.y < -1f)
        {
            gameManager.EndGame();
        }
    }
}
