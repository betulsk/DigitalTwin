using UnityEngine;
using static Events;

public class Machine : MonoBehaviour
{
	[SerializeField] private MachineConfig _machineConfig;
	[SerializeField] private Collider _collider;

	public MachineConfig MachineConfig
    {
		get { return _machineConfig; }
		set { _machineConfig = value; }
	}

    private void Start()
    {
        EventManager<OnCameraMovementStart>.SubscribeToEvent(OnCameraInitPos);
    }

    private void OnDestroy()
    {
        EventManager<OnCameraMovementStart>.UnsubscribeToEvent(OnCameraInitPos);
    }

    private void OnCameraInitPos(object sender, OnCameraMovementStart @event)
    {
        ChangeColliderEnableValue(true);
    }

    public void ChangeColliderEnableValue(bool enableValue)
	{
		_collider.enabled = enableValue;
    }
}
