using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating(nameof(ToggleCollision), 0, 1.5f);
    }

    private void ToggleCollision()
    {
        foreach (Collider2D collider in transform.GetComponentsInChildren<Collider2D>()) collider.enabled = !collider.enabled;
    }
}
//25