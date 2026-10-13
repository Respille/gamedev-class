using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RemoveButtonsOnGameStart : MonoBehaviour
{
    [SerializeField] List<GameObject> buttons;

    void OnEnable()
    {
        GameStateTracker.StartAction += RemoveButtons;
    }

    // Update is called once per frame
    void OnDisable()
    {
        GameStateTracker.StartAction -= RemoveButtons;
    }

    void RemoveButtons()
    {
        foreach (GameObject button in buttons)
        {
            Destroy(button);
        }
        buttons.Clear();
    }
}
