using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePropertyController : MonoBehaviour
{
    private const float SECOND = 1f;
    private WaitForSeconds _wfs;
    private Coroutine _updateRoutine;

    [SerializeField] private Machine _machine;
    [SerializeField] private List<InfoGroup> _infoGroups;
    [SerializeField] private InfoGroup _infoGroupPrefab;
    [SerializeField] private Transform _parentTransform;

    private void Start()
    {
        _wfs = new WaitForSeconds(SECOND);
        CreateInfoDatas();
        _updateRoutine = StartCoroutine(TimerRoutine());
    }

    private void OnDestroy()
    {
        if(_updateRoutine != null)
        {
            StopCoroutine(_updateRoutine);
        }
    }

    private void CreateInfoDatas()
    {
        MachineConfig machineConfig = _machine.MachineConfig;
        for(int i = 0; i < machineConfig.MachineData.PropertyTypeToValues.Dictionary.Count; i++)
        {
            InfoGroup infoGroup = Instantiate(_infoGroupPrefab, _parentTransform);
            infoGroup.SetDatas(machineConfig.MachineData, i);
            _infoGroups.Add(infoGroup);
        }
    }

    private void UpdatePropertyValues()
    {
        foreach(var item in _infoGroups)
        {
            item.UpdateDatas();
        }
    }

    private IEnumerator TimerRoutine()
    {
        while(true)
        {
            yield return _wfs;
            UpdatePropertyValues();
        }
    }
}
