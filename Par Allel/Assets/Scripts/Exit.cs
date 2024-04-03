using UnityEngine;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("touched");
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("leveled");
            GameObject.Find("Main Camera").GetComponent<LevelTransitions>().NextLevel();
        }
    }
}
// 14