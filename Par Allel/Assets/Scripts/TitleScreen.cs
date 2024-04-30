using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Because the button on screen doesnt work on PC for some unknowable reason
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Equals)) StartGame();
    }

    // I hate this but the wall we track for the cinemachine camera doesnt exist until after the scene is done loading
    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}