using UnityEngine;

public class MachineClickable : BaseClickable
{
    [SerializeField] private Machine _machine;

    public override void ClickCustomActions()
    {
        _machine.ChangeColliderEnableValue(false);
        _machine.ChangeTextEnableValue(false);
    }
}
