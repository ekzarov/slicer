using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private bool gameOver = false;
    public float restartDelay = 1f;

    public void EndGame()
    {
        if (!gameOver)
        {
            gameOver = true;
            Debug.Log("Game over");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Skid(Vector3 pos, Vector3 normal, float intensity, int lastIndex)
    {
        GetComponent<Skidmarks>().AddSkidMark(pos, normal, intensity, lastIndex);
    }
}