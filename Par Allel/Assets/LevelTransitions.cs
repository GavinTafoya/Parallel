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
    }

    public void NextLevel()
    {
        levelCounter++;
        SceneManager.LoadScene(levelCounter);
        a.transform.position = spawnLocations[levelCounter];
        b.transform.position = spawnLocations[levelCounter] * new Vector2(-1, 1);
    }
}
