using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyDupe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.GetType() == typeof(EventSystem))
        {
            if (GameObject.FindObjectsOfType<EventSystem>().Length > 1)
            {
                Destroy(gameObject);
            }
        }

        if(gameObject.GetType() == typeof(Camera))
        {
            if (GameObject.FindObjectsOfType<Camera>().Length > 1)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
