using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    void OnEnable()
    {
        GameStateTracker.EndAction += StopGameTime;
    }

    void OnDisable()
    {
        GameStateTracker.EndAction -= StopGameTime;
    }

    private void StopGameTime()
    {
        Time.timeScale = 0f;
    }
}
