using System.Collections;
using UnityEditor;
using UnityEngine;

public class Exit : MonoBehaviour
{
    bool ending = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && !ending)
        {
            ending = true;
            StartCoroutine(Open());
        }
    }

    private IEnumerator Open()
    {
        GetComponent<Animator>().SetBool("triggered", true);
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("Main Camera").GetComponent<LevelTransitions>().NextLevel();
    }
}
// 14