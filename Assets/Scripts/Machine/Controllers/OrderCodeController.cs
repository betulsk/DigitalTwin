using System;
using UnityEngine;

public class OrderCodeController : MonoBehaviour
{
    private float _orderCode = 2051920;
    public Action OnOrderCodeUpdated;

    private void Start()
    {
        InputManager.OnPressedKey += OnPressedKey;
    }

    private void OnDestroy()
    {
        InputManager.OnPressedKey -= OnPressedKey;
    }

    private void OnPressedKey(KeyCode keyCode)
    {
        if (keyCode == KeyCode.X)
        {
            IncreaseOrderCode();
        }
    }
    
    private void IncreaseOrderCode()
    {
        _orderCode++;
        OnOrderCodeUpdated?.Invoke();
    }

    public float GetOrderCode()
    {
        return _orderCode;
    }
}
