using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float x = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(5 / 4 * (3 * Mathf.Sin(x) - Mathf.Sin(3 * x)), 5 / 4 * (Mathf.Cos(x) - Mathf.Cos(3 * x)));
        x += 2 / Mathf.PI * Time.deltaTime * 4;
    }
}
