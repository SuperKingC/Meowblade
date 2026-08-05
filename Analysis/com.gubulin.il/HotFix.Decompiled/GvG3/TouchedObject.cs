using UnityEngine;

namespace GvG3;

public class TouchedObject
{
	public readonly GameObject Collider;

	public readonly eObjectType Type;

	public GameObject Target => (GameObject)(Type switch
	{
		eObjectType.Island => ((Component)Collider.transform.parent.parent).gameObject, 
		eObjectType.Flagship => ((Component)Collider.transform.parent).gameObject, 
		_ => Collider, 
	});

	public TouchedObject(GameObject colliderObj, eObjectType type)
	{
		Collider = colliderObj;
		Type = type;
	}

	public static bool operator ==(TouchedObject a, TouchedObject b)
	{
		return a?.Equals(b) ?? ((object)b == null);
	}

	public static bool operator !=(TouchedObject a, TouchedObject b)
	{
		return !(a == b);
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		TouchedObject touchedObject = (TouchedObject)obj;
		return (Object)(object)Collider == (Object)(object)touchedObject.Collider;
	}
}
