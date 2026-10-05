using UnityEngine;

public class ScriptableObjectInitializer : MonoBehaviour
{
    [SerializeField] SOPlayerStats SOPlayerStats;
    [SerializeField] SOLaserStats SOLaserStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SOPlayerStats.ResetValues();
        SOLaserStats.ResetValues();
    }
}
