using UnityEngine;

public class Boss : MonoBehaviour
{
    private int health = 5;
    private Animator anim;
    private bool hurt = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        anim.SetBool("hurt", true);
        hurt = false;
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
