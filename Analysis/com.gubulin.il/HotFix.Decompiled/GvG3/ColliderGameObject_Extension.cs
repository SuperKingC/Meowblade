using System;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using UnityEngine;

namespace GvG3;

public static class ColliderGameObject_Extension
{
	public static void AddOnClick(this GameObject colliderObject, Action<TouchedObject> action)
	{
		GvGWorldMapController.Instance.InputManager.AddOnClick(colliderObject, action);
	}

	public static void RemoveOnClick(this GameObject colliderObject, Action<TouchedObject> action)
	{
		GvGWorldMapController.Instance.InputManager.RemoveOnClick(colliderObject, action);
	}

	public static void AddOnClick(this Collider collider, Action<TouchedObject> action)
	{
		((Component)collider).gameObject.AddOnClick(action);
	}

	public static void RemoveOnClick(this Collider collider, Action<TouchedObject> action)
	{
		((Component)collider).gameObject.RemoveOnClick(action);
	}

	public static void SetText(this GameObject go, string text)
	{
		TextMesh component = go.GetComponent<TextMesh>();
		if ((Object)(object)component == (Object)null)
		{
			ILRuntimeDebug.LogError("[ColliderGameObject_Extension] SetText go.name=" + ((Object)go).name + " has no TextMesh");
		}
		else
		{
			component.text = text;
		}
	}

	public static void SetText(this GameObject go, string text, string path)
	{
		TextMesh component = ((Component)go.transform.Find(path)).GetComponent<TextMesh>();
		if ((Object)(object)component == (Object)null)
		{
			ILRuntimeDebug.LogError("[ColliderGameObject_Extension] SetText go.name=" + ((Object)go).name + " has no TextMesh");
		}
		else
		{
			component.text = text;
		}
	}
}
