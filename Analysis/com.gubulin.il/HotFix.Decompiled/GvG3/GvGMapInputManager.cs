using System;
using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GvG3;

public class GvGMapInputManager
{
	private struct TouchInfo
	{
		public Ray ray;

		public Vector3 floorPos;
	}

	private Transform FloorTouchTracker;

	private Transform CameraTracker;

	private TouchedObject SelectingTarget;

	private List<GameObject> TouchDownTargets;

	private Vector3 TouchStart;

	private Vector3 StartFloorPos;

	private Vector3 ObjectMoveStart;

	private float pinchDist;

	private bool IsMoseDown;

	private bool IsMovingCamera;

	private bool IsMovingObject;

	private bool IsTouchEndProcessed;

	private bool IsStopPropagation;

	private Dictionary<string, int> eObjectTypeOrder_Dict;

	public bool Enabled;

	public bool DragEnabled;

	public Rect cameraDragRect;

	public bool DisablePinch;

	public Action<float> OnPinch = delegate
	{
	};

	public Action OnPinchStart = delegate
	{
	};

	public Action OnPinchEnd = delegate
	{
	};

	public Action OnStartDragCamera = delegate
	{
	};

	public Action OnDragCamera = delegate
	{
	};

	private CustomUniqueEvent<List<TouchedObject>> OnClickAny;

	private Dictionary<eObjectType, CustomUniqueEvent<TouchedObject>> TouchEvent_Dict;

	private Dictionary<int, CustomUniqueEvent<TouchedObject>> ColliderTouchEvent_Dict;

	private HashSet<eObjectType> DraggableObjects = new HashSet<eObjectType>();

	public void InitInput(Transform floorTouchTracker, Transform cameraTraker)
	{
		FloorTouchTracker = floorTouchTracker;
		CameraTracker = cameraTraker;
		Enabled = true;
		DragEnabled = true;
		TouchDownTargets = new List<GameObject>();
		DisablePinch = false;
		OnClickAny = new CustomUniqueEvent<List<TouchedObject>>();
		eObjectTypeOrder_Dict = new Dictionary<string, int>();
		ColliderTouchEvent_Dict = new Dictionary<int, CustomUniqueEvent<TouchedObject>>();
		TouchEvent_Dict = new Dictionary<eObjectType, CustomUniqueEvent<TouchedObject>>();
		foreach (eObjectType value in Enum.GetValues(typeof(eObjectType)))
		{
			eObjectTypeOrder_Dict[value.ToString()] = (int)value;
			TouchEvent_Dict.Add(value, new CustomUniqueEvent<TouchedObject>());
		}
	}

