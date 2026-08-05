using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Shift.Legion.Common.Helpers;

public class TouchCreator
{
	private static BindingFlags flag;

	private static Dictionary<string, FieldInfo> fields;

	private object touch;

	public float deltaTime
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			Touch val = (Touch)touch;
			return ((Touch)(ref val)).deltaTime;
		}
		set
		{
			fields["m_TimeDelta"].SetValue(touch, value);
		}
	}

	public int tapCount
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			Touch val = (Touch)touch;
			return ((Touch)(ref val)).tapCount;
		}
		set
		{
			fields["m_TapCount"].SetValue(touch, value);
		}
	}

	public TouchPhase phase
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			Touch val = (Touch)touch;
			return ((Touch)(ref val)).phase;
		}
		set
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			fields["m_Phase"].SetValue(touch, value);
		}
	}

	public Vector2 deltaPosition
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			Touch val = (Touch)touch;
			return ((Touch)(ref val)).deltaPosition;
		}
		set
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			fields["m_PositionDelta"].SetValue(touch, value);
		}
	}

	public int fingerId
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			Touch val = (Touch)touch;
			return ((Touch)(ref val)).fingerId;
		}
		set
		{
			fields["m_FingerId"].SetValue(touch, value);
		}
	}

	public Vector2 position
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			Touch val = (Touch)touch;
			return ((Touch)(ref val)).position;
		}
		set
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			fields["m_Position"].SetValue(touch, value);
		}
	}

	public Vector2 rawPosition
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			Touch val = (Touch)touch;
			return ((Touch)(ref val)).rawPosition;
		}
		set
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			fields["m_RawPosition"].SetValue(touch, value);
		}
	}

	public Touch Create()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		return (Touch)touch;
	}

	public TouchCreator()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		touch = (object)default(Touch);
	}

	static TouchCreator()
	{
		flag = BindingFlags.Instance | BindingFlags.NonPublic;
		fields = new Dictionary<string, FieldInfo>();
		FieldInfo[] array = typeof(Touch).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
		foreach (FieldInfo fieldInfo in array)
		{
			fields.Add(fieldInfo.Name, fieldInfo);
		}
	}
}
