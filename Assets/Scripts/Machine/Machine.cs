using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
	private float _orderCode;
	private float _materialCode;
	private float _orderCount;

	[SerializeField] private MachineConfig _machineConfig;

	public MachineConfig MachineConfig
    {
		get { return _machineConfig; }
		set { _machineConfig = value; }
	}

	public float OrderCode
	{
		get { return _orderCode; }
		set { _orderCode = value; }
	}

	public float MaterialCode
    {
		get { return _materialCode; }
		set { _materialCode = value; }
	}

	public float OrderCount
    {
		get { return _orderCount; }
		set { _orderCount = value; }
	}
}
