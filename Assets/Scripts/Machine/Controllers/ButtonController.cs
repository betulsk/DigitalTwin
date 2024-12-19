using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button _moreInfoButton;

    private void Start()
    {
        _moreInfoButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnDestroy()
    {
        _moreInfoButton.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        Application.OpenURL(ConstValues.GOOGLE_ADDRESS);
    }
}
