using UnityEngine;

public class ButtonGeneric : MonoBehaviour
{
    public bool IsPressed { get; private set; } = false;

    public void PressButton()
    {
        if (IsPressed) return;
        IsPressed = true;
        OnButtonPress();
    }

    protected virtual void OnButtonPress()
    {
        print("Button pressed!");
    }
}
