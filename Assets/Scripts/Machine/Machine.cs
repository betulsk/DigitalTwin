using System;
using TMPro;
using UnityEngine;
using static Events;

public class Machine : MonoBehaviour
{
	[SerializeField] private MachineConfig _machineConfig;
	[SerializeField] private Collider _collider;
	[SerializeField] private TMP_Text _machineNameText;

	public MachineConfig MachineConfig
    {
		get { return _machineConfig; }
		set { _machineConfig = value; }
	}

    private void Start()
    {
        SetTextData();
        EventManager<OnCameraMovementStart>.SubscribeToEvent(OnCameraInitPos);
    }

    private void OnDestroy()
    {
        EventManager<OnCameraMovementStart>.UnsubscribeToEvent(OnCameraInitPos);
    }

    private void OnCameraInitPos(object sender, OnCameraMovementStart @event)
    {
        ChangeColliderEnableValue(true);
        ChangeTextEnableValue(true);
    }

    public void ChangeColliderEnableValue(bool enableValue)
	{
		_collider.enabled = enableValue;
    }

    private void SetTextData()
    {
        _machineNameText.SetText(_machineConfig.MachineData.MachineName);
        _machineNameText.transform.LookAt(Camera.main.transform);
        _machineNameText.transform.rotation = Camera.main.transform.rotation;
    }

    public void ChangeTextEnableValue(bool enableValue)
    {
        _machineNameText.enabled = enableValue;
    }
}
