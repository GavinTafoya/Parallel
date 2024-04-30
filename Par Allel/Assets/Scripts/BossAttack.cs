using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private GameObject target;
    private float speed = 2;

    public void SetTarget(GameObject target)
    {
        this.target = target;
        if (!target.CompareTag("Player")) gameObject.tag = "shoot";
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) GameObject.Find("A").GetComponent<PlayerController>().Hurt();
    }
}
