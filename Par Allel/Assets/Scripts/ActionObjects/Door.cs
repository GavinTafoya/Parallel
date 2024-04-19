using System.Collections;
using UnityEngine;

public class Door : ActionObject
{
    [SerializeField] private float dist;
    private float frame = 0;
    private bool isUp = false;

    public override void Action()
    {
        if (isUp == true) StartCoroutine(MoveDown()); 
        else StartCoroutine(MoveUp());
    }

    private IEnumerator MoveUp()
    {
        isUp = true;
        for (frame = frame; frame < 30; frame++)
        {
            transform.Translate(Vector3.up * dist);
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator MoveDown()
    {
        isUp = false;
        for (frame = frame; frame > 0; frame--)
        {
            transform.Translate(Vector3.up * dist);
            yield return new WaitForFixedUpdate();
        }
    }
}
