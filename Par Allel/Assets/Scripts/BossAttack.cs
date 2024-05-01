using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private GameObject target;
    private float speed = 2;
    private bool startMoving = false;

    public void SetTarget(GameObject target)
    {
        this.target = target;
        if (!target.CompareTag("Player")) gameObject.tag = "shoot";
        startMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startMoving) return; 
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) GameObject.Find("A").GetComponent<PlayerController>().Hurt();
    }
}
