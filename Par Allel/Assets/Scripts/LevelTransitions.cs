using Cinemachine;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitions : MonoBehaviour
{
    [SerializeField] private GameObject a, b;
    [SerializeField] private Vector2[] spawnLocations;
    private int levelCounter = 1;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(GameObject.Find("Virtual Camera")); // unsure if i need to do this for the live camera but I will
        SceneManager.activeSceneChanged += FindCameraTarget;
    }

    public void NextLevel()
    {
        levelCounter++;
        if ((levelCounter - 1) == spawnLocations.Length) levelCounter = 0;
        SceneManager.LoadScene(levelCounter);
        StartCoroutine("TP_Players");
        PlayerPrefs.SetInt("levelCount", levelCounter);
    }

    public void SetLevel(int level)
    {
        levelCounter = level;
    }

    public void FindCameraTarget(Scene old, Scene news)
    {
        GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("MiddleWall").transform;
    }

    public void Teleport()
    {
        StartCoroutine("TP_Players");
    }

    private IEnumerator TP_Players()
    {
        yield return new WaitForSeconds(.5f);
        a.transform.position = spawnLocations[levelCounter - 1];
        b.transform.position = spawnLocations[levelCounter - 1] * new Vector2(-1, 1);
    }
}
// 204