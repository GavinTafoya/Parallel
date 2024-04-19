using System.Collections;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player")) StartCoroutine(Open());
    }

    private IEnumerator Open()
    {
        GetComponent<Animator>().SetBool("triggered", true);
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("Main Camera").GetComponent<LevelTransitions>().NextLevel();
    }
}
// 14