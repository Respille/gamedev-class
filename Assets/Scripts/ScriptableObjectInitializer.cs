using UnityEngine;

public class ScriptableObjectInitializer : MonoBehaviour
{
    [SerializeField] SOPlayerStats SOPlayerStats;
    [SerializeField] SOLaserStats SOLaserStats;
    [SerializeField] GameObject gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeScriptableObjects();
    }

    public void InitializeScriptableObjects()
    {
        SOPlayerStats.ResetValues();
        SOPlayerStats.countdownController = gameManager.GetComponent<CountdownController>();
        SOPlayerStats.uiBonusController = gameManager.GetComponent<UIBonusController>();
        SOLaserStats.ResetValues();
    }
}
