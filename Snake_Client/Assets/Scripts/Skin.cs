using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    [SerializeField] private List<Renderer> _renderers;
    [SerializeField] private float _colorMultiplier = 1f;

    public void SetColor(Color color)
    {
        Color newColor = color;
        newColor.r *= _colorMultiplier;
        newColor.g *= _colorMultiplier;
        newColor.b *= _colorMultiplier;

        for (int i = 0; i < _renderers.Count; i++)
            _renderers[i].material.color = newColor;
    }
}
