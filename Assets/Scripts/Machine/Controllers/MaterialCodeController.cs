using System;
using UnityEngine;

public class MaterialCodeController : MonoBehaviour
{
    private float _materialCode = 575;
    public Action OnMaterialCodeUpdated;

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
            IncreaseMaterialCode();
        }
    }

    private void IncreaseMaterialCode()
    {
        _materialCode++;
        OnMaterialCodeUpdated?.Invoke();
    }

    public float GetMaterialCode()
    {
        return _materialCode;
    }
}
