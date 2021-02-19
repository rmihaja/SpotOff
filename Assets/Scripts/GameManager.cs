using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public DestinationLightController destinationLightController;
    public float waitTime = 2f;
    private void Start()
    {
    }
    public void CompleteLevel()
    {
        print("Level Won");
        destinationLightController.gameComplete = true;
        Invoke("LoadNextScene", waitTime);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
