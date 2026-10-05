using UnityEngine;
using System.Collections;

public class LaserSpawner : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float spawnPeriod = 2f; // a laser spawns every x seconds
    [SerializeField] float leftX;
    [SerializeField] float rightX;
    [SerializeField] float spawnZ;
    [SerializeField] float minY; // minimum y-coordinate for the left and right sides of the laser
    [SerializeField] float maxY; // maximum y-coordinate for the left and right sides of the laser

    Coroutine spawningCoroutine;
    float centerX;

    void Start()
    {
        spawningCoroutine = StartCoroutine(SpawnLasers());
        centerX = (leftX + rightX) / 2;
    }

    IEnumerator SpawnLasers()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnPeriod);

            float leftY = Random.Range(minY, maxY);
            float rightY = Random.Range(minY, maxY);
            float centerY = (leftY + rightY) / 2;

            float slope = (rightY - leftY) / (rightX - leftX);
            float rotation = Mathf.Atan(slope) * Mathf.Rad2Deg; // rotate laser around z-axis

            Vector3 spawnPosition = new Vector3(centerX, centerY, spawnZ);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, rotation + 90); // laser is initially horizontal

            GameObject newLaser = Instantiate(laserPrefab, spawnPosition, spawnRotation);
        }
    }
}
