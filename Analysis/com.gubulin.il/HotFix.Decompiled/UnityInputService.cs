using Shift.Legion.Common.Services;
using UnityEngine;

public sealed class UnityInputService : Service, IInputService, IService
{
	private float _holdingTimeLeft;

	private bool _isHoldingLeft;

	private bool _isReleasedLeft;

	private bool _isStartedHoldingLeft;

	private float _holdingTimeRight;

	private bool _isHoldingRight;

	private bool _isReleasedRight;

	private bool _isStartedHoldingRight;

	public UnityInputService(Contexts contexts)
		: base(contexts)
	{
	}

	public void Update(float delta)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		float num = (float)Screen.width / 2f;
		int num2 = 0;
		int num3 = 0;
		if (Input.GetMouseButton(0))
		{
			if (Input.mousePosition.x < num)
			{
				num2++;
			}
			else
			{
				num3++;
			}
		}
		if (Input.GetKey((KeyCode)32))
		{
			num2++;
		}
		if (Input.GetKey((KeyCode)119) || Input.GetKey((KeyCode)273))
		{
			num3++;
		}
		Touch[] touches = Input.touches;
		for (int i = 0; i < touches.Length; i++)
		{
			Touch val = touches[i];
			if (((Touch)(ref val)).position.x < num)
			{
				num2++;
			}
			else
			{
				num3++;
			}
		}
		if (num2 > 0)
		{
			if (_isHoldingLeft)
			{
				_holdingTimeLeft += delta;
				_isStartedHoldingLeft = false;
			}
			else
			{
				_holdingTimeLeft = 0f;
				_isStartedHoldingLeft = true;
			}
			_isHoldingLeft = true;
			_isReleasedLeft = false;
		}
		else if (_isHoldingLeft)
		{
			_isHoldingLeft = false;
			_isReleasedLeft = true;
		}
		else
		{
			_isReleasedLeft = false;
		}
		if (num3 > 0)
		{
			if (_isHoldingRight)
			{
				_holdingTimeRight += delta;
				_isStartedHoldingRight = false;
			}
			else
			{
				_holdingTimeRight = 0f;
				_isStartedHoldingRight = true;
			}
			_isHoldingRight = true;
			_isReleasedRight = false;
		}
		else if (_isHoldingRight)
		{
			_isHoldingRight = false;
			_isReleasedRight = true;
		}
		else
		{
			_isReleasedRight = false;
		}
	}

	public bool IsHoldingLeft()
	{
		return _isHoldingLeft;
	}

	public bool IsStartedHoldingLeft()
	{
		return _isStartedHoldingLeft;
	}

	public float HoldingTimeLeft()
	{
		return _holdingTimeLeft;
	}

	public bool IsReleasedLeft()
	{
		return _isReleasedLeft;
	}

	public bool IsHoldingRight()
	{
		return _isHoldingRight;
	}

	public bool IsStartedHoldingRight()
	{
		return _isStartedHoldingRight;
	}

	public float HoldingTimeRight()
	{
		return _holdingTimeRight;
	}

	public bool IsReleasedRight()
	{
		return _isReleasedRight;
	}
}
