using System;
using UnityEngine;

public class OrderAmountController : MonoBehaviour
{
    private float _orderCount = 300;

    [SerializeField] private float _orderAmount = 50;

    public Action OnOrderAmountUpdated;

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
        if(keyCode == KeyCode.X)
        {
            IncreaseOrderAmount();
        }
    }

    private void IncreaseOrderAmount()
    {
        _orderCount += _orderAmount;
        OnOrderAmountUpdated?.Invoke();
    }

    public float GetOrderCount()
    {
        return _orderCount;
    }
}
