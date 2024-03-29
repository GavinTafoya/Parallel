using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    private void FixedUpdate()
    {
        //Debug.Log(Input.GetKey(KeyCode.C) + " " + Input.GetKey(KeyCode.D) + " " + Input.GetKey(KeyCode.Equals));
        if (Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Equals))
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
