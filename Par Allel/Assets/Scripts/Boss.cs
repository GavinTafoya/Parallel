using UnityEngine;

public class Boss : MonoBehaviour
{
    private int health = 5;
    private Animator anim;
    private bool hurt = false;
    private GameObject target;

    [SerializeField] private GameObject attack;
    private float attackTimer;
    private float attackCooldown = 5f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        anim.SetBool("hurt", hurt);
        hurt = false;

        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            attackTimer = 0;
            target = GameObject.Find(Random.value > 0.5f ? "A" : "B");
            GameObject shoot = Instantiate(attack, transform.position, Quaternion.identity);
            shoot.GetComponent<BossAttack>().SetTarget(target);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("shoot"))
        {
            health--;
            hurt = true;
        }
    }
}
