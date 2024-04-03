using Unity.VisualScripting;
using UnityEngine;

public class FloatingJoystick : MonoBehaviour
{
    [HideInInspector] public RectTransform rect;
    public RectTransform knob;

    // Start is called before the first frame update
    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        if (SystemInfo.deviceType != DeviceType.Handheld)
        {
            gameObject.SetActive(false);
        }
    }
}