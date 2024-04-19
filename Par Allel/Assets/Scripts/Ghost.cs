using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private float speed = 2;
    private float dir = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * dir * Time.deltaTime * Vector3.right);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) // we got em bois
        {
            collision.gameObject.GetComponent<PlayerController>().Hurt();
        }
        else
        {
            dir *= -1;
        }
    }
}
