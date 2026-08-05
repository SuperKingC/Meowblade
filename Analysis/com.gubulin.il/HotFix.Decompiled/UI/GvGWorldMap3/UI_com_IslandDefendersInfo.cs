using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_IslandDefendersInfo : GComponent
{
	public Controller Obedience;

	public Controller isInfinity;

	public GImage n10;

	public GImage n12;

	public GLoader ObedienceIcon;

	public GTextField ObedienceValue;

	public GTextField Obedience0;

	public GTextField Obedience1;

	public GTextField ObedienceValue1;

	public GGroup n5;

	public GTextField n6;

	public GImage n7;

	public GTextField n8;

	public GTextField Defenders;

	public const string URL = "ui://4eq8fgd2hgjzfa";

	public static string Name = "UI_com_IslandDefendersInfo";

	private Coroutine _updateRemainTime;

	public static string GetURL()
	{
		return "ui://4eq8fgd2hgjzfa";
	}

	public static UI_com_IslandDefendersInfo CreateInstance()
	{
		return (UI_com_IslandDefendersInfo)(object)UIPackage.CreateObject("GvGWorldMap3", "com_IslandDefendersInfo");
	}

	public static UI_com_IslandDefendersInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandDefendersInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2hgjzfa", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Obedience = ((GComponent)this).GetController("Obedience");
		isInfinity = ((GComponent)this).GetController("isInfinity");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		ObedienceIcon = (GLoader)((GComponent)this).GetChild("ObedienceIcon");
		ObedienceValue = (GTextField)((GComponent)this).GetChild("ObedienceValue");
		Obedience0 = (GTextField)((GComponent)this).GetChild("Obedience0");
		string id = "ui://4eq8fgd2hgjzfa".Replace("ui://", "") + "-" + ((GObject)Obedience0).id;
		((GObject)Obedience0).text = LanguagesManager.GetDesc(id);
		Obedience1 = (GTextField)((GComponent)this).GetChild("Obedience1");
		string id2 = "ui://4eq8fgd2hgjzfa".Replace("ui://", "") + "-" + ((GObject)Obedience1).id;
		((GObject)Obedience1).text = LanguagesManager.GetDesc(id2);
		ObedienceValue1 = (GTextField)((GComponent)this).GetChild("ObedienceValue1");
		string id3 = "ui://4eq8fgd2hgjzfa".Replace("ui://", "") + "-" + ((GObject)ObedienceValue1).id;
		((GObject)ObedienceValue1).text = LanguagesManager.GetDesc(id3);
		n5 = (GGroup)((GComponent)this).GetChild("n5");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id4 = "ui://4eq8fgd2hgjzfa".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id4);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id5 = "ui://4eq8fgd2hgjzfa".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id5);
		Defenders = (GTextField)((GComponent)this).GetChild("Defenders");
	}

	public void OnRender(IslandStateModel islandState, List<UI_main_IslandDefenders.UnitInfo> unitInfos)
	{
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		((GObject)Defenders).text = islandState.DetailInfo.DefenderNum().ToString();
		int obedience = islandState.Obedience();
		if (_updateRemainTime != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_updateRemainTime);
			_updateRemainTime = null;
		}
		bool flag = islandState.ObedienceValue < 0f || (double)islandState.ObedienceValue > TimeSpan.FromDays(30.0).TotalSeconds;
		isInfinity.SetSelectedIndex(flag ? 1 : 0);
		if (flag)
		{
			((GObject)ObedienceValue).text = "∞";
		}
		else
		{
			double serverRealtimeSeconds = GameController.Instance.GetServerRealtimeSeconds();
			double endTimeStamp = serverRealtimeSeconds + (double)islandState.ObedienceValue;
			_updateRemainTime = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(UpdateRemainTime(endTimeStamp));
		}
		if (islandState.CampId == 0)
		{
			Obedience.selectedIndex = 2;
		}
		else
		{
			Obedience.selectedIndex = ((obedience == 0) ? 1 : 0);
		}
		((GObject)this).onClick.Set(new EventCallback0(CheckDefendersInfo));
		void CheckDefendersInfo()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_IslandDefenders.Name, new Dictionary<string, object>
			{
				{ "UnitInfos", unitInfos },
				{ "IslandId", islandState.IslandId },
				{ "RebornTimestamp", islandState.NPCRebornTimestamp },
				{ "RecoveryTimestamp", islandState.NPCRecoveryTimestamp },
				{ "ObedienceValue", obedience }
			});
		}
	}

	private IEnumerator UpdateRemainTime(double endTimeStamp)
	{
		WaitForSeconds wait = new WaitForSeconds(1f);
		while (!((GObject)this).isDisposed)
		{
			double remainTime = endTimeStamp - GameController.Instance.GetServerRealtimeSeconds();
			((GObject)ObedienceValue).text = UiHelper.ParseTime((int)remainTime);
			yield return wait;
		}
		_updateRemainTime = null;
	}
}
