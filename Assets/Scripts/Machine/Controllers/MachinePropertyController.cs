using System.Collections.Generic;
using UnityEngine;

public class MachinePropertyController : MonoBehaviour
{
    [SerializeField] private Machine _machine;
    [SerializeField] private List<InfoGroup> _infoGroups;
    [SerializeField] private InfoGroup _infoGroupPrefab;
    [SerializeField] private Transform _parentTransform;

    private void Start()
    {
        CreateInfoDatas();
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

    public void UpdatePropertyValues()
    {
        foreach(var item in _infoGroups)
        {

        }
    }
}
