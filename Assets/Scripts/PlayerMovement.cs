using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Swipe swipeControl;
    public Rigidbody rb;
    public GameManager gameManager;

    public float moveSpeed = 1000;
    public float slideSpeed = 500;
    public float swipeSpeed;

    private Vector3 desiredPosition;

	void FixedUpdate () {

        rb.AddForce(new Vector3(0, 0, moveSpeed * Time.deltaTime));

        var velocity = new Vector3(-slideSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey("left"))
        {
            rb.AddForce(velocity, ForceMode.VelocityChange);
        }
        else if (Input.GetKey("right"))
        {
            rb.AddForce((-1) * velocity, ForceMode.VelocityChange);
        }
        else if (swipeControl.SwipeLeft)
        {
            rb.AddForce(velocity * swipeSpeed, ForceMode.VelocityChange);
        }
        else if (swipeControl.SwipeRight)
        {
            rb.AddForce((-1) * velocity * swipeSpeed, ForceMode.VelocityChange);
        }

        // Check whether object on surface
        if (transform.position.y < -1f)
        {
            gameManager.EndGame();
        }
    }
}
