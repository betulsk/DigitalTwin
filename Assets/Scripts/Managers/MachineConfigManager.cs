using UnityEngine;

public class MachineConfigManager : Singleton<MachineConfigManager>
{
    [SerializeField] private MachineConfig _machineConfig;
    public MachineConfig MachineConfig => _machineConfig;
}
