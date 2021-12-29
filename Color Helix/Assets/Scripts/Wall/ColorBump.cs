using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBump : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Color currentColor;

    void Awake() 
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start() 
    {
        transform.parent = null;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    void Update() 
    {
        UpdateColor();
    }

    void UpdateColor()
    {
        meshRenderer.material.color = currentColor;
    }

    public Color GetColor()
    {
        return currentColor;
    }

    public Color SetColor(Color color)
    {
        return currentColor = color;
    }
}
