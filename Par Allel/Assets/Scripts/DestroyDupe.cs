using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyDupe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetType() == typeof(EventSystem))
        {
            if (FindObjectsOfType<EventSystem>().Length > 1) Destroy(gameObject);
        }

        if (gameObject.GetType() == typeof(Camera))
        {
            if (FindObjectsOfType<Camera>().Length > 1) Destroy(gameObject);
        }
    }
}