using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class GoBackButtonControl : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = gameObject.GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ViewManager.Instance.PreviousView);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }
}
