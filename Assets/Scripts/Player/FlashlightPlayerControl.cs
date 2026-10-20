using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightPlayerControl : MonoBehaviour
{
    [SerializeField] private Light flashlight;

    void Update()
    {
        if (Mouse.current != null &&
            Mouse.current.rightButton.wasPressedThisFrame)
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}