using UnityEngine;

public class OneTimeMovementButton2 : OneTimeMovementGeneric
{
    void OnEnable()
    {
        ButtonPressTracker.Button2Action += Move;
    }

    void OnDisable()
    {
        ButtonPressTracker.Button2Action -= Move;
    }
}
