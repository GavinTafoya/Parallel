using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private GameObject targetPlayer;
    [SerializeField] private bool isA;
    private float speed = 0.8f;
    private float dir = 1;

    private void Start()
    {
        targetPlayer = (isA) ? GameObject.Find("A") : GameObject.Find("B");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPlayer.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // we got em bois
        {
            GameObject.Find("A").GetComponent<PlayerController>().Hurt();
        }
    }
}
