using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.Guide;
using UI.GvGBrawlFight;
using UnityEngine;

namespace UI.Tips;

public class UI_SkillDetailPopup : GComponent, IUiController
{
	public class BrawlFightBuff
	{
		public string ItemId;

		public bool IsGroup;

		public string SkillName;

		public string Desc;

		public int Count;

		public int Limit;

		public bool State => Count > 0;
	}

	public GGraph mask;

	public UI_SkillDialog skillDialog;

	public Transition showDialog;

	public const string URL = "ui://47lbpgx9vphh13";

	public static string Name = "UI_SkillDetailPopup";

	public const string ShowPramBrawlFightBuff = "BrawlFightBuff";

	private Vec2 pos;

	private GDEAbilityData abilityData;

	private int limit;

	private bool isUnlock;

	private GList parentList;

	private bool isShow;

	private FakeSoldier specialityDta;

	private string skillIconUrl;

	private List<string> textureList = new List<string>();

	private Dictionary<string, object> Parameters;

	private const int maxPanelX = 1465;

	public static string GetURL()
	{
		return "ui://47lbpgx9vphh13";
	}

	public static UI_SkillDetailPopup CreateInstance()
	{
		return (UI_SkillDetailPopup)(object)UIPackage.CreateObject("Tips", "SkillDetailPopup");
	}

