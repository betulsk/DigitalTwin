using System;
using System.Collections;
using UnityEngine;

public class OEEController : MonoBehaviour
{
    private const float MINUTE = 60f;
    private int _currentOEEValue;
    private bool _isRunning = true;

    [SerializeField] private int _minValue = 75;
    [SerializeField] private int _maxValue = 85;
    public Action OnOEEUpdated;

    private void Start()
    {
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
            _currentOEEValue = UnityEngine.Random.Range(_minValue, _maxValue);
            OnOEEUpdated?.Invoke();
            yield return new WaitForSeconds(MINUTE);
        }
    }

    public int GetCurrentOEE()
    {
        return _currentOEEValue;
    }
}
