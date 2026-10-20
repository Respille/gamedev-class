using UnityEngine;

public class Button2 : ButtonGeneric
{
    protected override void OnButtonPress()
    {
        print("Button 2 pressed");
        ButtonPressTracker.ActivateButton2();
    }
}
