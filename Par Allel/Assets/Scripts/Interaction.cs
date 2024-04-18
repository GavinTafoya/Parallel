using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private bool hasInteracted = false, interacting = false;

    // Update is called once per frame
    void Update()
    {
        if (interacting) // do some condition idk
        {
            target.SendMessage("Action");
            hasInteracted = true;
            interacting = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && !hasInteracted) interacting = true;
    }
}
