using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Alert : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _alertPlaceholder = null;

    public string alertText
    {
        get => _alertPlaceholder.text;
        set => _alertPlaceholder.text = value;
    }

    private void Awake()
    {
        if(gameObject.activeSelf)
        gameObject.SetActive(false);
    }
}
