using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MovieTransistions : MonoBehaviour
{
    private VideoPlayer video;
    private float timeLength;

    // Start is called before the first frame update
    void Start()
    {
        video = GetComponent<VideoPlayer>();
        timeLength = video.frameCount / video.frameRate;
        StartCoroutine("EndAnimation");
    }

    private IEnumerator EndAnimation()
    {
        yield return new WaitForSeconds(timeLength + 0.1f);
        GameObject.Find("Main Camera").GetComponent<LevelTransitions>().NextLevel();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            GameObject.Find("Main Camera").GetComponent<LevelTransitions>().NextLevel();
        }
    }
}
