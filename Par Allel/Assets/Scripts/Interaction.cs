using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;
    private bool hasInteracted = false, interacting = false;

    // Update is called once per frame
    void Update()
    {
        if (interacting) // do some condition idk
        {
            foreach(GameObject target in targets)
            {
                target.SendMessage("Action");
            }
            hasInteracted = true;
            interacting = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && !hasInteracted) interacting = true;
    }
}
