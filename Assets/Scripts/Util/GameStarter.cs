using UnityEngine;

public class GameStarter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameStateTracker.StartGame();
    }
}