	public static UI_SkillDetailPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SkillDetailPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9vphh13", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		skillDialog = (UI_SkillDialog)(object)((GComponent)this).GetChild("skillDialog");
		showDialog = ((GComponent)this).GetTransition("showDialog");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		Parameters = parameters;
		pos = new Vec2();
		if (parameters.ContainsKey("Pos"))
		{
			pos.x = ((Vector2)parameters["Pos"]).x;
			pos.y = ((Vector2)parameters["Pos"]).y;
			if (pos.x > 1465f)
			{
				pos.x = 1465f;
			}
			((GObject)this).SetXY(0f, 0f);
			((GObject)this).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
			if (parameters.TryGetValue("SortingOrder", out var value))
			{
				((GObject)this).sortingOrder = (int)value;
			}
			else
			{
				((GObject)this).sortingOrder = 1;
			}
		}
		else
		{
			End();
		}
		((GObject)this).sortingOrder = ((!parameters.TryGetValue("SortingOrder", out var value2)) ? 1 : ((int)value2));
		skillIconUrl = (parameters.TryGetValue("SkillIconUrl", out var value3) ? value3.ToString() : "");
		object value5;
		if (parameters.TryGetValue("SpecialityData", out var value4))
		{
			specialityDta = (FakeSoldier)value4;
			ShowSpecialityData();
		}
		else if (parameters.TryGetValue("BrawlFightBuff", out value5))
		{
			BrawlFightBuff buff = (BrawlFightBuff)value5;
			RenderBrawlFightBuff(buff);
		}
		else
		{
			abilityData = (GDEAbilityData)parameters["Data"];
			limit = (int)parameters["Limit"];
			isUnlock = (bool)parameters["State"];
			parentList = (GList)parameters["GList"];
			isShow = parameters.TryGetValue("IsShow", out var value6) && (bool)value6;
			ShowSkillData();
		}
		((GObject)(object)skillDialog).SetXY_WithinBounds(pos);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		((GObject)mask).onClick.Add(new EventCallback0(End));
		((GObject)skillDialog.Describe_t).onClickLink.Set(new EventCallback1(OnClickSkillEffectLink));
		SharedMessenger.AddListener<string>("CLOSE_UI", OnGuideEnd);
		((GObject)skillDialog.skillType).onClickLink.Set(new EventCallback1(OnClickSkillEffectLink));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)mask).onClick.Remove(new EventCallback0(End));
		((GObject)skillDialog.Describe_t).onClickLink.Clear();
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnGuideEnd);
		((GObject)skillDialog.skillType).onClickLink.Clear();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("SkillDetailPopup.Exit", mask);
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("SkillDetailPopup.Exit", mask);
	}

	public void End()
	{
		if (skillDialog.Type.selectedIndex == 0 && parentList != null)
		{
			parentList.selectedIndex = -1;
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	private void OnGuideEnd(string endPanelName)
	{
		if (endPanelName == UI_Guide.Name)
		{
			End();
		}
	}

	private void OnClickSkillEffectLink(EventContext e)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillEffectPanel.Name, new Dictionary<string, object> { 
		{
			"EffectKey",
			e.data.ToString()
		} });
	}

	private void ShowSpecialityData()
	{
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		skillDialog.Type.selectedIndex = 1;
		string currentLevelFeatureAbilityId = specialityDta.GetCurrentLevelFeatureAbilityId();
		int featureAbilityLevel = specialityDta.GetFeatureAbilityLevel();
		GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(currentLevelFeatureAbilityId);
		((GObject)skillDialog.Name_t).text = $"{gDEAbilityData.Name} LV{featureAbilityLevel}";
		((GObject)skillDialog.Describe_t).text = Singleton<AbilityDataManager>.Instance.GetDescription(gDEAbilityData.Key);
		skillDialog.SpecialityLevel.selectedIndex = featureAbilityLevel - 2;
		if (skillDialog.SpecialityLevel.selectedIndex == 1)
		{
			FGUIManager.Instance.AddTextSpecialEffects(skillDialog.specialitySfxBack, "ui_active_glow_orange", new Vector3(30f, 30f, 30f));
		}
		else if (skillDialog.SpecialityLevel.selectedIndex == 2)
		{
			FGUIManager.Instance.AddTextSpecialEffects(skillDialog.specialitySfxBack, "ui_active_glow_orange_2", new Vector3(30f, 30f, 30f));
		}
	}

	private string ParseDescription(string description)
	{
		foreach (Match item in Regex.Matches(description, "{\\$([a-zA-Z0-9_\\[\\]]+)(\\:?([a-zA-Z0-9_.\\[\\]]+))*?}"))
		{
			string value = item.Value;
			value = value.Replace("{$", "");
			value = value.Replace("}", "");
			string[] array = value.Split(new char[1] { ':' }, StringSplitOptions.RemoveEmptyEntries);
			string newValue = item.Value;
			if (array.Length == 2)
			{
				string key = array[0];
				if (Parameters.TryGetValue(key, out var value2))
				{
					float num = (float)value2;
					float num2 = NumericParser.Float(array[1]);
					newValue = $"{num * num2:0.#}";
				}
			}
			description = description.Replace(item.Value, newValue);
		}
		return description;
	}

	public static string ParseDescriptionStatic(string description, Dictionary<string, float> parameters)
	{
		foreach (Match item in Regex.Matches(description, "{\\$([a-zA-Z0-9_\\[\\]]+)(\\:?([a-zA-Z0-9_.\\[\\]]+))*?}"))
		{
			string value = item.Value;
			value = value.Replace("{$", "");
			value = value.Replace("}", "");
			string[] array = value.Split(new char[1] { ':' }, StringSplitOptions.RemoveEmptyEntries);
			string newValue = item.Value;
			if (array.Length == 2)
			{
				string key = array[0];
				if (parameters.TryGetValue(key, out var value2))
				{
					float num = float.Parse(array[1]);
					newValue = $"{value2 * num:0.#}";
				}
			}
			description = description.Replace(item.Value, newValue);
		}
		return description;
	}

	private void DisplaySeasonBuffSkill()
	{
		skillDialog.Type.selectedIndex = 2;
		((GObject)skillDialog.state).visible = false;
		string description = Singleton<AbilityDataManager>.Instance.GetDescription(abilityData.Key);
		description = ParseDescription(description);
		((GObject)skillDialog.Describe_t).text = description;
		((GObject)skillDialog.Name_t).text = Singleton<AbilityDataManager>.Instance.GetSpecialTagName(abilityData.Key);
		UI_com_buff buffIcon = skillDialog.buffIcon;
		((GObject)buffIcon.n103).visible = false;
		buffIcon.showMode.selectedIndex = 0;
		buffIcon.isDeactivate.selectedIndex = 0;
		buffIcon.itemIcon.url = abilityData.Icon.ToPublicResourcesRgbIcon();
	}

	private void ShowSkillData()
	{
		if (abilityData.Key.StartsWith("PVPS1rule"))
		{
			DisplaySeasonBuffSkill();
			return;
		}
		skillDialog.Type.selectedIndex = 0;
		string description = Singleton<AbilityDataManager>.Instance.GetDescription(abilityData.Key);
		description = ParseDescription(description);
		((GObject)skillDialog.Describe_t).text = description;
		((GObject)skillDialog.Name_t).text = Singleton<AbilityDataManager>.Instance.GetSpecialTagName(abilityData.Key);
		string text = "";
		switch (limit)
		{
		case 0:
			text = "[color=#86bb07]C[/color]";
			break;
		case 1:
			text = "[color=#86bb07]C+[/color]";
			break;
		case 2:
			text = "[color=#1573ff]B[/color]";
			break;
		case 3:
			text = "[color=#1573ff]B+[/color]";
			break;
		case 4:
			text = "[color=#c12eff]A[/color]";
			break;
		case 5:
			text = "[color=#c12eff]A+[/color]";
			break;
		case 6:
			text = "[color=#ff8d04]S[/color]";
			break;
		case 7:
			text = "[color=#ff8d04]S+[/color]";
			break;
		case 8:
			text = "[color=#ffd73b]M[/color]";
			break;
		}
		string text2 = "";
		if (!string.IsNullOrEmpty(skillIconUrl))
		{
			skillDialog.SkillIconLoader.url = skillIconUrl;
		}
		else
		{
			skillDialog.SkillIconLoader.LoadAbilityIcon(abilityData.Icon);
		}
		((GObject)skillDialog.skillType).text = ParseDescription(abilityData.AbilityCategory);
		if (abilityData.CoolingTime != "")
		{
			((GObject)skillDialog.coolingText).text = LanguagesManager.GetDesc("CsharpCodeZhTcText914") + ":" + abilityData.CoolingTime + LanguagesManager.GetDesc("CsharpCodeZhTcText92");
		}
		else
		{
			((GObject)skillDialog.coolingText).text = abilityData.CoolingTime;
		}
		if (isUnlock)
		{
			((GObject)skillDialog.state).visible = false;
			((GObject)skillDialog.SkillIconLoader).grayed = false;
			((GObject)skillDialog.frameImage).grayed = false;
			skillDialog.FloorLoader.url = "ui://PublicResources/avatar_default_bg_1";
		}
		else
		{
			if (limit != -1)
			{
				text2 = "[color=#FF0000]" + LanguagesManager.GetDesc("CsharpCodeZhTcText598") + ":" + LanguagesManager.GetDesc("CsharpCodeZhTcText599") + "[/color]" + text + "[color=#FF0000]" + LanguagesManager.GetDesc("CsharpCodeZhTcText600") + "[/color]";
			}
			((GObject)skillDialog.SkillIconLoader).grayed = true;
			((GObject)skillDialog.frameImage).grayed = true;
			((GObject)skillDialog.state).visible = true;
			skillDialog.FloorLoader.url = "ui://PublicResources/avatar_default_bg";
		}
		if (isShow)
		{
			if (string.IsNullOrWhiteSpace(text2))
			{
				text2 = "[color=#FF0000]" + LanguagesManager.GetDesc("CsharpCodeZhTcText598") + ":" + LanguagesManager.GetDesc("CsharpCodeZhTcText601") + "[/color]";
			}
			((GObject)skillDialog.state).visible = true;
			((GObject)skillDialog.SkillIconLoader).grayed = false;
			((GObject)skillDialog.frameImage).grayed = false;
		}
		if (!string.IsNullOrWhiteSpace(text2))
		{
			((GObject)skillDialog.Describe_t).text = ((GObject)skillDialog.Describe_t).text + Environment.NewLine + text2;
		}
	}

	private void RenderBrawlFightBuff(BrawlFightBuff buff)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(buff.ItemId);
		bool flag = UI.GvGBrawlFight.UI_com_buff.IsSpecialBuff(gDEItemData);
		skillDialog.Type.selectedIndex = (flag ? 2 : 3);
		((GObject)skillDialog.Name_t).text = buff.SkillName;
		((GObject)skillDialog.Describe_t).text = buff.Desc;
		((GObject)skillDialog.state).visible = !buff.State;
		if (flag)
		{
			UI_com_buff buffIcon = skillDialog.buffIcon;
			buffIcon.itemIcon.url = gDEItemData.Icon.ToPublicResourcesRgbIcon();
			buffIcon.isDeactivate.SetSelectedIndex((!buff.State) ? 1 : 0);
			((GObject)buffIcon.rewardCount).text = $"Lv{buff.Count}";
			buffIcon.effectRange.SetSelectedIndex(buff.IsGroup ? 1 : 0);
			buffIcon.showMode.SetSelectedIndex(1);
		}
		else
		{
			FGUIManager.Instance.SetItemIconAndFrame(skillDialog.buffIconScore, buff.ItemId);
		}
	}
}
