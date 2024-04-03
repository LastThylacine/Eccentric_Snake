using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjectInitialize : MonoBehaviour
{
    [SerializeField] private string _playerPrefsKey;

    private void Start()
    {
        gameObject.SetActive(Convert.ToBoolean(PlayerPrefs.GetInt(_playerPrefsKey)));
    }
}
