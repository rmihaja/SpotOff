using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonCommands : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        print("START THE GAME");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        print("We quit the game");
        Application.Quit();
    }
}
