using UnityEngine;
using System;

[RequireComponent(typeof(MeshRenderer))]
public class InvisibleWhenUnlit : MonoBehaviour
{
    [NonSerialized] public bool isLit = false;
    public bool IsRecentlyLit { get; private set; } = false; // if the button has been lit in the last two frames

    private MeshRenderer meshRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void LateUpdate()
    {
        meshRenderer.enabled = isLit;
        IsRecentlyLit = isLit;
        isLit = false;        
    }
}
