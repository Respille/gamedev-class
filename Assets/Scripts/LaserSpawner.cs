using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserSpawner : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] SOPlayerStats SOPlayerStats;
    [SerializeField] SOLaserStats SOLaserStats;
    [SerializeField] float leftX;
    [SerializeField] float rightX;
    [SerializeField] float spawnZ;
    [SerializeField] float minZ;
    [SerializeField] float minY; // minimum y-coordinate for the left and right sides of the laser
    [SerializeField] float maxY; // maximum y-coordinate for the left and right sides of the laser

    Coroutine spawningCoroutine;
    float centerX;
    float distanceBetweenLasers;
    List<GameObject> instantiatedLasers = new();

    void Start()
    {
        spawningCoroutine = StartCoroutine(SpawnLasers());
        centerX = (leftX + rightX) / 2;
        distanceBetweenLasers = SOLaserStats.LaserSpeed * SOLaserStats.SpawnPeriod;
        PopulateLasers();
    }

    void OnEnable()
    {
        SOPlayerStats.GameOverAction += Reset;
    }

    void OnDisable()
    {
        SOPlayerStats.GameOverAction -= Reset;
    }

    void Reset()
    {
        if (spawningCoroutine != null) // stop coroutine that's still running
        {
            StopCoroutine(spawningCoroutine);
            spawningCoroutine = null;
        }

        foreach (GameObject laser in instantiatedLasers)
        {
            Destroy(laser);
        }
        instantiatedLasers.Clear();

        spawningCoroutine = StartCoroutine(SpawnLasers());
        PopulateLasers();
    }

    void SpawnLaser(float z)
    {
        float leftY, rightY;
        do
        {
            leftY = Random.Range(minY, maxY);
            rightY = Random.Range(minY, maxY);
        } while (leftY > 2 && rightY > 2);

        float centerY = (leftY + rightY) / 2;

        float slope = (rightY - leftY) / (rightX - leftX);
        float rotation = Mathf.Atan(slope) * Mathf.Rad2Deg; // rotate laser around z-axis

        Vector3 spawnPosition = new Vector3(centerX, centerY, z);
        Quaternion spawnRotation = Quaternion.Euler(0, 0, rotation + 90); // +90 because laser is initially horizontal

        GameObject newLaser = Instantiate(laserPrefab, spawnPosition, spawnRotation);
        instantiatedLasers.Add(newLaser);
    }

    IEnumerator SpawnLasers()
    {
        while (true)
        {
            yield return new WaitForSeconds(SOLaserStats.SpawnPeriod);
            SpawnLaser(spawnZ);
        }
    }

    void PopulateLasers()
    {
        float z = spawnZ - distanceBetweenLasers;

        while (z > minZ)
        {
            SpawnLaser(z);
            z -= distanceBetweenLasers;
        }
    }
}
