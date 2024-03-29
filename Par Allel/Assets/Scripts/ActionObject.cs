using UnityEngine;

public class ActionObject : MonoBehaviour
{
    public virtual void Action()
    {
        Debug.Log("billy");
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
