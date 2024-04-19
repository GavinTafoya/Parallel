using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float x = 0;

    void Update()
    {
        transform.position = new Vector2(5 / 4 * (3 * Mathf.Sin(x) - Mathf.Sin(3 * x)), 5 / 4 * (Mathf.Cos(x) - Mathf.Cos(3 * x)));
        x += 2 / Mathf.PI * Time.deltaTime * 4;
    }
}
