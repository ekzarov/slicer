using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public PlayerMovement playerMovement;
    public GameManager gameManager;
    public bool endGameOnCollission = true;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle" && endGameOnCollission)
        {
            playerMovement.enabled = false;
            gameManager.EndGame();
        }
    }
}