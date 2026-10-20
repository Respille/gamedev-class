using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightPlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    private Light spotLight;
    private FlashlightRays flashlightRays;

    void Start()
    {
        spotLight = flashlight.GetComponent<Light>();
        flashlightRays = flashlight.GetComponent<FlashlightRays>();
    }

    void Update()
    {
        if (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame)
        {
            spotLight.enabled = !spotLight.enabled;
            flashlightRays.enabled = !flashlightRays.enabled;
        }
    }
}