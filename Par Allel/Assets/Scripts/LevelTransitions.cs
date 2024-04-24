using Cinemachine;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

// not touching this much yet until we have levels more figured out
public class LevelTransitions : MonoBehaviour
{
    [SerializeField] private GameObject a, b;
    [SerializeField] private Vector2[] spawnLocations;
    private int levelCounter = 0;
    [SerializeField] private Rect[] viewportRects;
    [SerializeField] private float[] cameraSizes;

    private GameObject virtualCam1;
    private GameObject virtualCam2;
    private GameObject camera2;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        virtualCam1 = GameObject.Find("Virtual Camera");
        DontDestroyOnLoad(virtualCam1);
    }

    public void NextLevel()
    {
        if (levelCounter - 1 == spawnLocations.Length) levelCounter = 0;
        levelCounter++;
        SceneManager.LoadScene(levelCounter);
        StartCoroutine(TP_Players());
        Debug.LogError("bing");
    }

    public void SetLevel(int level)
    {
        levelCounter = level;
    }

    //Not used
    public void FindCameraTarget(Scene old, Scene news)
    {
        virtualCam1.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("Cam1").transform;
        virtualCam2.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("Cam2").transform;
        virtualCam1.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = cameraSizes[levelCounter - 1];
        virtualCam2.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = cameraSizes[levelCounter - 1];
        GetComponent<Camera>().rect = viewportRects[(levelCounter - 1) * 2];
        camera2.GetComponent<Camera>().rect = viewportRects[(levelCounter - 1) * 2 + 1];
    }

    public void Teleport()
    {
        StartCoroutine(TP_Players());
    }

    private IEnumerator TP_Players()
    {
        yield return new WaitForSeconds(.1f);
        a.transform.position = spawnLocations[levelCounter - 1];
        b.transform.position = spawnLocations[levelCounter - 1] * new Vector2(-1, 1);
    }
}
// 204