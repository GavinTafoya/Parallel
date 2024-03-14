using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void StartGame()
    {
        int levelCounter = 1;
        if (PlayerPrefs.HasKey("levelCount")) levelCounter = PlayerPrefs.GetInt("levelCount");
        GameObject.Find("Main Camera").GetComponent<LevelTransitions>().SetLevel(levelCounter);
        SceneManager.LoadScene(1);
    }
}
