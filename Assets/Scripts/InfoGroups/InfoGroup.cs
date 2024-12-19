using System.Linq;
using TMPro;
using UnityEngine;

public class InfoGroup : MonoBehaviour
{
	[SerializeField ] private EMachinePropertyType _infoType;
	[SerializeField ] private TMP_Text _propertyNameText;
	[SerializeField ] private TMP_Text _propertyText;
	
	public EMachinePropertyType InfoType
	{
		get { return _infoType; }
		set { _infoType = value; }
	}

	public void SetDatas(MachineData machineData, int value)
	{
		var keyList = machineData.PropertyTypeToValues.Dictionary.Keys.ToList();
        InfoType = keyList[value];
		string propertyConst = machineData.PropertyTypeToConstValue.Dictionary[InfoType];

		_propertyNameText.text = machineData.PropertyTypeToNameStr.Dictionary[InfoType];
		_propertyText.SetText(machineData.PropertyTypeToValues.Dictionary[InfoType] + propertyConst);
    }
}
