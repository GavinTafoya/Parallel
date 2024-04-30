using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MovieTransistions : MonoBehaviour
{
    private VideoPlayer video;

    // Start is called before the first frame update
    void Start()
    {
        video = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (video.frame == (long) video.frameCount)
        {
            SceneManager.LoadScene("LevelSelect");
        }
    }
}
