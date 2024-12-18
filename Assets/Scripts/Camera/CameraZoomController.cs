using DG.Tweening;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{
    private Transform _initialTransform;
    private BaseClickable _clickedClickable;

    [SerializeField] private float _zoomDuration;

    private void Start()
    {
        _initialTransform = transform;
        ClickableManager.Instance.OnClickableClicked += OnClickableClicked;
    }

    private void OnDestroy()
    {
        if(ClickableManager.Instance != null)
        {
            ClickableManager.Instance.OnClickableClicked -= OnClickableClicked;
        }
    }

    private void OnClickableClicked(BaseClickable clickable)
    {
        _clickedClickable = clickable;
        ZoomIn();
    }

    private void ZoomIn()
    {
        transform.DOMove(_clickedClickable.CameraTargetTransform.position, _zoomDuration).OnUpdate(() =>
        {
            transform.LookAt(_clickedClickable.transform);
        });
    }

    private void ZoomOut()
    {

    }
}
