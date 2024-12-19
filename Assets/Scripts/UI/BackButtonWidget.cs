using UnityEngine;
using UnityEngine.UI;
using static Events;

public class BackButtonWidget : MonoBehaviour
{
    [SerializeField] private Button _backButton;

    private void Start()
    {
        EventManager<OnCameraMovementFinished>.SubscribeToEvent(OnMovementFinished);
        EventManager<OnCameraMovementStart>.SubscribeToEvent(OnCameraInit);
    }

    private void OnDestroy()
    {
        _backButton.onClick.RemoveListener(OnBackButtonClicked);
    }

    private void OnCameraInit(object sender, OnCameraMovementStart @event)
    {
        _backButton.gameObject.SetActive(false);
    }

    private void OnMovementFinished(object sender, OnCameraMovementFinished @event)
    {
        _backButton.gameObject.SetActive(true);
        _backButton.interactable = true;
        _backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnBackButtonClicked()
    {
        _backButton.onClick.RemoveListener(OnBackButtonClicked);
        _backButton.interactable = false;
        EventManager<OnBackButtonClicked>.CustomAction(this, new OnBackButtonClicked());
    }
}
