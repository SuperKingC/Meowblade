using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UI.Tips;
using UnityEngine;

namespace Shift.Legion.GvGServer.Models.Map;

public class Ability
{
	private GDEAbilityData _abilityData;

	public string AbilityId { get; set; }

	public bool IsPercent { get; set; }

	public string N1 { get; set; }

	public GDEAbilityData AbilityData
	{
		get
		{
			if (_abilityData == null)
			{
				_abilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(AbilityId);
			}
			return _abilityData;
		}
	}

	public int GetAbilityLevel()
	{
		if (AbilityData == null)
		{
			return 0;
		}
		if (!IsPercent)
		{
			return int.Parse(N1) / 10000;
		}
		return 0;
	}

	public string GetAbilityLevelAndName()
	{
		if (AbilityData == null)
		{
			return "";
		}
		string arg = AbilityData.Name.Replace("压制效果：", "");
		return $"{arg}Lv{GetAbilityLevel()}";
	}

	public string GetAbilityIcon()
	{
		if (AbilityData == null)
		{
			return "";
		}
		return "ui://LordOfDreams/" + AbilityData.Icon;
	}

	public void ShowSkillDetailPopup()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		if (AbilityData != null)
		{
			Vector2 val = default(Vector2);
			((Vector2)(ref val))._002Ector(960f, 665f);
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("Pos", val);
			dictionary.Add("Data", AbilityData);
			dictionary.Add("Limit", 0);
			dictionary.Add("State", true);
			dictionary.Add("GList", null);
			dictionary.Add("SkillIconUrl", GetAbilityIcon());
			dictionary.Add("Level", GetAbilityLevel());
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, dictionary);
		}
	}
}
