using UnityEngine;

public class OneTimeMovementButton1 : OneTimeMovementGeneric
{
    void OnEnable()
    {
        ButtonPressTracker.Button1Action += Move;
    }

    void OnDisable()
    {
        ButtonPressTracker.Button1Action -= Move;
    }
}
