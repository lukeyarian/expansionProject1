using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Variables/BoolVariable", fileName = "BoolVariable", order = 0)]
public class BoolVariable : ScriptableObject , ISerializationCallbackReceiver
{
	public bool InitialValue;

	[NonSerialized]
	public bool Value;

	public void OnAfterDeserialize()
	{
		Value = InitialValue;
	}

	public void OnBeforeSerialize(){}
}
