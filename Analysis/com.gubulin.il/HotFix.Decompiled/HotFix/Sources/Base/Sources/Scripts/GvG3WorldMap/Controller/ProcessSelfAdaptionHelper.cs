using System;
using System.Collections.Generic;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;

public static class ProcessSelfAdaptionHelper
{
	private static readonly Dictionary<ComponentAlignType, Action<SelfAdaption>> _processors = new Dictionary<ComponentAlignType, Action<SelfAdaption>>
	{
		{
			ComponentAlignType.Top,
			ProcessTop
		},
		{
			ComponentAlignType.Center,
			ProcessCenter
		}
	};

	public static void ProcessSelfAdaption(SelfAdaption selfAdaption)
	{
		if (selfAdaption != null)
		{
			if (!_processors.TryGetValue(selfAdaption.AlignType, out var value))
			{
				throw new Exception($"ProcessSelfAdaptionHelper AlignType={selfAdaption.AlignType} has not processor");
			}
			Action<SelfAdaption> action = value;
			action(selfAdaption);
		}
	}

	private static void ProcessTop(SelfAdaption selfAdaption)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		List<Transform> list = FilterActive(selfAdaption);
		if (list.Count > 0)
		{
			float num = selfAdaption.PerSize * selfAdaption.Scale;
			float num2 = num / 2f;
			for (int i = 0; i < list.Count; i++)
			{
				float num3 = num2 + (float)i * num;
				Vector3 localPosition = list[i].localPosition;
				localPosition.y = 0f - num3;
				list[i].localPosition = localPosition;
			}
		}
	}

	private static void ProcessCenter(SelfAdaption selfAdaption)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		List<Transform> list = FilterActive(selfAdaption);
		if (list.Count > 0)
		{
			float num = selfAdaption.PerSize * selfAdaption.Scale;
			float num2 = selfAdaption.AnchorPoint - (float)list.Count * num / 2f;
			float num3 = num / 2f;
			for (int i = 0; i < list.Count; i++)
			{
				float num4 = num3 + (float)i * num;
				Vector3 localPosition = list[i].localPosition;
				localPosition.x = num2 + num4;
				list[i].localPosition = localPosition;
			}
		}
	}

	private static List<Transform> FilterActive(SelfAdaption selfAdaption)
	{
		List<Transform> list = new List<Transform>(2);
		for (int i = 0; i < selfAdaption.Objects.Count; i++)
		{
			Transform val = selfAdaption.Objects[i]?.Value;
			if (val != null && selfAdaption.ObjectIsActive(((Component)val).gameObject))
			{
				list.Add(val);
			}
		}
		return list;
	}
}
