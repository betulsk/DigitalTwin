using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MachineUIController : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private OEEController _oeeController;
    [SerializeField] private OrderCodeController _orderCodeController;
    [SerializeField] private MaterialCodeController _materialCodeController;

    [Header("OEE Properties")]
    [SerializeField] private Image _oeeSliderImage;
    [SerializeField] private TMP_Text _oeeText;

    [Header("Order Code Properties")]
    [SerializeField] private TMP_Text _orderCodeText;

    [Header("Material Code Properties")]
    [SerializeField] private TMP_Text _materialCodeText;

    private void Awake()
    {
        _oeeController.OnOEEUpdated += OnOEEValueUpdated;
        _orderCodeController.OnOrderCodeUpdated += OnOrderCodeUpdated;
        _materialCodeController.OnMaterialCodeUpdated += OnMaterialCodeUpdated;
    }

    private void OnDestroy()
    {
        _oeeController.OnOEEUpdated -= OnOEEValueUpdated;
        _orderCodeController.OnOrderCodeUpdated -= OnOrderCodeUpdated;
        _materialCodeController.OnMaterialCodeUpdated -= OnMaterialCodeUpdated;
    }

    private void OnMaterialCodeUpdated()
    {
        _materialCodeText.SetText(ConstValues.MATERIAL + _materialCodeController.GetMaterialCode());
    }

    private void OnOrderCodeUpdated()
    {
        _orderCodeText.SetText(ConstValues.ORDER + _orderCodeController.GetOrderCode());
    }

    private void OnOEEValueUpdated()
    {
        _oeeSliderImage.fillAmount = _oeeController.GetCurrentOEE() /100f;
        _oeeText.SetText(ConstValues.RATIO + _oeeController.GetCurrentOEE());
        Debug.Log("OEEValue is : " + _oeeController.GetCurrentOEE());
    }
}
