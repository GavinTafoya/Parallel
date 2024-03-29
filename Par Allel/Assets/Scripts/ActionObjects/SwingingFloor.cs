using System.Collections;
using UnityEngine;

public class SwingingFloor : ActionObject
{
    [SerializeField] private int dir;
    public override void Action()
    {
        StartCoroutine(Swing());
    }

    private IEnumerator Swing()
    {
        for (int i = 0; i < 30; i++)
        {
            transform.Rotate(new Vector3(0, 0, 3 * dir));
            yield return new WaitForFixedUpdate();
        }
    }
}
