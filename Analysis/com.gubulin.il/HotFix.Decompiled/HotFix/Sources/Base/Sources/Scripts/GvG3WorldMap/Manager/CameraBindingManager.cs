using System;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;

public class CameraBindingManager
{
	private enum TargetType
	{
		Position,
		Transform
	}

	private TargetType Type;

	private Transform TargetTransform;

	private Vector3 TargetPos;

	private float TargetCamSize;

	private Vector3 ViewCenterPos;

	private float OriginalSize;

	private Vector3 OriginalPos;

	private Quaternion OriginalRotation;

	private Camera Camera;

	private Transform CameraContainer;

	public Vector3 CamOffset;

	private int OnChangeCamPos_CallFrame;

	private int OnChangeSize_CallFrame;

	private Action MovingStrategyUpdate;

	private Action CamSizeStrategyUpdate;

	private float CatchupTime = 0f;

	private float CamSizeCatchupTime = 0f;

	private float MoveLerpSpeed = 5f;

	private float CamSizeLerpSpeed = 5f;

	private float ConstantSpeed;

	private float ConstantCamSizeSpeed;

	private bool IsPause = false;

	public Action<float> OnChangeSize;

	public Action<Vector3> OnChangeCamPos;

	public Action OnReachTarget;

	public Action OnReachTargetSize;

	private float PauseSize;

	private Vector3 PausePos;

	public Camera MainCamera => Camera;

	public Vector3 ViewCenter => ViewCenterPos;

	public float CamSize
	{
		get
		{
			if (CamSizeStrategyUpdate == new Action(UpdateToCamSize_FollowImmediately))
			{
				return TargetCamSize;
			}
			return Camera.orthographicSize;
		}
		set
		{
			SetTargetCamSize(value);
			CamSize_FollowImmediately();
		}
	}

