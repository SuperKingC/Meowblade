using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameDataEditor;
using HotFix.Base.Scripts.Chapter;
using Shift.Legion.Common.Managers;
using UnityEngine;

public class MapBackgroundController : MonoBehaviour, IMapBackgroundController
{
	public static float MapLength = 129f;

	public static float FarBackgroundMoveSpeed = 6f;

	public static float CloseBackgroundMoveSpeed = 12f;

	public static float MainBackgroundMoveSpeed = 25.8f;

	public static float TopBackgroundMoveSpeed = 25.8f;

	public static float FarBackgroundLength = 25.8f;

	public static float CloseBackgroundLength = 25.8f;

	public static float MainBackgroundLength = 25.8f;

	public static float TopBackgroundLength = 25.8f;

	private List<GameObject> _farBackgrounds = new List<GameObject>();

	private List<GameObject> _closeBackgrounds = new List<GameObject>();

	private List<GameObject> _mainBackgrounds = new List<GameObject>();

	private List<GameObject> _topBackgrounds = new List<GameObject>();

	private List<GameObject> _farBackgroundsFx = new List<GameObject>();

	private List<GameObject> _closeBackgroundsFx = new List<GameObject>();

	private List<GameObject> _mainBackgroundsFx = new List<GameObject>();

	private List<GameObject> _topBackgroundsFx = new List<GameObject>();

	private string _mapIdentifier;

	private GDEMapFXData _mapFxData;

	public static float FarBackgroundRatio;

	public static float CloseBackgroundRatio;

	private Transform _mainCameraTransform;

	private Vector3 _previousCameraPosition;

	private static Dictionary<string, GDEMapFXData> _allMapFxData;

	private bool FinishReset = false;

	private Dictionary<string, GameObject> Cache_FX;

	public float StartX { get; set; }

	public static Dictionary<string, GDEMapFXData> AllMapFxData
	{
		get
		{
			if (_allMapFxData == null)
			{
				_allMapFxData = new Dictionary<string, GDEMapFXData>();
				IEnumerable<GDEMapFXData> allItems = GDMgr.GetAllItems<GDEMapFXData>();
				foreach (GDEMapFXData item in allItems)
				{
					if (!_allMapFxData.ContainsKey(item.MapIdentifier))
					{
						_allMapFxData.Add(item.MapIdentifier, item);
					}
				}
			}
			return _allMapFxData;
		}
	}

	public string Identifier
	{
		get
		{
			return _mapIdentifier;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	private void Awake()
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		FinishReset = false;
		MapLength = 129f;
		FarBackgroundMoveSpeed = 6f;
		CloseBackgroundMoveSpeed = 12f;
		MainBackgroundMoveSpeed = 25.8f;
		FarBackgroundLength = 25.8f;
		CloseBackgroundLength = 25.8f;
		MainBackgroundLength = 25.8f;
		TopBackgroundMoveSpeed = 25.8f;
		TopBackgroundLength = 25.8f;
		_farBackgrounds = new List<GameObject>();
		_closeBackgrounds = new List<GameObject>();
		_mainBackgrounds = new List<GameObject>();
		_farBackgroundsFx = new List<GameObject>();
		_closeBackgroundsFx = new List<GameObject>();
		_mainBackgroundsFx = new List<GameObject>();
		_topBackgrounds = new List<GameObject>();
		_topBackgroundsFx = new List<GameObject>();
		_mainCameraTransform = ((Component)Camera.main).transform;
		_previousCameraPosition = _mainCameraTransform.position;
	}

	private void Start()
	{
		AdjustBackgroundPosition();
	}

	public void SetMapIdentifier(string mapIdentifier)
	{
		if (_mapIdentifier == mapIdentifier)
		{
			FinishReset = true;
			return;
		}
		_mapIdentifier = mapIdentifier;
		if (AllMapFxData.ContainsKey(_mapIdentifier))
		{
			_mapFxData = AllMapFxData[_mapIdentifier];
		}
		else
		{
			_mapFxData = null;
		}
		ResetBackground();
	}

	public void SetScale(Vector3 scale)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		((Component)this).transform.localScale = scale;
	}

