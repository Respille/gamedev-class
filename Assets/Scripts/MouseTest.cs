using UnityEngine;
using UnityEngine.InputSystem; // Must include this namespace

public class MouseTest : MonoBehaviour
{
    void Update()
    {
        // Ensure a mouse is connected
        if (Mouse.current == null) return;

        // 1. DETECT CLICKS
        if (Mouse.current.leftButton.wasPressedThisFrame) Debug.Log("Left Clicked");
        if (Mouse.current.leftButton.isPressed) Debug.Log("Left Held");
        if (Mouse.current.rightButton.wasReleasedThisFrame) Debug.Log("Right Released");

        // 2. GET MOUSE POSITION
        Vector2 mousePos = Mouse.current.position.ReadValue();

        // 3. GET MOUSE DELTA & SCROLL
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        Vector2 scrollDelta = Mouse.current.scroll.ReadValue(); // .y for vertical scroll
    }
}