	public CameraBindingManager()
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		Camera = ((Component)Camera.main).GetComponent<Camera>();
		CameraContainer = ((Component)Camera).transform.parent;
		CamOffset = Vector3.zero;
		Type = TargetType.Position;
	}

	public void Init(Vector3 viewCenterPos, float camHeight, Quaternion rotation)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		float num = camHeight / (float)Math.Tan(Math.PI / 4.0);
		CamOffset = new Vector3(0f, camHeight, 0f - num);
		ViewCenterPos = viewCenterPos;
		OriginalSize = Camera.orthographicSize;
		OriginalPos = ((Component)CameraContainer).transform.position;
		OriginalRotation = ((Component)Camera).transform.rotation;
		((Component)CameraContainer).transform.position = ViewCenterPos + CamOffset;
		((Component)Camera).transform.rotation = rotation;
		IsPause = false;
	}

	public void OnDestroy()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		Camera.orthographicSize = OriginalSize;
		((Component)CameraContainer).transform.position = OriginalPos;
		((Component)Camera).transform.rotation = OriginalRotation;
		OnChangeSize = null;
		OnChangeCamPos = null;
		OnReachTarget = null;
		OnReachTargetSize = null;
	}

	public void Pause()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		if (!IsPause)
		{
			IsPause = true;
			PauseSize = Camera.orthographicSize;
			PausePos = ((Component)CameraContainer).transform.position;
		}
	}

	public void Resume()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		if (IsPause)
		{
			IsPause = false;
			Camera.orthographicSize = PauseSize;
			((Component)CameraContainer).transform.position = PausePos;
		}
	}

	public void SetTarget(Vector3 target)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		TargetPos = target;
		Type = TargetType.Position;
	}

	public void SetTarget(Transform target)
	{
		TargetTransform = target;
		Type = TargetType.Transform;
	}

	public void SetTargetCamSize(float target)
	{
		TargetCamSize = target;
	}

	public void FollowImmediately()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if (Type == TargetType.Position)
		{
			ViewCenterPos = TargetPos;
			((Component)CameraContainer).transform.position = ViewCenterPos + CamOffset;
			MovingStrategyUpdate = null;
		}
		else if (Type == TargetType.Transform)
		{
			MovingStrategyUpdate = UpdateFollowTrans_FollowImmediately;
			MovingStrategyUpdate();
		}
		OnChangeCamPos_CallFrame = Time.frameCount;
	}

	public void CatchupInTime(float catchupTime)
	{
		CatchupTime = catchupTime;
		if (Type == TargetType.Position)
		{
			MovingStrategyUpdate = UpdateMoveToPos_CatchupInTime;
		}
		else if (Type == TargetType.Transform)
		{
			MovingStrategyUpdate = UpdateFollowTrans_CatchupInTime;
		}
	}

	public void FollowAndSlowdown(float lerpSpeed)
	{
		MoveLerpSpeed = lerpSpeed;
		if (Type == TargetType.Position)
		{
			MovingStrategyUpdate = UpdateMoveToPos_Slowdown;
		}
		else if (Type == TargetType.Transform)
		{
			MovingStrategyUpdate = UpdateFollowTrans_Slowdown;
		}
	}

	public void FollowAtConstantSpeed(float constantSpeed)
	{
		ConstantSpeed = constantSpeed;
		if (Type == TargetType.Position)
		{
			MovingStrategyUpdate = UpdateMoveToPos_ConstantSpeed;
		}
		else if (Type == TargetType.Transform)
		{
			MovingStrategyUpdate = UpdateFollowTrans_ConstantSpeed;
		}
	}

	public void CamSize_FollowImmediately()
	{
		CamSizeStrategyUpdate = UpdateToCamSize_FollowImmediately;
	}

	public void CamSize_CatchupInTime(float catchupTime)
	{
		CamSizeCatchupTime = catchupTime;
		CamSizeStrategyUpdate = UpdateToCamSize_CatchupInTime;
	}

	public void CamSize_FollowAndSlowdown(float lerpSpeed)
	{
		CamSizeLerpSpeed = lerpSpeed;
		CamSizeStrategyUpdate = UpdateToCamSize_Slowdown;
	}

	public void CamSize_FollowAtConstantSpeed(float constantSpeed)
	{
		ConstantCamSizeSpeed = constantSpeed;
		CamSizeStrategyUpdate = UpdateToCamSize_ConstantSpeed;
	}

	public void Update()
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		MovingStrategyUpdate?.Invoke();
		CamSizeStrategyUpdate?.Invoke();
		if (OnChangeCamPos != null && (OnChangeCamPos_CallFrame == Time.frameCount || MovingStrategyUpdate != null))
		{
			OnChangeCamPos(((Component)CameraContainer).transform.position);
		}
		if (OnChangeSize != null && (OnChangeSize_CallFrame == Time.frameCount || CamSizeStrategyUpdate != null))
		{
			OnChangeSize(Camera.orthographicSize);
		}
	}

	public void StopFollowingTarget()
	{
		MovingStrategyUpdate = null;
	}

	public bool IsCurrentTarget(Transform target)
	{
		return Type == TargetType.Transform && (Object)(object)TargetTransform == (Object)(object)target;
	}

	private void UpdateFollowTrans_FollowImmediately()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)TargetTransform == (Object)null))
		{
			ViewCenterPos = TargetTransform.position;
			((Component)CameraContainer).transform.position = ViewCenterPos + CamOffset;
		}
	}

	private void UpdateFollowTrans_CatchupInTime()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		if (CatchupTime > 0f)
		{
			Vector3 val = TargetTransform.position - ViewCenterPos;
			float catchupTime = CatchupTime;
			float deltaTime = Time.deltaTime;
			Vector3 val2 = -6f / Mathf.Pow(catchupTime, 3f) * val;
			Vector3 val3 = (0f - catchupTime) * val2;
			Vector3 val4 = (0f - catchupTime) / 2f * val3;
			Vector3 val5 = Mathf.Pow(deltaTime, 3f) / 6f * val2 + Mathf.Pow(deltaTime, 2f) / 2f * val3 + deltaTime * val4;
			ViewCenterPos -= new Vector3(val5.x, val5.y, val5.z);
			((Component)CameraContainer).transform.position = ViewCenterPos + CamOffset;
			CatchupTime -= deltaTime;
		}
		else
		{
			FollowImmediately();
			ReachTrans();
		}
	}

	private void UpdateFollowTrans_Slowdown()
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		ViewCenterPos = Vector3.Lerp(ViewCenterPos, TargetTransform.position, Time.deltaTime * MoveLerpSpeed);
		((Component)CameraContainer).transform.position = ViewCenterPos + CamOffset;
		if (OnReachTarget != null)
		{
			Vector3 val = TargetTransform.position - ViewCenterPos;
			if (((Vector3)(ref val)).sqrMagnitude < 0.005f)
			{
				ReachTrans();
			}
		}
	}

	private void UpdateFollowTrans_ConstantSpeed()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = TargetTransform.position - ViewCenterPos;
		float magnitude = ((Vector3)(ref val)).magnitude;
		float num = ConstantSpeed * Time.deltaTime;
		if (magnitude <= num || magnitude == 0f)
		{
			ViewCenterPos = TargetTransform.position;
			((Component)CameraContainer).transform.position = ViewCenterPos + CamOffset;
			ReachTrans();
		}
		else
		{
			Vector3 val2 = val / magnitude;
			ViewCenterPos += val2 * num;
			((Component)CameraContainer).transform.position = ViewCenterPos + CamOffset;
		}
	}

	private void ReachTrans()
	{
		OnChangeCamPos_CallFrame = Time.frameCount;
		OnReachTarget?.Invoke();
		OnReachTarget = null;
	}

	private void UpdateMoveToPos_CatchupInTime()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		if (CatchupTime > 0f)
		{
			Vector3 val = TargetPos - ViewCenterPos;
			float num = CatchupTime + Mathf.Epsilon;
			float deltaTime = Time.deltaTime;
			Vector3 val2 = -6f / Mathf.Pow(num, 3f) * val;
			Vector3 val3 = (0f - num) * val2;
			Vector3 val4 = (0f - num) / 2f * val3;
			Vector3 val5 = Mathf.Pow(deltaTime, 3f) / 6f * val2 + Mathf.Pow(deltaTime, 2f) / 2f * val3 + deltaTime * val4;
			ViewCenterPos -= new Vector3(val5.x, val5.y, val5.z);
			((Component)CameraContainer).transform.position = ViewCenterPos + CamOffset;
			CatchupTime -= deltaTime;
		}
		else
		{
			FollowImmediately();
			ReachPos();
		}
	}

	private void UpdateMoveToPos_Slowdown()
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		ViewCenterPos = Vector3.Lerp(ViewCenterPos, TargetPos, Time.deltaTime * MoveLerpSpeed);
		((Component)CameraContainer).transform.position = ViewCenterPos + CamOffset;
		if (OnReachTarget != null)
		{
			Vector3 val = TargetTransform.position - ViewCenterPos;
			if (((Vector3)(ref val)).sqrMagnitude < 0.005f)
			{
				ReachPos();
			}
		}
	}

	private void UpdateMoveToPos_ConstantSpeed()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = TargetPos - ViewCenterPos;
		float magnitude = ((Vector3)(ref val)).magnitude;
		float num = ConstantCamSizeSpeed * Time.deltaTime;
		if (magnitude <= num || magnitude == 0f)
		{
			ViewCenterPos = TargetPos;
			((Component)CameraContainer).transform.position = ViewCenterPos + CamOffset;
			ReachPos();
		}
		else
		{
			Vector3 val2 = val / magnitude;
			ViewCenterPos += val2 * num;
			((Component)CameraContainer).transform.position = ViewCenterPos + CamOffset;
		}
	}

	private void ReachPos()
	{
		OnChangeCamPos_CallFrame = Time.frameCount;
		OnReachTarget?.Invoke();
		OnReachTarget = null;
		MovingStrategyUpdate = null;
	}

	private void UpdateToCamSize_FollowImmediately()
	{
		Camera.orthographicSize = TargetCamSize;
		CamSizeStrategyUpdate = null;
		ReachCamSize();
	}

	private void UpdateToCamSize_CatchupInTime()
	{
		if (CamSizeCatchupTime > 0f)
		{
			float num = TargetCamSize - Camera.orthographicSize;
			float num2 = CamSizeCatchupTime + Mathf.Epsilon;
			float deltaTime = Time.deltaTime;
			float num3 = -6f / Mathf.Pow(num2, 3f) * num;
			float num4 = (0f - num2) * num3;
			float num5 = (0f - num2) / 2f * num4;
			float num6 = Mathf.Pow(deltaTime, 3f) / 6f * num3 + Mathf.Pow(deltaTime, 2f) / 2f * num4 + deltaTime * num5;
			Camera camera = Camera;
			camera.orthographicSize -= num6;
			CamSizeCatchupTime -= deltaTime;
		}
		if (CamSizeCatchupTime <= 0f)
		{
			Camera.orthographicSize = TargetCamSize;
			ReachCamSize();
		}
	}

	private void UpdateToCamSize_Slowdown()
	{
		Camera.orthographicSize = Mathf.Lerp(Camera.orthographicSize, TargetCamSize, Time.deltaTime * CamSizeLerpSpeed);
		if (OnReachTargetSize != null && TargetCamSize - Camera.orthographicSize < 0.005f)
		{
			ReachCamSize();
		}
	}

	private void UpdateToCamSize_ConstantSpeed()
	{
		float num = TargetCamSize - Camera.orthographicSize;
		float num2 = ConstantSpeed * Time.deltaTime;
		if (num <= num2 || num == 0f)
		{
			Camera.orthographicSize = TargetCamSize;
			ReachCamSize();
		}
		else
		{
			Camera camera = Camera;
			camera.orthographicSize += num2;
		}
	}

	private void ReachCamSize()
	{
		OnChangeSize_CallFrame = Time.frameCount;
		OnReachTargetSize?.Invoke();
		OnReachTargetSize = null;
		CamSizeStrategyUpdate = null;
	}
}
