using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private bool hasInteracted = false, interacting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        if (collision.tag == "Player" && !hasInteracted)
        {
            interacting = true;
        }
    }
}
