using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    private InputManager inputManager;

    private void Start()
    {
        inputManager = GameObject.Find("TouchManager").GetComponent<InputManager>();
    }

    private void FixedUpdate()
    {
        if (inputManager.isInteracting || Input.GetKey(KeyCode.E))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        int levelCounter = 1;
        if (PlayerPrefs.HasKey("levelCount")) levelCounter = PlayerPrefs.GetInt("levelCount");
        GameObject.Find("Main Camera").GetComponent<LevelTransitions>().SetLevel(levelCounter);
        SceneManager.LoadScene(1);
    }
}
