using TMPro;
using System;
using UnityEngine;
using System.Collections;

public class UIBonusController : MonoBehaviour
{
    [SerializeField] SOPlayerStats SOPlayerStats;
    [SerializeField] TextMeshProUGUI bonusText;

    Coroutine bonusTextCoroutine;

    public void SetBonusText(String text)
    {
        if (bonusTextCoroutine != null)
        {
            StopCoroutine(bonusTextCoroutine);
            bonusTextCoroutine = null;
        }
        bonusTextCoroutine = StartCoroutine(SetBonusTextCoroutine(text));
    }

    IEnumerator SetBonusTextCoroutine(String text)
    {
        bonusText.text = text;
        yield return new WaitForSeconds(3f);

        bonusText.text = "";
        bonusTextCoroutine = null;
        yield break;
    }
}
