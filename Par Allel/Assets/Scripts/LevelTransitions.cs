using Cinemachine;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitions : MonoBehaviour
{
    [SerializeField] private GameObject a, b;
    [SerializeField] private Vector2[] spawnLocations;
    [SerializeField] private Rect[] viewportRects;
    [SerializeField] private float[] cameraSizes;
    private int levelCounter = 1;

    private GameObject virtualCam1;
    private GameObject virtualCam2;
    private GameObject camera2;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        camera2 = GameObject.Find("Second Camera");
        DontDestroyOnLoad(camera2);
        virtualCam1 = GameObject.Find("Virtual Camera");
        DontDestroyOnLoad(virtualCam1);
        virtualCam2 = GameObject.Find("Virtual Camera (1)");
        DontDestroyOnLoad(virtualCam2);
        SceneManager.activeSceneChanged += FindCameraTarget;
    }

    public void NextLevel()
    {
        levelCounter++;
        if ((levelCounter - 1) == spawnLocations.Length) levelCounter = 0;
        SceneManager.LoadScene(levelCounter);
        a.transform.position = spawnLocations[levelCounter - 1];
        b.transform.position = spawnLocations[levelCounter - 1] * new Vector2(-1, 1);
        //PlayerPrefs.SetInt("levelCount", levelCounter);
    }

    public void SetLevel(int level)
    {
        levelCounter = level;
    }

    public void FindCameraTarget(Scene old, Scene news)
    {
        virtualCam1.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("Cam1").transform;
        virtualCam2.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("Cam2").transform;
        virtualCam1.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = cameraSizes[levelCounter - 1];
        virtualCam2.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = cameraSizes[levelCounter - 1];
        GetComponent<Camera>().rect = viewportRects[(levelCounter - 1) * 2];
        camera2.GetComponent<Camera>().rect = viewportRects[(levelCounter - 1) * 2 + 1];
    }
}
// 204