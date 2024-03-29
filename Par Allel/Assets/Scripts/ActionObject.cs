using UnityEngine;

public class ActionObject : MonoBehaviour
{
    public void Action()
    {
        Debug.Log("billy");
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
