using UnityEngine;

public class CameraBindingHandler
{
	private CameraBinding _CameraBinding;

	public Transform TargetTransform
	{
		get
		{
			return _CameraBinding.BindingTransform;
		}
		set
		{
			_CameraBinding.ChangeTargetTransform(value);
		}
	}

	public Vector3 TargetPos
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return _CameraBinding.BindingPos;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			_CameraBinding.ChangeTargetPos(value);
		}
	}

	public float TargetSize
	{
		get
		{
			return _CameraBinding.TargetSize;
		}
		set
		{
			_CameraBinding.TargetSize = value;
		}
	}

	public float CatchupTime
	{
		get
		{
			return _CameraBinding.CatchupTime;
		}
		set
		{
			_CameraBinding.CatchupTime = value;
		}
	}

	public bool NotifyOnceOnCatchup
	{
		get
		{
			return _CameraBinding.NotifyOnceOnCatchup;
		}
		set
		{
			_CameraBinding.NotifyOnceOnCatchup = value;
		}
	}

	public CameraBinding CameraBinding => _CameraBinding;

	public CameraBindingHandler(CameraBinding cameraBinding)
	{
		_CameraBinding = cameraBinding;
	}
}
