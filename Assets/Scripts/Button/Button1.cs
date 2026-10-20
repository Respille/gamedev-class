using UnityEngine;

public class Button1 : ButtonGeneric
{
    protected override void OnButtonPress()
    {
        print("Button 1 pressed");
        ButtonPressTracker.ActivateButton1();
    }
}
