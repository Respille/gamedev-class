using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BonusPanelSpawner : MonoBehaviour
{
    [SerializeField] GameObject bonusPanelPrefab;
    [SerializeField] SOPlayerStats SOPlayerStats;
    [SerializeField] float minZ;
    [SerializeField] float maxZ;
    [SerializeField] float y;
    [SerializeField] float distanceBetweenPanels;
    [SerializeField] float leftX;
    [SerializeField] float rightX;

    List<GameObject> instantiatedPanels = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetPanels();
    }

    void OnEnable()
    {
        SOPlayerStats.GameOverAction += ResetPanels;
    }

    void OnDisable()
    {
        SOPlayerStats.GameOverAction -= ResetPanels;
    }

    void ResetPanels()
    {
        foreach (GameObject panel in instantiatedPanels)
        {
            Destroy(panel);
        }
        instantiatedPanels.Clear();

        float z = minZ;
        bool isLeft = true;
        while (z <= maxZ)
        {
            float x = isLeft ? leftX : rightX;
            isLeft = !isLeft;

            Vector3 spawnPosition = new Vector3(x, y, z);
            GameObject newPanel = Instantiate(bonusPanelPrefab, spawnPosition, Quaternion.identity);
            instantiatedPanels.Add(newPanel);

            z += distanceBetweenPanels;
        }
    }
}
