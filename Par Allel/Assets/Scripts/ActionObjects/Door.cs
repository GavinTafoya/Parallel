using System.Collections;
using UnityEngine;

public class Door : ActionObject
{
    [SerializeField] private float dist;
    public override void Action()
    {
        StartCoroutine(MoveUp());
    }

    private IEnumerator MoveUp()
    {
        for (int i = 0; i < 30; i++)
        {
            transform.Translate(Vector3.up * dist);
            yield return new WaitForFixedUpdate();
        }
    }
}
