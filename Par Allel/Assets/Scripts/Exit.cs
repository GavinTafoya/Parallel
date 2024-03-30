using UnityEngine;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.Find("Main Camera").GetComponent<LevelTransitions>().NextLevel();
        }
    }
}
// 14