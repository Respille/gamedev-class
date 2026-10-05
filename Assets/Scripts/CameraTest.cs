using UnityEngine;
using UnityEngine.InputSystem;

public class CameraTest : MonoBehaviour
{
    [SerializeField] float horizontalSensitivity = 0.3f;
    [SerializeField] float verticalSensitivity = 0.3f;

    float horizontalRotation;
    float verticalRotation;
    Camera mainCamera;
    Transform mainCameraTransform;
    bool secondFrameOrBefore = true;
    int frameCount = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Locks cursor to center of screen
        mainCamera = Camera.main;
        mainCameraTransform = mainCamera.transform;
        // To change initial rotation of camera, just move the camera in the editor
        horizontalRotation = mainCameraTransform.localRotation.eulerAngles.y;
        verticalRotation = mainCameraTransform.localRotation.eulerAngles.x;
    }

    void Update()
    {
        // If on frame 1 or 2, does not move the camera to prevent the camera from moving wildly
        if (secondFrameOrBefore)
        {
            frameCount++;
            if (frameCount >= 2)
            {
                secondFrameOrBefore = false;
            }
            return;
        }

        float mouseX = Mouse.current.delta.x.ReadValue();
        float mouseY = Mouse.current.delta.y.ReadValue();

        horizontalRotation += mouseX * horizontalSensitivity;
        verticalRotation -= mouseY * verticalSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Prevents looking upside down

        mainCameraTransform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0f);
    }
}
