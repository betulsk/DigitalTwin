using DG.Tweening;
using UnityEngine;
using static Events;

public class CameraZoomController : MonoBehaviour
{
    private Transform _initialTransform;
    private Vector3 _initialPos;
    private Quaternion _initialRot;
    private BaseClickable _clickedClickable;

    [SerializeField] private float _zoomDuration;

    private void Start()
    {
        _initialTransform = transform;
        _initialPos = transform.position;
        _initialRot = transform.rotation;
        ClickableManager.Instance.OnClickableClicked += OnClickableClicked;
        EventManager<OnBackButtonClicked>.SubscribeToEvent(OnBackButtonClick);
    }

    private void OnDestroy()
    {
        if(ClickableManager.Instance != null)
        {
            ClickableManager.Instance.OnClickableClicked -= OnClickableClicked;
        }
        EventManager<OnBackButtonClicked>.UnsubscribeToEvent(OnBackButtonClick);
    }

    private void OnBackButtonClick(object sender, OnBackButtonClicked @event)
    {
        ZoomOut();
    }

    private void OnClickableClicked(BaseClickable clickable)
    {
        _clickedClickable = clickable;
        ZoomIn();
    }

    private void ZoomIn()
    {
        transform.DOMove(_clickedClickable.CameraTargetTransform.position, _zoomDuration)
            .OnUpdate(() =>
            {
                transform.LookAt(_clickedClickable.transform);
            })
            .OnComplete(() =>
            {
                EventManager<OnCameraMovementFinished>.CustomAction(this, new OnCameraMovementFinished());
            });
    }

    private void ZoomOut()
    {
        transform.DOMove(_initialPos, _zoomDuration).OnComplete(() =>
        {
            EventManager<OnCameraMovementStart>.CustomAction(this, new OnCameraMovementStart());

        });
        transform.DORotateQuaternion(_initialRot, _zoomDuration);
    }
}
