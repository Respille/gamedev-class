using UnityEngine;

public class Button1 : ButtonGeneric
{
    public override void OnButtonPress()
    {
        print("Button 1 pressed");
        ButtonPressTracker.ActivateButton1();
    }
}
