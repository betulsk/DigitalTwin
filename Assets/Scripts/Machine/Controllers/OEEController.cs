using System;
using System.Collections;
using UnityEngine;

public class OEEController : MonoBehaviour
{
    private const float MINUTE = 60f;
    private WaitForSeconds _wfs;
    private int _currentOEEValue;
    private bool _isRunning = true;

    [SerializeField] private int _minValue = 75;
    [SerializeField] private int _maxValue = 85;

    public Action OnOEEUpdated;

    private void Start()
    {
        _wfs = new WaitForSeconds(MINUTE);
        StartCoroutine(SimulateOEE());
    }

    private void OnDestroy()
    {
        _isRunning = false;
    }

    private IEnumerator SimulateOEE()
    {
        while(_isRunning)
        {
            SetValue();
            yield return _wfs;
        }
    }

    private void SetValue()
    {
        _currentOEEValue = UnityEngine.Random.Range(_minValue, _maxValue);
        OnOEEUpdated?.Invoke();
    }

    public int GetCurrentOEE()
    {
        return _currentOEEValue;
    }
}