	public void UpdateInput()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected I4, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Invalid comparison between Unknown and I4
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Invalid comparison between Unknown and I4
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Invalid comparison between Unknown and I4
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		if (!Enabled)
		{
			return;
		}
		if (Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch(0);
			TouchPhase phase = ((Touch)(ref touch)).phase;
			TouchPhase val = phase;
			switch ((int)val)
			{
			case 0:
				IsTouchEndProcessed = false;
				OnTouchDown(GetFinger1HitFloorPos(touch));
				break;
			case 3:
				if (!IsTouchEndProcessed)
				{
					IsTouchEndProcessed = true;
					OnTouchUp(GetFinger1HitFloorPos(touch));
				}
				break;
			case 1:
				OnDrag(GetFinger1HitFloorPos(touch));
				break;
			case 2:
				break;
			}
		}
		else if (Input.touchCount > 1)
		{
			if (!DisablePinch)
			{
				Touch touch2 = Input.GetTouch(0);
				Touch touch3 = Input.GetTouch(1);
				Vector2 val2;
				if ((int)((Touch)(ref touch2)).phase == 0 || (int)((Touch)(ref touch3)).phase == 0)
				{
					val2 = ((Touch)(ref touch2)).position - ((Touch)(ref touch3)).position;
					pinchDist = ((Vector2)(ref val2)).magnitude;
					OnPinchStart?.Invoke();
				}
				else if ((int)((Touch)(ref touch2)).phase == 3)
				{
					OnTouchDown(GetFinger1HitFloorPos(touch3));
					OnPinchEnd?.Invoke();
				}
				else if ((int)((Touch)(ref touch3)).phase == 3)
				{
					OnTouchDown(GetFinger1HitFloorPos(touch2));
					OnPinchEnd?.Invoke();
				}
				else
				{
					val2 = ((Touch)(ref touch2)).position - ((Touch)(ref touch3)).position;
					float magnitude = ((Vector2)(ref val2)).magnitude;
					OnPinch?.Invoke(pinchDist / magnitude);
				}
			}
		}
		else
		{
			if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && !EventSystem.current.IsPointerOverGameObject())
			{
				IsMoseDown = true;
				OnTouchDown(GetMouseHitFloorPos());
			}
			else if ((Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)) && !EventSystem.current.IsPointerOverGameObject())
			{
				IsMoseDown = false;
				OnTouchUp(GetMouseHitFloorPos());
			}
			if (IsMoseDown)
			{
				OnDrag(GetMouseHitFloorPos());
			}
			else
			{
				UpdateMouseTracker();
			}
		}
	}

	public void StopPropagation()
	{
		IsStopPropagation = true;
	}

	public eObjectType GetObjectTypeByName(string colliderName)
	{
		int value;
		return eObjectTypeOrder_Dict.TryGetValue(colliderName, out value) ? ((eObjectType)value) : eObjectType.None;
	}

	private void OnTouchDown(TouchInfo touchInfo)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		FloorTouchTracker.position = touchInfo.floorPos;
		TouchStart = touchInfo.floorPos;
		StartFloorPos = touchInfo.floorPos;
		TouchDownTargets = GetRaycastColliders(touchInfo.ray);
	}

	private void OnTouchUp(TouchInfo touchInfo)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (!IsMovingCamera)
		{
			List<GameObject> colliders = GetRaycastColliders(touchInfo.ray).Intersect(TouchDownTargets).ToList();
			List<TouchedObject> orderedTouchedObjects = GetOrderedTouchedObjects(colliders);
			SelectingTarget = ((orderedTouchedObjects.Count > 0) ? orderedTouchedObjects[0] : null);
			TouchDownTargets.Clear();
			IsStopPropagation = false;
			foreach (TouchedObject item in orderedTouchedObjects)
			{
				if (IsStopPropagation)
				{
					break;
				}
				if (ColliderTouchEvent_Dict.TryGetValue(((object)item.Collider).GetHashCode(), out var value) && !value.IsEmpty)
				{
					value.Invoke(item);
				}
				if (TouchEvent_Dict.TryGetValue(item.Type, out var value2) && !value2.IsEmpty)
				{
					value2.Invoke(item);
				}
			}
			OnClickAny?.Invoke(orderedTouchedObjects);
		}
		IsMovingCamera = false;
		IsMovingObject = false;
	}

	private void OnDrag(TouchInfo touchInfo)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		if (!DragEnabled)
		{
			return;
		}
		FloorTouchTracker.position = touchInfo.floorPos;
		Vector3 delta = FloorTouchTracker.position - TouchStart;
		if (!IsMovingCamera && !IsMovingObject && ((Vector3)(ref delta)).magnitude > Camera.main.orthographicSize / 25f)
		{
			if (SelectingTarget != null && TouchDownTargets.Contains(SelectingTarget.Collider) && CheckDraggableObj())
			{
				IsMovingObject = true;
				ObjectMoveStart = SelectingTarget.Collider.transform.position;
			}
			else
			{
				IsMovingCamera = true;
				OnStartDragCamera?.Invoke();
			}
		}
		if (IsMovingObject)
		{
			OnDragObject(ObjectMoveStart, delta);
		}
		else if (IsMovingCamera)
		{
			Transform cameraTracker = CameraTracker;
			cameraTracker.position -= FloorTouchTracker.position - StartFloorPos;
			if (GvG3IslandController.IsInstanceCreated && (Object)(object)GvG3IslandController.Instance != (Object)null)
			{
				CameraTracker.position = GvG3IslandController.Instance.PosChecker_Island(GvG3IslandController.Instance.ZoomLevel, CameraTracker.position);
			}
			else if (cameraDragRect != Rect.zero)
			{
				CameraTracker.position = new Vector3(Mathf.Clamp(CameraTracker.position.x, ((Rect)(ref cameraDragRect)).xMin, ((Rect)(ref cameraDragRect)).xMax), CameraTracker.position.y, Mathf.Clamp(CameraTracker.position.z, ((Rect)(ref cameraDragRect)).yMin * 1.414f, ((Rect)(ref cameraDragRect)).yMax * 1.414f));
			}
			OnDragCamera?.Invoke();
		}
	}

	private List<GameObject> GetRaycastColliders(Ray ray)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		List<GameObject> list = new List<GameObject>();
		RaycastHit[] array = Physics.RaycastAll(ray, 1000f);
		for (int i = 0; i < array.Length; i++)
		{
			RaycastHit val = array[i];
			list.Add(((Component)((RaycastHit)(ref val)).collider).gameObject);
		}
		return list;
	}

	private List<TouchedObject> GetOrderedTouchedObjects(List<GameObject> colliders)
	{
		List<TouchedObject> list = new List<TouchedObject>();
		foreach (GameObject collider in colliders)
		{
			list.Add(new TouchedObject(collider, eObjectTypeOrder_Dict.TryGetValue(((Object)collider).name, out var value) ? ((eObjectType)value) : eObjectType.None));
		}
		return list.OrderByDescending((TouchedObject o) => (int)o.Type).ToList();
	}

	private TouchInfo GetFinger1HitFloorPos(Touch touch)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		Vector2 position = ((Touch)(ref touch)).position;
		Ray ray = Camera.main.ScreenPointToRay(Vector2.op_Implicit(position));
		Vector3 direction = ((Ray)(ref ray)).direction;
		Vector3 normalized = ((Vector3)(ref direction)).normalized;
		Vector3 floorPos = normalized * (((Ray)(ref ray)).origin.y / Mathf.Abs(normalized.y)) + ((Ray)(ref ray)).origin;
		return new TouchInfo
		{
			ray = ray,
			floorPos = floorPos
		};
	}

	private TouchInfo GetMouseHitFloorPos()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		Vector3 mousePosition = Input.mousePosition;
		Ray ray = Camera.main.ScreenPointToRay(mousePosition);
		Vector3 direction = ((Ray)(ref ray)).direction;
		Vector3 normalized = ((Vector3)(ref direction)).normalized;
		Vector3 floorPos = normalized * (((Ray)(ref ray)).origin.y / Mathf.Abs(normalized.y)) + ((Ray)(ref ray)).origin;
		return new TouchInfo
		{
			ray = ray,
			floorPos = floorPos
		};
	}

	private void UpdateMouseTracker()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		TouchInfo mouseHitFloorPos = GetMouseHitFloorPos();
		FloorTouchTracker.position = mouseHitFloorPos.floorPos;
	}

	public void AddOnClickAny(Action<List<TouchedObject>> action)
	{
		if (action == null)
		{
			throw new Exception("[GvGMapInputManager] AddOnClickAny action is null");
		}
		OnClickAny.AddListener(action);
	}

	public void RemoveOnClickAny(Action<List<TouchedObject>> action)
	{
		if (action == null)
		{
			throw new Exception("[GvGMapInputManager] RemoveOnClickAny action is null");
		}
		OnClickAny.RemoveListener(action);
	}

	public void ClearOnClickAny()
	{
		OnClickAny.Clear();
	}

	public void AddOnClick(eObjectType type, Action<TouchedObject> action)
	{
		if (action == null)
		{
			throw new Exception($"[GvGMapInputManager] AddOnClick type={type} action is null");
		}
		TouchEvent_Dict[type].AddListener(action);
	}

	public void RemoveOnClick(eObjectType type, Action<TouchedObject> action)
	{
		if (action == null)
		{
			throw new Exception($"[GvGMapInputManager] RemoveOnClick type={type} action is null");
		}
		TouchEvent_Dict[type].RemoveListener(action);
	}

	public void ClearOnClick(eObjectType type)
	{
		TouchEvent_Dict[type].Clear();
	}

	public void AddOnClick(GameObject colliderObject, Action<TouchedObject> action)
	{
		if (action == null)
		{
			throw new Exception("[GvGMapInputManager] AddOnClick colliderObject=" + ((Object)colliderObject).name + " action is null");
		}
		int hashCode = ((object)colliderObject).GetHashCode();
		if (!ColliderTouchEvent_Dict.TryGetValue(hashCode, out var value))
		{
			value = new CustomUniqueEvent<TouchedObject>();
			ColliderTouchEvent_Dict.Add(hashCode, value);
		}
		value.AddListener(action);
	}

	public void RemoveOnClick(GameObject colliderObject, Action<TouchedObject> action)
	{
		if (action == null)
		{
			throw new Exception("[GvGMapInputManager] RemoveOnClick colliderObject=" + ((Object)colliderObject).name + " action is null");
		}
		int hashCode = ((object)colliderObject).GetHashCode();
		if (ColliderTouchEvent_Dict.TryGetValue(hashCode, out var value))
		{
			value.RemoveListener(action);
			if (value.IsEmpty)
			{
				ColliderTouchEvent_Dict.Remove(hashCode);
			}
		}
	}

	private bool CheckDraggableObj()
	{
		return false;
	}

	private void OnDragObject(Vector3 startPos, Vector3 delta)
	{
	}
}
