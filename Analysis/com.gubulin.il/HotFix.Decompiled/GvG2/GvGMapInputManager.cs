using System;
using System.Collections.Generic;
using GvG2.Common.Models;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GvG2;

public class GvGMapInputManager
{
	private struct TouchInfo
	{
		public Ray ray;

		public Vector3 floorPos;
	}

	private Transform FloorTouchTracker;

	private Transform CameraTracker;

	private GameObject TouchDownTarget = null;

	private Vector3 TouchStart;

	private Vector3 StartFloorPos;

	private Vector3 ObjectMoveStart;

	private bool IsMoseDown = false;

	private bool IsMovingCamera = false;

	private bool IsMovingObject = false;

	public GameObject SelectingTarget = null;

	public ObjectType SelectingType = ObjectType.None;

	public bool Enabled;

	private bool IsTouchEndProcessed;

	internal bool DragEnabled;

	public Action<GameObject> OnDeselect = delegate
	{
	};

	public Action<GameObject> OnSelectIsland = delegate
	{
	};

	public Action OnDragCamera = delegate
	{
	};

	public HashSet<ObjectType> DraggableObjects = new HashSet<ObjectType>();

	public void InitInput(Transform floorTouchTracker, Transform cameraTraker)
	{
		FloorTouchTracker = floorTouchTracker;
		CameraTracker = cameraTraker;
		Enabled = true;
		DragEnabled = true;
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

	private void OnTouchDown(TouchInfo touchInfo)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		FloorTouchTracker.position = touchInfo.floorPos;
		TouchStart = touchInfo.floorPos;
		StartFloorPos = touchInfo.floorPos;
		TouchDownTarget = null;
		RaycastHit val = default(RaycastHit);
		if (Physics.Raycast(touchInfo.ray, ref val, 1000f))
		{
			TouchDownTarget = ((Component)((RaycastHit)(ref val)).collider).gameObject;
			ObjectMoveStart = TouchDownTarget.transform.position;
		}
	}

	private void OnTouchUp(TouchInfo touchInfo, Action<GameObject> OnSelecting, Action OnTouchAny)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if (!IsMovingCamera)
		{
			OnTouchAny?.Invoke();
			GameObject selectingTarget = SelectingTarget;
			SelectingTarget = null;
			SelectingType = ObjectType.None;
			RaycastHit val = default(RaycastHit);
			if (Physics.Raycast(touchInfo.ray, ref val, 1000f))
			{
				GameObject gameObject = ((Component)((RaycastHit)(ref val)).collider).gameObject;
				if ((Object)(object)gameObject == (Object)(object)TouchDownTarget)
				{
					TouchDownTarget = null;
					SelectingTarget = ((Component)((RaycastHit)(ref val)).collider).gameObject;
					if ((Object)(object)selectingTarget != (Object)null && (Object)(object)selectingTarget != (Object)(object)SelectingTarget)
					{
						OnDeselect?.Invoke(selectingTarget);
					}
					OnSelecting?.Invoke(gameObject);
				}
				else if ((Object)(object)selectingTarget != (Object)null)
				{
					OnDeselect?.Invoke(selectingTarget);
				}
			}
			else if ((Object)(object)selectingTarget != (Object)null)
			{
				OnDeselect?.Invoke(selectingTarget);
			}
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
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		if (!DragEnabled)
		{
			return;
		}
		FloorTouchTracker.position = touchInfo.floorPos;
		Vector3 delta = FloorTouchTracker.position - TouchStart;
		if (!IsMovingCamera && !IsMovingObject && ((Vector3)(ref delta)).magnitude > Camera.main.orthographicSize / 25f)
		{
			if (CheckDraggableObj())
			{
				IsMovingObject = true;
			}
			else
			{
				IsMovingCamera = true;
			}
		}
		if (IsMovingObject)
		{
			OnDragObject(ObjectMoveStart, delta);
		}
		else if (IsMovingCamera)
		{
			Vector3 cur = CameraTracker.position - (FloorTouchTracker.position - StartFloorPos);
			if ((Object)(object)GvGWorldMapController.Instance == (Object)null)
			{
				CameraTracker.position = PosChecker_Island(cur);
			}
			else
			{
				CameraTracker.position = PosChecker_WorldMap(cur);
			}
			OnDragCamera?.Invoke();
		}
	}

	private Vector3 PosChecker_Island(Vector3 cur)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		float num = cur.x;
		float num2 = cur.z;
		if (num < -29f)
		{
			num = -29f;
		}
		if (num > 39f)
		{
			num = 39f;
		}
		if (num2 < -69f)
		{
			num2 = -69f;
		}
		if (num2 > 63f)
		{
			num2 = 63f;
		}
		return new Vector3(num, cur.y, num2);
	}

	private Vector3 PosChecker_WorldMap(Vector3 cur)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		float num = cur.x;
		float num2 = cur.z;
		if (num < -7f)
		{
			num = -7f;
		}
		if (num > 7f)
		{
			num = 7f;
		}
		if (num2 < -10f)
		{
			num2 = -10f;
		}
		if (num2 > 10f)
		{
			num2 = 10f;
		}
		return new Vector3(num, cur.y, num2);
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
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		if (!Enabled)
		{
			return;
		}
		if (Input.touchCount > 0)
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
					OnTouchUp(GetFinger1HitFloorPos(touch), OnFinger1Selecting, OnFingerTouchkAny);
				}
				break;
			case 1:
				OnDrag(GetFinger1HitFloorPos(touch));
				break;
			case 2:
				break;
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
				OnTouchUp(GetMouseHitFloorPos(), OnMouseSelecting, OnClickAny);
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

	private bool CheckDraggableObj()
	{
		return false;
	}

	private void OnDragObject(Vector3 startPos, Vector3 delta)
	{
	}

	private void OnFinger1Selecting(GameObject target)
	{
		if ((Object)(object)target.transform.parent != (Object)null && (Object)(object)target.transform.parent.parent != (Object)null && ((Object)target.transform.parent.parent).name == "Islands")
		{
			SelectingType = ObjectType.Island;
			OnSelectIsland?.Invoke(target);
		}
	}

	private void OnFingerTouchkAny()
	{
	}

	private void OnMouseSelecting(GameObject target)
	{
		if (((Object)target.transform.parent.parent).name == "Islands")
		{
			SelectingType = ObjectType.Island;
			if (Input.GetMouseButtonUp(0))
			{
				OnSelectIsland?.Invoke(target);
			}
		}
	}

	private void OnClickAny()
	{
	}
}
