using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIAmmoController : MonoBehaviour
{
    TextMeshProUGUI ammoText;

    void Start()
    {
        ammoText.text = "";
    }

    void OnEnable()
    {
        ammoText = GetComponent<TextMeshProUGUI>();
        AmmoTracker.AmmoChangeAction += ChangeText;
        GameStateTracker.StartAction += ChangeText;
    }

    void OnDisable()
    {
        AmmoTracker.AmmoChangeAction -= ChangeText;
        GameStateTracker.StartAction -= ChangeText;
    }

    void ChangeText()
    {
        ammoText.text = $"Ammo: {AmmoTracker.Ammo}";
    }
}
