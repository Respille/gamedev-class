using UnityEngine;

[CreateAssetMenu(fileName = "SOLaserStats", menuName = "Custom/Scriptable Objects/Laser Stats")]
public class SOLaserStats : ScriptableObject
{
    public int initialDamage = 10;
    public float initialLaserSpeed = 5f; // a laser moves x units every second
    public float initialSpawnPeriod = 2f; // a laser spawns every x seconds

    public int Damage { get; private set; }
    public float LaserSpeed { get; private set; }
    public float SpawnPeriod { get; private set; }

    public void ResetValues()
    {
        Damage = initialDamage;
        LaserSpeed = initialLaserSpeed;
        SpawnPeriod = initialSpawnPeriod;
    }
}
