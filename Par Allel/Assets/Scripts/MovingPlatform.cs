using UnityEngine;

public class MovingPlatform : ActionObject
{
    [SerializeField] private float distance;
    [SerializeField] private float midpoint;
    private bool moving = false;
    private float y;

    public override void Action()
    {
        moving = true;
    }

    void Update()
    {
        if (moving)
        {
            transform.position = new Vector2(transform.position.x, Mathf.Sin(y * distance / 2) + midpoint);
            y += Time.deltaTime;
        }
        /*transform.position = new Vector2(5 / 4 * (3 * Mathf.Sin(x) - Mathf.Sin(3 * x)), 5 / 4 * (Mathf.Cos(x) - Mathf.Cos(3 * x)));
        x += 2 / Mathf.PI * Time.deltaTime * 4;*/
    }
}
