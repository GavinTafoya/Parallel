using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private bool isA;
    private bool loaded;
    private bool activated;
    [SerializeField] private GameObject projectile;

    private void Update()
    {
        GameObject target = GameObject.Find(isA ? "B" : "A");
        activated = DistanceBetween(transform.position, target.transform.position) < 1;
    }

    private float DistanceBetween(Vector3 self, Vector3 target)
    {
        return Mathf.Sqrt(Mathf.Pow(self.x - target.x, 2) + Mathf.Pow(self.y - target.y, 2));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bool activatedByA = collision.gameObject.layer == 8;

            else if (activatedByA && isA && loaded)
            {
                Fire();
            }
            else if (!activatedByA && !isA && loaded)
            {
                Fire();
            }
        }
        else if (collision.CompareTag("evilshoot") && activated)
        {
            Destroy(collision.gameObject);
            loaded = true;
        }
    }

    private void Fire()
    {
        GameObject shot = Instantiate(projectile, transform.position, Quaternion.identity);
        shot.GetComponent<BossAttack>().SetTarget(GameObject.Find("Boss Alien"));
    }

}
