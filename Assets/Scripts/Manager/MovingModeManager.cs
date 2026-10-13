using System.Collections.Generic;
using UnityEngine;

public class MovingModeManager : MonoBehaviour
{
    [SerializeField] List<GameObject> objectsToEnable;

    void Start()
    {
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(false);
        }
    }

    void OnEnable()
    {
        GameStateTracker.StartMovingModeAction += EnableObjects;
    }

    void OnDisable()
    {
        GameStateTracker.StartMovingModeAction -= EnableObjects;
    }

    void EnableObjects()
    {
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
        }
    }
}
