using System;
using System.Collections.Generic;
using Shift.Legion.Common.Services;
using UI.Tips;
using UnityEngine;

namespace FairyGUI;

public static class GButtonExtensions
{
	public static void SetPopupTips(this GButton btn, string tipText, Vector2 deltaPos = default(Vector2))
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		btn.SetPopupTips(() => tipText, deltaPos);
	}

	public static void SetPopupTips(this GButton btn, Func<string> realtimeText, Vector2 deltaPos = default(Vector2))
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		btn.SetPopupTipsToPos(realtimeText, absolutePos);
		Vector2 absolutePos()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			Vector2 val = ((GObject)btn).LocalToGlobal(Vector2.zero);
			val = ((GObject)GRoot.inst).GlobalToLocal(val);
			val.x += deltaPos.x;
			val.y += deltaPos.y;
			return val;
		}
	}

	public static void SetPopupTipsToPos(this GButton btn, Func<string> realtimeText, Func<Vector2> absolutePos)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		((GObject)btn).onClick.Set(new EventCallback1(onClickBtn));
		void onClickBtn(EventContext context)
		{
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ExclamationMarkPanel.Name, new Dictionary<string, object>
			{
				{
					"Title",
					realtimeText?.Invoke()
				},
				{
					"Pos",
					absolutePos?.Invoke()
				}
			});
			context.StopPropagation();
		}
	}
}
