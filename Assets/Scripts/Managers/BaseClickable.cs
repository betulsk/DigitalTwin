using UnityEngine;

public abstract class BaseClickable : MonoBehaviour
{
    [SerializeField] private Transform _cameraTargetTransform;

    public Transform CameraTargetTransform => _cameraTargetTransform;
    public abstract void ClickCustomActions();

    public void Click()
    {
        ClickCustomActions();
    }
}

