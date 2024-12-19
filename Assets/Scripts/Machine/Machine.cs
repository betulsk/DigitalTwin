using UnityEngine;

public class Machine : MonoBehaviour
{
	[SerializeField] private MachineConfig _machineConfig;

	public MachineConfig MachineConfig
    {
		get { return _machineConfig; }
		set { _machineConfig = value; }
	}
}
