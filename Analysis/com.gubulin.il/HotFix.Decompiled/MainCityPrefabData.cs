using System;
using System.Collections.Generic;
using System.Reflection;
using HotFix.Sources.Base.Scripts.MainCity;
using Shift.Legion.Helpers;
using UI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class MainCityPrefabData
{
	private static Dictionary<string, string> _Building_InitJson;

	private static Dictionary<string, string> Building_InitJson
	{
		get
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			if (_Building_InitJson == null)
			{
				AsyncOperationHandle<TextAsset> val = Addressables.LoadAssetAsync<TextAsset>((object)"MainCityPrefabData");
				TextAsset val2 = val.WaitForCompletion();
				_Building_InitJson = JsonHelper.ToObject<Dictionary<string, string>>(val2.text);
				Addressables.Release<TextAsset>(val);
			}
			return _Building_InitJson;
		}
	}

	public static void InitBuildingGameObject(GameObject _building)
	{
		string text = ((Object)_building).name.Replace("(Clone)", "");
		if (!Building_InitJson.ContainsKey(text))
		{
			ILRuntimeDebug.LogError("Building Name is {0} Not In MainCityPrefabData.Building_InitJson", text);
			return;
		}
		Transform transform = _building.transform;
		string json = Building_InitJson[text];
		Dictionary<string, Dictionary<string, string>> dictionary = JsonHelper.ToObject<Dictionary<string, Dictionary<string, string>>>(json);
		foreach (string key in dictionary.Keys)
		{
			string[] array = key.Split('@');
			string text2 = array[0];
			string component_name = array[1];
			Transform val = ((!(text2 == "")) ? transform.Find(text2) : transform);
			if ((Object)(object)val == (Object)null)
			{
				ILRuntimeDebug.LogError("path not find :{0}", text2);
				break;
			}
			GameObject gameObject = ((Component)val).gameObject;
			object val2 = GetComponentByName(gameObject, component_name);
			if (val2 == null)
			{
				val2 = AddComponentByName(gameObject, component_name, text);
			}
			if (val2 != null)
			{
				Dictionary<string, string> kV = dictionary[key];
				ChangeObjectValue(kV, transform, ref val2);
			}
		}
	}

	private static void SetValue(PropertyInfo _pfino, FieldInfo _finfo, object obj, object val)
	{
		if (_pfino != null)
		{
			_pfino.SetValue(obj, val);
		}
		if (_finfo != null)
		{
			_finfo.SetValue(obj, val);
		}
	}

	private static object AddComponentByName(GameObject go, string component_name, string root_name)
	{
		object obj = null;
		switch (component_name)
		{
		case "WorkshopController":
			obj = go.AddComponent<WorkshopController>();
			if (root_name == "Building7")
			{
				((Behaviour)(WorkshopController)obj).enabled = false;
			}
			break;
		case "ThroneController":
			obj = go.AddComponent<ThroneController>();
			break;
		case "CampController":
			obj = go.AddComponent<CampController>();
			break;
		case "StorehouseController":
			obj = go.AddComponent<StorehouseController>();
			break;
		case "VirtualBuildingController":
			obj = go.AddComponent<VirtualBuildingController>();
			if (root_name == "Building18")
			{
				((Behaviour)(VirtualBuildingController)obj).enabled = false;
			}
			break;
		case "WorkerController":
			if (!(root_name == "Building17"))
			{
				obj = go.AddComponent<WorkerController>();
			}
			break;
		case "Workbench":
			obj = go.AddComponent<Workbench>();
			break;
		case "BuilderController":
			obj = go.AddComponent<BuilderController>();
			break;
		case "UI.HitArea":
			obj = go.AddComponent<HitArea>();
			break;
		case "MaterialFlow":
			obj = go.AddComponent<MaterialFlow>();
			if (root_name == "Building7")
			{
				((Behaviour)(MaterialFlow)obj).enabled = false;
			}
			break;
		case "RecycleWorkbench":
			obj = go.AddComponent<RecycleWorkbench>();
			break;
		case "MoltenCoreWorkerController":
			obj = go.AddComponent<MoltenCoreWorkerController>();
			break;
		case "MoltenCoreController":
			obj = go.AddComponent<MoltenCoreController>();
			break;
		case "PortalSoldier":
			obj = go.AddComponent<PortalSoldier>();
			break;
		case "BlackMarketController":
			obj = go.AddComponent<BlackMarketController>();
			break;
		case "GvGExpeditionHallEntranceController":
			obj = go.AddComponent<GvGExpeditionHallEntranceController>();
			break;
		}
		return obj;
	}

	private static object GetComponentByName(GameObject go, string component_name)
	{
		object result = null;
		switch (component_name)
		{
		case "WorkshopController":
			result = go.GetComponent<WorkshopController>();
			break;
		case "ThroneController":
			result = go.GetComponent<ThroneController>();
			break;
		case "CampController":
			result = go.GetComponent<CampController>();
			break;
		case "StorehouseController":
			result = go.GetComponent<StorehouseController>();
			break;
		case "VirtualBuildingController":
			result = go.GetComponent<VirtualBuildingController>();
			break;
		case "WorkerController":
			result = go.GetComponent<WorkerController>();
			break;
		case "Workbench":
			result = go.GetComponent<Workbench>();
			break;
		case "BuilderController":
			result = go.GetComponent<BuilderController>();
			break;
		case "UI.HitArea":
			result = go.GetComponent<HitArea>();
			break;
		case "MaterialFlow":
			result = go.GetComponent<MaterialFlow>();
			break;
		case "RecycleWorkbench":
			result = go.GetComponent<RecycleWorkbench>();
			break;
		case "MoltenCoreWorkerController":
			result = go.GetComponent<MoltenCoreWorkerController>();
			break;
		case "MoltenCoreController":
			result = go.GetComponent<MoltenCoreController>();
			break;
		case "PortalSoldier":
			result = go.GetComponent<PortalSoldier>();
			break;
		case "BlackMarketController":
			result = go.GetComponent<BlackMarketController>();
			break;
		}
		return result;
	}

	private static void ChangeObjectValue(Dictionary<string, string> KV, Transform root_trans, ref object val)
	{
		foreach (string key in KV.Keys)
		{
			string text = KV[key];
			FieldInfo field = val.GetType().GetField(key);
			PropertyInfo property = val.GetType().GetProperty(key);
			if (field == null && property == null)
			{
				continue;
			}
			if (text.IndexOf("#") >= 0)
			{
				string[] array = text.Split('#');
				string text2 = array[0];
				string text3 = "";
				if (array.Length == 2)
				{
					text3 = array[1];
				}
				switch (text2)
				{
				case "Class":
				{
					string json = text.Replace("Class#", "");
					Dictionary<string, string> kV = JsonHelper.ToObject<Dictionary<string, string>>(json);
					if (field != null)
					{
						object val2 = field.GetValue(val);
						ChangeObjectValue(kV, root_trans, ref val2);
						SetValue(property, field, val, val2);
					}
					if (property != null)
					{
						object val3 = property.GetValue(val);
						ChangeObjectValue(kV, root_trans, ref val3);
						SetValue(property, field, val, val3);
					}
					break;
				}
				case "Transform":
				{
					Transform val4 = root_trans.Find(text3);
					SetValue(property, field, val, val4);
					break;
				}
				case "GameObject":
					if (!string.IsNullOrEmpty(text3))
					{
						GameObject gameObject2 = ((Component)root_trans.Find(text3)).gameObject;
						SetValue(property, field, val, gameObject2);
					}
					else
					{
						GameObject gameObject3 = ((Component)root_trans).gameObject;
						SetValue(property, field, val, gameObject3);
					}
					break;
				case "GameObject[]":
				{
					GameObject[] array2 = StringToGameObjectArray(root_trans, text3);
					if (array2 != null)
					{
						SetValue(property, field, val, array2);
					}
					break;
				}
				case "Transform[]":
				{
					Transform[] val5 = StringToTransformArray(root_trans, text3);
					SetValue(property, field, val, val5);
					break;
				}
				case "MonoBehaviour":
				{
					GameObject gameObject4 = ((Component)root_trans.Find(text3)).gameObject;
					SetValue(property, field, val, gameObject4);
					break;
				}
				default:
				{
					GameObject gameObject = ((Component)root_trans.Find(text3)).gameObject;
					object obj = GetComponentByName(gameObject, text2);
					if (obj == null)
					{
						obj = AddComponentByName(gameObject, text2, ((Object)root_trans).name);
					}
					if (obj != null)
					{
						SetValue(property, field, val, obj);
					}
					break;
				}
				}
			}
			else if (text.IndexOf("[]") == 0)
			{
				SetValue(property, field, val, null);
			}
			else if (text.IndexOf("{}") == 0)
			{
				SetValue(property, field, val, null);
			}
			else if (field != null)
			{
				if (field.FieldType.IsEnum)
				{
					object value = Enum.Parse(field.FieldType, text);
					field.SetValue(val, value);
				}
				else
				{
					object value2 = Convert.ChangeType(text, field.FieldType);
					field.SetValue(val, value2);
				}
			}
		}
	}

	private static GameObject[] StringToGameObjectArray(Transform parent, string path)
	{
		if (path == "")
		{
			return (GameObject[])(object)new GameObject[1] { ((Component)parent).gameObject };
		}
		string[] array = path.Split(',');
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < array.Length; i++)
		{
			list.Add(((Component)parent.Find(array[i])).gameObject);
		}
		return list.ToArray();
	}

	private static Transform[] StringToTransformArray(Transform parent, string path)
	{
		if (path == "")
		{
			return (Transform[])(object)new Transform[1] { parent };
		}
		string[] array = path.Split(',');
		List<Transform> list = new List<Transform>();
		for (int i = 0; i < array.Length; i++)
		{
			list.Add(parent.Find(array[i]));
		}
		return list.ToArray();
	}
}
