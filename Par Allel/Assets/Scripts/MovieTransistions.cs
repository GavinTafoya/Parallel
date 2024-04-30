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
    }

    private IEnumerator EndAnimation()
    {
        yield return new WaitForSeconds(timeLength + 0.1f);
        SceneManager.LoadScene("LevelSelect");
    }
}