	public void ClearBackgrounds()
	{
		ClearBackgrounds(_farBackgrounds);
		ClearBackgrounds(_closeBackgrounds);
		ClearBackgrounds(_mainBackgrounds);
		ClearBackgrounds(_topBackgrounds);
		ClearBackgrounds(_farBackgroundsFx);
		ClearBackgrounds(_closeBackgroundsFx);
		ClearBackgrounds(_mainBackgroundsFx);
		ClearBackgrounds(_topBackgroundsFx);
		if (Cache_FX == null)
		{
			Cache_FX = new Dictionary<string, GameObject>();
		}
		Cache_FX.Clear();
	}

	private void Update()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		if (_mainCameraTransform.position == _previousCameraPosition)
		{
			return;
		}
		bool flag = _farBackgroundsFx.Count > 0;
		for (int i = 0; i < _farBackgrounds.Count; i++)
		{
			Transform transform = _farBackgrounds[i].transform;
			transform.position += new Vector3((_mainCameraTransform.position.x - _previousCameraPosition.x) * FarBackgroundRatio, 0f, 0f);
			if (flag)
			{
				Transform transform2 = _farBackgroundsFx[i].transform;
				transform2.position += new Vector3((_mainCameraTransform.position.x - _previousCameraPosition.x) * FarBackgroundRatio, 0f, 0f);
			}
		}
		for (int j = 0; j < _closeBackgrounds.Count; j++)
		{
			Transform transform3 = _closeBackgrounds[j].transform;
			transform3.position += new Vector3((_mainCameraTransform.position.x - _previousCameraPosition.x) * CloseBackgroundRatio, 0f, 0f);
			if (flag && _closeBackgroundsFx.Count > 0)
			{
				Transform transform4 = _closeBackgroundsFx[j].transform;
				transform4.position += new Vector3((_mainCameraTransform.position.x - _previousCameraPosition.x) * CloseBackgroundRatio, 0f, 0f);
			}
		}
		_previousCameraPosition = _mainCameraTransform.position;
	}

	public static void RefreshRatio()
	{
		FarBackgroundRatio = (MainBackgroundMoveSpeed - FarBackgroundMoveSpeed) / MainBackgroundMoveSpeed;
		CloseBackgroundRatio = (MainBackgroundMoveSpeed - CloseBackgroundMoveSpeed) / MainBackgroundMoveSpeed;
	}

	private async void ResetBackground()
	{
		if (string.IsNullOrEmpty(_mapIdentifier))
		{
			return;
		}
		FinishReset = false;
		double mainCnt = Math.Ceiling(MapLength / MainBackgroundLength);
		double closeCnt = Math.Ceiling(MapLength / CloseBackgroundRatio / CloseBackgroundLength);
		double farCnt = Math.Ceiling(MapLength / FarBackgroundRatio / FarBackgroundLength);
		ClearBackgrounds();
		int defaultLayerId = SortingLayer.NameToID("Default");
		int entitiesLayerId = SortingLayer.NameToID("Entities");
		for (int j = 0; (double)j < farCnt; j++)
		{
			_farBackgrounds.Add(GetFarBackground(_mapIdentifier, defaultLayerId));
		}
		await Task.Delay(100);
		for (int k = 0; (double)k < closeCnt; k++)
		{
			_closeBackgrounds.Add(GetCloseBackground(_mapIdentifier, defaultLayerId));
		}
		await Task.Delay(100);
		for (int i = 0; (double)i < mainCnt; i++)
		{
			_mainBackgrounds.Add(GetMainBackground(_mapIdentifier, defaultLayerId));
		}
		await Task.Delay(100);
		for (int l = 0; (double)l < mainCnt; l++)
		{
			_topBackgrounds.Add(GetTopBackground(_mapIdentifier, entitiesLayerId));
		}
		await Task.Delay(100);
		if (_mapFxData != null)
		{
			if (!string.IsNullOrEmpty(_mapFxData.FarFx))
			{
				for (int m = 0; (double)m < farCnt; m++)
				{
					GameObject go = GetFx(_mapFxData.FarFx, _mapFxData.FarFxOffset, defaultLayerId, 1);
					if ((Object)(object)go != (Object)null)
					{
						_farBackgroundsFx.Add(go);
					}
				}
			}
			await Task.Delay(100);
			if (!string.IsNullOrEmpty(_mapFxData.CloseFx))
			{
				for (int n = 0; (double)n < closeCnt; n++)
				{
					GameObject go2 = GetFx(_mapFxData.CloseFx, _mapFxData.CloseFxOffset - 1.5f, defaultLayerId, 3);
					if ((Object)(object)go2 != (Object)null)
					{
						_closeBackgroundsFx.Add(go2);
					}
				}
			}
			await Task.Delay(100);
			if (!string.IsNullOrEmpty(_mapFxData.MainFx))
			{
				for (int num = 0; (double)num < mainCnt; num++)
				{
					GameObject go3 = GetFx(_mapFxData.MainFx, _mapFxData.MainFxOffset, defaultLayerId, 5);
					if ((Object)(object)go3 != (Object)null)
					{
						_mainBackgroundsFx.Add(go3);
					}
				}
			}
			await Task.Delay(100);
			if (!string.IsNullOrEmpty(_mapFxData.TopFx))
			{
				for (int num2 = 0; (double)num2 < mainCnt; num2++)
				{
					GameObject go4 = GetFx(_mapFxData.TopFx, _mapFxData.TopFxOffset, entitiesLayerId, 7);
					if ((Object)(object)go4 != (Object)null)
					{
						_topBackgroundsFx.Add(go4);
					}
				}
			}
		}
		FinishReset = true;
		AdjustBackgroundPosition();
	}

	private void ClearBackgrounds(List<GameObject> list)
	{
		foreach (GameObject item in list)
		{
			SpriteRenderer component = item.GetComponent<SpriteRenderer>();
			if ((Object)(object)component != (Object)null && component.sprite != null)
			{
				AssetsManager.Instance.UnloadAsset<Sprite>(((Object)component.sprite).name);
				component.sprite = null;
			}
			Object.Destroy((Object)(object)item);
		}
		list.Clear();
	}

	private GameObject GetMainBackground(string mapIdentifier, int layerId)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		if (Cache_FX == null)
		{
			Cache_FX = new Dictionary<string, GameObject>();
		}
		GameObject val = null;
		if (!Cache_FX.ContainsKey(mapIdentifier))
		{
			val = SpawnManager.Instance.InstantiatePool("SpriteWrap", Vector3.zero, 1);
			Cache_FX.Add(mapIdentifier, val);
		}
		else
		{
			val = Object.Instantiate<GameObject>(Cache_FX[mapIdentifier]);
		}
		SpriteRenderer spriteRenderer = val.GetComponent<SpriteRenderer>();
		Transform mapBackgroundTransform = val.transform;
		((Renderer)spriteRenderer).sortingLayerID = layerId;
		((Renderer)spriteRenderer).sortingOrder = 4;
		mapBackgroundTransform.SetParent(((Component)this).transform, false);
		mapBackgroundTransform.localScale = Vector3.one;
		mapBackgroundTransform.localRotation = Quaternion.identity;
		mapBackgroundTransform.position = Vector3.zero;
		mapBackgroundTransform.localPosition = Vector3.zero;
		AssetsManager.Instance.LoadAsset<Sprite>(mapIdentifier + "_main").Then((Action<Sprite>)delegate(Sprite asset)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			spriteRenderer.sprite = asset;
			mapBackgroundTransform.localPosition = new Vector3(mapBackgroundTransform.localPosition.x, 0f, mapBackgroundTransform.localPosition.z);
		});
		return val;
	}

	private GameObject GetTopBackground(string mapIdentifier, int layerId)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		if (Cache_FX == null)
		{
			Cache_FX = new Dictionary<string, GameObject>();
		}
		GameObject val = null;
		if (!Cache_FX.ContainsKey(mapIdentifier))
		{
			val = SpawnManager.Instance.InstantiatePool("SpriteWrap", Vector3.zero, 1);
			Cache_FX.Add(mapIdentifier, val);
		}
		else
		{
			val = Object.Instantiate<GameObject>(Cache_FX[mapIdentifier]);
		}
		SpriteRenderer spriteRenderer = val.GetComponent<SpriteRenderer>();
		Transform mapBackgroundTransform = val.transform;
		((Renderer)spriteRenderer).sortingLayerID = layerId;
		((Renderer)spriteRenderer).sortingOrder = 6;
		mapBackgroundTransform.SetParent(((Component)this).transform, false);
		mapBackgroundTransform.localScale = Vector3.one;
		mapBackgroundTransform.localRotation = Quaternion.identity;
		mapBackgroundTransform.position = Vector3.zero;
		mapBackgroundTransform.localPosition = Vector3.zero;
		AssetsManager.Instance.LoadAsset<Sprite>(mapIdentifier + "_top").Then((Action<Sprite>)delegate(Sprite asset)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			spriteRenderer.sprite = asset;
			mapBackgroundTransform.localPosition = new Vector3(mapBackgroundTransform.localPosition.x, -4.45f, mapBackgroundTransform.localPosition.z);
		});
		return val;
	}

	private GameObject GetFarBackground(string mapIdentifier, int layerId)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		if (Cache_FX == null)
		{
			Cache_FX = new Dictionary<string, GameObject>();
		}
		GameObject val = null;
		if (!Cache_FX.ContainsKey(mapIdentifier))
		{
			val = SpawnManager.Instance.InstantiatePool("SpriteWrap", Vector3.zero, 1);
			Cache_FX.Add(mapIdentifier, val);
		}
		else
		{
			val = Object.Instantiate<GameObject>(Cache_FX[mapIdentifier]);
		}
		SpriteRenderer spriteRenderer = val.GetComponent<SpriteRenderer>();
		Transform mapBackgroundTransform = val.transform;
		((Renderer)spriteRenderer).sortingLayerID = layerId;
		((Renderer)spriteRenderer).sortingOrder = 0;
		mapBackgroundTransform.SetParent(((Component)this).transform, false);
		mapBackgroundTransform.localScale = Vector3.one;
		mapBackgroundTransform.localRotation = Quaternion.identity;
		AssetsManager.Instance.LoadAsset<Sprite>(mapIdentifier + "_far").Then((Action<Sprite>)delegate(Sprite asset)
		{
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			spriteRenderer.sprite = asset;
			float num = Camera.main.orthographicSize - spriteRenderer.size.y / 2f;
			mapBackgroundTransform.localPosition = new Vector3(mapBackgroundTransform.localPosition.x, num, mapBackgroundTransform.localPosition.z);
		});
		return val;
	}

	private GameObject GetFx(string fxIdentifier, float zOffset, int layerId, int sortingOrder)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		if (Cache_FX == null)
		{
			Cache_FX = new Dictionary<string, GameObject>();
		}
		GameObject val = null;
		if (!Cache_FX.ContainsKey(fxIdentifier))
		{
			val = SpawnManager.Instance.InstantiatePool(fxIdentifier, Vector3.zero, 1);
			Cache_FX.Add(fxIdentifier, val);
		}
		else
		{
			val = Object.Instantiate<GameObject>(Cache_FX[fxIdentifier]);
		}
		if ((Object)(object)val == (Object)null)
		{
			return null;
		}
		Transform transform = val.transform;
		transform.SetParent(((Component)this).transform, false);
		transform.localScale = Vector3.one;
		transform.localRotation = Quaternion.identity;
		Vector3 localPosition = transform.localPosition;
		((Vector3)(ref localPosition))._002Ector(localPosition.x, zOffset, localPosition.z);
		transform.localPosition = localPosition;
		ParticleSystem[] componentsInChildren = ((Component)transform).GetComponentsInChildren<ParticleSystem>();
		ParticleSystem[] array = componentsInChildren;
		foreach (ParticleSystem val2 in array)
		{
			Renderer component = ((Component)val2).GetComponent<Renderer>();
			if (component.enabled)
			{
				component.sortingLayerID = layerId;
				component.sortingOrder = sortingOrder;
			}
		}
		return val;
	}

	private GameObject GetCloseBackground(string mapIdentifier, int layerId)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		if (Cache_FX == null)
		{
			Cache_FX = new Dictionary<string, GameObject>();
		}
		GameObject val = null;
		if (!Cache_FX.ContainsKey(mapIdentifier))
		{
			val = SpawnManager.Instance.InstantiatePool("SpriteWrap", Vector3.zero, 1);
			Cache_FX.Add(mapIdentifier, val);
		}
		else
		{
			val = Object.Instantiate<GameObject>(Cache_FX[mapIdentifier]);
		}
		SpriteRenderer spriteRenderer = val.GetComponent<SpriteRenderer>();
		Transform mapBackgroundTransform = val.transform;
		((Renderer)spriteRenderer).sortingLayerID = layerId;
		((Renderer)spriteRenderer).sortingOrder = 2;
		mapBackgroundTransform.SetParent(((Component)this).transform, false);
		mapBackgroundTransform.localScale = Vector3.one;
		mapBackgroundTransform.localRotation = Quaternion.identity;
		AssetsManager.Instance.LoadAsset<Sprite>(mapIdentifier + "_close").Then((Action<Sprite>)delegate(Sprite asset)
		{
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			spriteRenderer.sprite = asset;
			float num = Camera.main.orthographicSize - spriteRenderer.size.y / 2f;
			mapBackgroundTransform.localPosition = new Vector3(mapBackgroundTransform.localPosition.x, num, mapBackgroundTransform.localPosition.z);
		});
		return val;
	}

	private void AdjustBackgroundPosition()
	{
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		if (!FinishReset)
		{
			return;
		}
		float num = StartX - FarBackgroundLength / 2f;
		float num2 = StartX - CloseBackgroundLength / 2f;
		float num3 = StartX - MainBackgroundLength / 2f;
		float num4 = StartX - MainBackgroundLength / 2f;
		bool flag = _mapFxData != null && !string.IsNullOrEmpty(_mapFxData.FarFx);
		for (int i = 0; i < _farBackgrounds.Count; i++)
		{
			Vector3 position = _farBackgrounds[i].transform.position;
			_farBackgrounds[i].transform.position = new Vector3(num, position.y, position.z);
			if (flag)
			{
				Vector3 position2 = _farBackgroundsFx[i].transform.position;
				_farBackgroundsFx[i].transform.position = new Vector3(num, position2.y, position2.z);
			}
			num += FarBackgroundLength;
		}
		bool flag2 = _mapFxData != null && !string.IsNullOrEmpty(_mapFxData.CloseFx);
		for (int j = 0; j < _closeBackgrounds.Count; j++)
		{
			Vector3 position3 = _closeBackgrounds[j].transform.position;
			_closeBackgrounds[j].transform.position = new Vector3(num2, position3.y, position3.z);
			if (flag2 && _closeBackgroundsFx.Count > 0)
			{
				Vector3 position4 = _closeBackgroundsFx[j].transform.position;
				_closeBackgroundsFx[j].transform.position = new Vector3(num2, position4.y, position4.z);
			}
			num2 += CloseBackgroundLength;
		}
		bool flag3 = _mapFxData != null && !string.IsNullOrEmpty(_mapFxData.MainFx);
		for (int k = 0; k < _mainBackgrounds.Count; k++)
		{
			Vector3 position5 = _mainBackgrounds[k].transform.position;
			_mainBackgrounds[k].transform.position = new Vector3(num3, position5.y, position5.z);
			if (flag3)
			{
				Vector3 position6 = _mainBackgroundsFx[k].transform.position;
				_mainBackgroundsFx[k].transform.position = new Vector3(num3, position6.y, position6.z);
			}
			num3 += MainBackgroundLength;
		}
		bool flag4 = _mapFxData != null && !string.IsNullOrEmpty(_mapFxData.TopFx);
		for (int l = 0; l < _topBackgrounds.Count; l++)
		{
			Vector3 position7 = _topBackgrounds[l].transform.position;
			_topBackgrounds[l].transform.position = new Vector3(num4, position7.y, position7.z);
			if (flag4)
			{
				Vector3 position8 = _topBackgroundsFx[l].transform.position;
				_topBackgroundsFx[l].transform.position = new Vector3(num4, position8.y, position8.z);
			}
			num4 += MainBackgroundLength;
		}
	}
}
