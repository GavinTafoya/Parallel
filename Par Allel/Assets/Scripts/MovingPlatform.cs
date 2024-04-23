using UnityEngine;

public class MovingPlatform : ActionObject
{
    [SerializeField] private float distance;
    [SerializeField] private float midpoint;
    [SerializeField] private bool isVertical;
    private bool moving = false;
    private float delta;

    public override void Action()
    {
        moving = true;
    }

    void Update()
    {
        if (moving)
        {
            transform.position = new Vector2(
                (!isVertical) ? Mathf.Sin(delta * distance / 2) + midpoint : transform.position.x, 
                (isVertical) ? Mathf.Sin(delta * distance / 2) + midpoint : transform.position.y
            );
            delta += Time.deltaTime;
        }
        /*transform.position = new Vector2(5 / 4 * (3 * Mathf.Sin(x) - Mathf.Sin(3 * x)), 5 / 4 * (Mathf.Cos(x) - Mathf.Cos(3 * x)));
        x += 2 / Mathf.PI * Time.deltaTime * 4;*/
    }
}
