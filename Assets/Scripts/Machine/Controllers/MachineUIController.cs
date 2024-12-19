using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MachineUIController : MonoBehaviour
{
    [SerializeField] private OEEController _oeeController;
    [SerializeField] private Image _oeeSliderImage;
    [SerializeField] private TMP_Text _OEEText;

    private void Awake()
    {
        _oeeController.OnOEEUpdated += OnOEEValueUpdated;
    }

    private void OnDestroy()
    {
        _oeeController.OnOEEUpdated -= OnOEEValueUpdated;
    }

    private void OnOEEValueUpdated()
    {
        _oeeSliderImage.fillAmount = _oeeController.GetCurrentOEE() /100f;
        _OEEText.SetText(ConstValues.RATIO + _oeeController.GetCurrentOEE());
        Debug.Log("OEEValue is : " + _oeeController.GetCurrentOEE());
    }
}
