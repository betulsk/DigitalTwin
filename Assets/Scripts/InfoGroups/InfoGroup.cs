using System.Linq;
using TMPro;
using UnityEngine;

public class InfoGroup : MonoBehaviour
{
	private float _machineValue;
	private float _minValue;
	private float _maxValue;
	private string _properyName;
	private string _propertyConst;

    [SerializeField ] private EMachinePropertyType _infoType;
	[SerializeField ] private TMP_Text _propertyNameText;
	[SerializeField ] private TMP_Text _propertyText;
	[SerializeField ] private float _coefValue = .1f;
	
	public EMachinePropertyType InfoType
	{
		get { return _infoType; }
		set { _infoType = value; }
	}

	public void SetDatas(MachineData machineData, int value)
	{
		var keyList = machineData.PropertyTypeToValues.Dictionary.Keys.ToList();
        InfoType = keyList[value];
		_propertyConst = machineData.PropertyTypeToConstValue.Dictionary[InfoType];
		_machineValue = machineData.PropertyTypeToValues.Dictionary[InfoType];
		SetMinMaxValue();
        _propertyNameText.SetText(machineData.PropertyTypeToNameStr.Dictionary[InfoType]);
        SetDataVisual(_machineValue + _propertyConst);
    }

    private void SetMinMaxValue()
    {
		_minValue = _machineValue - (_machineValue * _coefValue);
		_maxValue = _machineValue + (_machineValue * _coefValue);
    }

	private void SetDataVisual(string propertyValueText)
	{
        _propertyText.SetText(propertyValueText);
    }

    public void UpdateDatas()
	{
		_machineValue = UnityEngine.Random.Range(_minValue, _maxValue);
        SetDataVisual(_machineValue + _propertyConst);
    }
}
