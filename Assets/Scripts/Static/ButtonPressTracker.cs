using System;

public static class ButtonPressTracker
{
    public static event Action Button1Action;
    public static event Action Button2Action;

    public static void ActivateButton1()
    {
        Button1Action?.Invoke();
    }

    public static void ActivateButton2()
    {
        Button2Action?.Invoke();
    }
}
