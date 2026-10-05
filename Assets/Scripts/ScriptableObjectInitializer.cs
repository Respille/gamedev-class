using UnityEngine;

public class ScriptableObjectInitializer : MonoBehaviour
{
    [SerializeField] SOPlayerStats SOPlayerStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SOPlayerStats.ResetValues();
    }
}
