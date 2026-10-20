using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonPressManager : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float rayLength = 10f;
    [SerializeField] private LayerMask interactableLayers;

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        bool shouldDisableText = true;
        if (Physics.Raycast(ray, out RaycastHit hit, rayLength, interactableLayers))
        {
            //print("raycast done");
            GameObject button = hit.collider.gameObject;
            if (button.CompareTag("HiddenUnlessLit"))
            {
                //print("satisfies tag");
                InvisibleWhenUnlit inv = button.GetComponent<InvisibleWhenUnlit>();
                ButtonGeneric bg = button.GetComponent<ButtonGeneric>();
                if (inv.IsRecentlyLit)
                {
                    //print("is lit");
                    ButtonVisibilityTracker.ButtonVisible();
                    shouldDisableText = false;

                    if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
                    {
                        //print("mouse clicked");
                        bg.OnButtonPress();
                    }
                }
            }
        }

        if (shouldDisableText)
        {
            ButtonVisibilityTracker.NoButtonVisible();
        }
    }
}
