using UnityEngine;
using System;

[RequireComponent(typeof(MeshRenderer))]
public class InvisibleWhenUnlit : MonoBehaviour
{
    [NonSerialized] public bool isLit = false;
    private MeshRenderer meshRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void LateUpdate()
    {
        meshRenderer.enabled = isLit;
        isLit = false;
    }
}
