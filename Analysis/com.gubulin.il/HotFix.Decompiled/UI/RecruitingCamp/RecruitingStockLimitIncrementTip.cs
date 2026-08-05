using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using UnityEngine;

namespace UI.RecruitingCamp;

public class RecruitingStockLimitIncrementTip
{
	private const string TECH_LIMIT_INCREMENT_KEY = "H010";

	private const string PAYLOAD = "Payload";

	private const string S001 = "S001";

	private const string BASE_LIMIT_TEXT = "CsharpCodeZhTcText353";

	private const string SOLDIER_STOCK_LIMIT_TECH_INCREMENT = "Soldier_Stock_Limit_Tech_Increment";

	private const string SOLDIER_STOCK_LIMIT_I67508_INCREMENT = "Soldier_Stock_Limit_I67508_Increment";

	private const string SOLDIER_STOCK_LIMIT_INCREMENT_TIP = "Soldier_Stock_Limit_Increment_Tip";

	public void RenderLimitIncrementBtn(GObject obj, Vector2 tipPos)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		int increment;
		bool flag = HasTechIncrement(out increment);
		int increment2;
		bool flag2 = Has代理作战Increment(out increment2);
		obj.visible = flag || flag2;
		string text = string.Empty;
		if (flag)
		{
			text = text + "[" + "Soldier_Stock_Limit_Tech_Increment".ToLanguage() + "]";
		}
		if (flag2)
		{
			text = text + "[" + "Soldier_Stock_Limit_I67508_Increment".ToLanguage() + "]";
		}
		string text2 = "Soldier_Stock_Limit_Increment_Tip".ToLanguage().Format(new object[1] { text });
		int num = GameManagers.Instance.StockController.GetLimit("S001") + Mathf.Abs(GameManagers.Instance.UserArchiveManager.GetGvGShipPlanSoldiersStockLimitOccupiedValue());
		int number = num - increment - increment2;
		obj.data = new Dictionary<string, object>
		{
			{
				"Title",
				text2 + Environment.NewLine + "CsharpCodeZhTcText353".ToLanguage() + "：" + number.ShortNumberFormat()
			},
			{ "Pos", tipPos }
		};
	}

	private static bool HasTechIncrement(out int increment)
	{
		increment = 0;
		int techLevel = GameManagers.Instance.UserArchiveManager.GetTechLevel("H010");
		if (techLevel <= 0)
		{
			return false;
		}
		List<Modifier> techEffects = GameManagers.Instance.TechnologyManager.GetTechEffects("H010", techLevel);
		if (techEffects != null)
		{
			foreach (Modifier item in techEffects)
			{
				if (item.PayloadDictionary.TryGetValue("Payload", out var value))
				{
					increment = StockController.GetOriginLimit("S001") * (int.Parse(value.ToString().Replace("%", "")) / 100);
				}
			}
		}
		return true;
	}

	private static bool Has代理作战Increment(out int increment)
	{
		increment = GameManagers.Instance.UserArchiveManager.GetGvGSoldierStockLimit战时扩编Increment().LimitIncrease;
		return increment > 0;
	}
}
