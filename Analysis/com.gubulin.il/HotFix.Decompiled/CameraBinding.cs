using System;
using UnityEngine;

public class CameraBinding : MonoBehaviour
{
	private enum BindingType
	{
		NO_BINDING,
		TRANSFORM,
		POSITION
	}

	public bool IsPause;

	private BindingType Type;

	public Transform BindingTransform;

	public Vector3 BindingPos;

	private Vector3 ViewCenterPos;

	public float TargetSize;

	private Camera _Camera;

	private Vector3 CamOffset;

	public float CatchupTime = 0f;

	public bool NotifyOnceOnCatchup = false;

	public Action<float> OnChangeSize = delegate
	{
	};

	public Action OnCatchup = delegate
	{
	};

	public Action<Vector3> OnChangePos = delegate
	{
	};

	private void Awake()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		Type = BindingType.NO_BINDING;
		BindingTransform = null;
		BindingPos = Vector3.zero;
		ViewCenterPos = Vector3.zero;
		TargetSize = 0f;
		CamOffset = Vector3.zero;
		_Camera = ((Component)Camera.main).GetComponent<Camera>();
		CatchupTime = 0f;
		IsPause = false;
	}

	public CameraBindingHandler BindTarget(Vector3 pos, float targetSize, float catchupTime)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		ChangeTargetPos(pos);
		TargetSize = targetSize;
		CatchupTime = catchupTime;
		return new CameraBindingHandler(this);
	}

	public CameraBindingHandler BindTarget(Transform trans, float targetSize, float catchupTime)
	{
		ChangeTargetTransform(trans);
		TargetSize = targetSize;
		CatchupTime = catchupTime;
		return new CameraBindingHandler(this);
	}

	public void ChangeTargetPos(Vector3 pos)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		Vector3 position = ((Component)this).transform.position;
		Type = BindingType.POSITION;
		BindingPos = new Vector3(pos.x, 0f, pos.z);
		InitCamOffset(pos);
		ViewCenterPos = position - CamOffset;
	}

	public void ChangeTargetTransform(Transform trans)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		Vector3 position = ((Component)this).transform.position;
		Type = BindingType.TRANSFORM;
		BindingTransform = trans;
		InitCamOffset(trans.position);
		ViewCenterPos = position - CamOffset;
	}

	public void InitCamOffset(Vector3 targetPos)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		Vector3 position = ((Component)this).transform.position;
		float num = position.y - targetPos.y;
		float num2 = num / (float)Math.Tan(Math.PI / 4.0);
		CamOffset = new Vector3(0f, position.y, 0f - num2);
	}

	private void Update()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		if (Type == BindingType.NO_BINDING || IsPause)
		{
			return;
		}
		if (Type == BindingType.TRANSFORM)
		{
			BindingPos = Vector3.zero;
			BindingPos.x = BindingTransform.position.x;
			BindingPos.z = BindingTransform.position.z;
		}
		float num = 0f;
		if ((double)CatchupTime > 0.1)
		{
			float num2 = CatchupTime + Mathf.Epsilon;
			float deltaTime = Time.deltaTime;
			Vector3 val = BindingPos - ViewCenterPos;
			Vector4 val2 = default(Vector4);
			((Vector4)(ref val2))._002Ector(val.x, val.y, val.z, TargetSize - _Camera.orthographicSize);
			Vector4 val3 = -6f / Mathf.Pow(num2, 3f) * val2;
			Vector4 val4 = (0f - num2) * val3;
			Vector4 val5 = (0f - num2) / 2f * val4;
			Vector4 val6 = Mathf.Pow(deltaTime, 3f) / 6f * val3 + Mathf.Pow(deltaTime, 2f) / 2f * val4 + deltaTime * val5;
			ViewCenterPos -= new Vector3(val6.x, val6.y, val6.z);
			num = _Camera.orthographicSize - val6.w;
			if (NotifyOnceOnCatchup)
			{
				Vector3 val7 = BindingPos - ViewCenterPos;
				if (((Vector3)(ref val7)).sqrMagnitude < 0.005f)
				{
					NotifyOnceOnCatchup = false;
					OnCatchup?.Invoke();
				}
			}
		}
		else
		{
			ViewCenterPos = BindingPos;
			num = TargetSize;
		}
		if (Math.Abs(num - _Camera.orthographicSize) > 0.001f)
		{
			_Camera.orthographicSize = num;
			OnChangeSize?.Invoke(_Camera.orthographicSize);
			SharedMessenger.Broadcast("ON_CAMERA_SIZE_CHANGE", _Camera.orthographicSize);
		}
		((Component)this).transform.position = ViewCenterPos + CamOffset;
		OnChangePos?.Invoke(((Component)this).transform.position);
	}

	internal void StopBinding()
	{
		((Behaviour)this).enabled = false;
		OnChangeSize = delegate
		{
		};
		OnCatchup = delegate
		{
		};
	}
}
