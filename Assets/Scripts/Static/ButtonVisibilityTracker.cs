using System;

public static class ButtonVisibilityTracker
{
    public static event Action ButtonVisibleAction;
    public static event Action NoButtonVisibleAction;
    private static bool isButtonVisible = false;

    public static void ButtonVisible()
    {
        if (isButtonVisible) return;
        ButtonVisibleAction?.Invoke();
        isButtonVisible = true;
    }

    public static void NoButtonVisible()
    {
        if (!isButtonVisible) return;
        NoButtonVisibleAction?.Invoke();
        isButtonVisible = false;
    }
}
