using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIButtonController : MonoBehaviour
{
    TextMeshProUGUI buttonText;

    void OnEnable()
    {
        buttonText = GetComponent<TextMeshProUGUI>();
        GameStateTracker.StartAction += DisableText;
        ButtonVisibilityTracker.ButtonVisibleAction += EnableText;
        ButtonVisibilityTracker.NoButtonVisibleAction += DisableText;
    }

    void OnDisable()
    {
        GameStateTracker.StartAction -= DisableText;
        ButtonVisibilityTracker.ButtonVisibleAction -= EnableText;
        ButtonVisibilityTracker.NoButtonVisibleAction -= DisableText;
    }

    void EnableText()
    {
        buttonText.text = "Left-click to press button.";
    }

    void DisableText()
    {
        buttonText.text = "";
    }
}
