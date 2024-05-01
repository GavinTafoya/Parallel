using System.Collections;
using UnityEditor;
using UnityEngine;

public class Exit : MonoBehaviour
{
    bool ending = false;
    
    //Check if the player is colliding
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && !ending)
        {
            ending = true;
            StartCoroutine(Open());
        }
    }

    //Open the door
    private IEnumerator Open()
    {
        GetComponent<Animator>().SetBool("triggered", true);
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("Main Camera").GetComponent<LevelTransitions>().NextLevel();
    }
}
// 14