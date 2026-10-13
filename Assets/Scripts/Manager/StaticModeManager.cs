using System.Collections.Generic;
using UnityEngine;

public class StaticModeManager : MonoBehaviour
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
        GameStateTracker.StartStaticModeAction += EnableObjects;
    }

    void OnDisable()
    {
        GameStateTracker.StartStaticModeAction -= EnableObjects;
    }

    void EnableObjects()
    {
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
        }
    }
}
