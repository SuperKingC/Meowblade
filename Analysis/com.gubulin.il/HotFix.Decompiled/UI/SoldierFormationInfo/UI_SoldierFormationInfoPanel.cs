using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.SoldierFormationInfo;

public class UI_SoldierFormationInfoPanel : GComponent, IUiController
{
	public GGraph mask;

	public UI_SoldierFormationInfo Dialog;

	public const string URL = "ui://r7u60zpohc8r0";

	public static string Name = "UI_SoldierFormationInfoPanel";

	private Vector2 dialogPos;

	private Soldier curSoldier;

	public static string GetURL()
	{
		return "ui://r7u60zpohc8r0";
	}

	public static UI_SoldierFormationInfoPanel CreateInstance()
	{
		return (UI_SoldierFormationInfoPanel)(object)UIPackage.CreateObject("SoldierFormationInfo", "SoldierFormationInfoPanel");
	}

	public static UI_SoldierFormationInfoPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierFormationInfoPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r7u60zpohc8r0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_SoldierFormationInfo)(object)((GComponent)this).GetChild("Dialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("DialogPos", out var value))
		{
			dialogPos = (Vector2)value;
		}
		else
		{
			dialogPos = Vector2.zero;
		}
		((GObject)this).sortingOrder = 1;
		((GObject)Dialog).SetScale(0.25f, 0.25f);
		((GObject)Dialog).SetXY(dialogPos.x, dialogPos.y);
		((GObject)Dialog).alpha = 0f;
		SetMainInfo();
	}

	public void OnShow()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		((GObject)Dialog).TweenFade(1f, 0.1f);
		((GObject)Dialog).TweenScale(Vector2.one, 0.33f).SetEase((EaseType)26);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)mask).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)mask).onClick.Remove(new EventCallback0(End));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void SetMainInfo()
	{
		((GObject)Dialog.title).text = LanguagesManager.GetDesc("CsharpCodeZhTcText195");
		List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
		List<KeyValuePair<int, int>> list2 = new List<KeyValuePair<int, int>>();
		int dungeonLevel = GameManagers.Instance.UserArchiveManager.GetDungeonLevel();
		if (dungeonLevel >= list.Count - 3)
		{
			list.RemoveRange(0, 16);
			list2 = list;
		}
		else
		{
			for (int i = dungeonLevel + 1; i < dungeonLevel + 5; i++)
			{
				list2.Add(new KeyValuePair<int, int>(i, list[i].Value));
			}
		}
		for (int j = 0; j < list2.Count; j++)
		{
			GTextField content = Dialog.content.content;
			((GObject)content).text = ((GObject)content).text + string.Format("[color=#D5BA7A]{0}{1}[/color] ", LanguagesManager.GetDesc("CsharpCodeZhTcText194"), list2[j].Key);
			if (list2[j].Key.ToString().Length == 1)
			{
				GTextField content2 = Dialog.content.content;
				((GObject)content2).text = ((GObject)content2).text + " ";
			}
			if (list2[j].Value.ToString().Length == 3)
			{
				GTextField content3 = Dialog.content.content;
				((GObject)content3).text = ((GObject)content3).text + " ";
			}
			GTextField content4 = Dialog.content.content;
			((GObject)content4).text = ((GObject)content4).text + $"[color=#AFF627]{list2[j].Value}[/color]";
			if (j != list2.Count - 1)
			{
				GTextField content5 = Dialog.content.content;
				((GObject)content5).text = ((GObject)content5).text + Environment.NewLine;
			}
		}
	}
}
