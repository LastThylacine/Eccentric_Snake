using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSettings : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private bool _defaultValue;
    [SerializeField] private string _key;

    private void Start()
    {
        SetValue(Convert.ToBoolean(PlayerPrefs.GetInt(_key, _defaultValue ? 1 : 0)));
    }

    private void SetValue(bool value)
    {
        _toggle.isOn = value;
        PlayerPrefs.SetInt(_key, value ? 1 : 0);
    }

    public void SetValueFromToggle()
    {
        SetValue(_toggle.isOn);
    }
}
