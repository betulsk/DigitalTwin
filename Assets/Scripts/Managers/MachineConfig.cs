using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Create a Scriptable Object/MachineConfig", fileName = "MachineConfig")]
public class MachineConfig : ScriptableObject
{
    [SerializeField] private MachineData _machineData;
    public MachineData MachineData => _machineData;
}

[Serializable]
public struct MachineData
{
    public string MachineName;
    public float OrderCode;
    public float MaterialCode;
    public float OrderCount;
    public SerializableDictionary<EMachinePropertyType, float> PropertyTypeToValues;
    public SerializableDictionary<EMachinePropertyType, string> PropertyTypeToNameStr;
    public SerializableDictionary<EMachinePropertyType, string> PropertyTypeToConstValue;
}