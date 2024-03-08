using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitions : MonoBehaviour
{
    [SerializeField] private GameObject a, b;
    [SerializeField] private Vector2[] spawnLocations;
    private int levelCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(GameObject.Find("Virtual Camera")); // unsure if i need to do this for the live camera but I will
    }

    public void NextLevel()
    {
        levelCounter++;
        if (levelCounter == spawnLocations.Length) levelCounter = 0;
        SceneManager.LoadScene(levelCounter);
        a.transform.position = spawnLocations[levelCounter];
        b.transform.position = spawnLocations[levelCounter] * new Vector2(-1, 1);
    }
}
