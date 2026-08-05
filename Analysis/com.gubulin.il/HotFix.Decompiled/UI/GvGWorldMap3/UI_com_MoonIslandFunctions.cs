using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_MoonIslandFunctions : GComponent
{
	public Controller Type;

	public GImage n6;

	public GTextField OccupyTip;

	public GList Functions;

	public GTextField n7;

	public const string URL = "ui://4eq8fgd2h4tpe4";

	public static string Name = "UI_com_MoonIslandFunctions";

	private Vector2 CurCardWorldPos;

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpe4";
	}

	public static UI_com_MoonIslandFunctions CreateInstance()
	{
		return (UI_com_MoonIslandFunctions)(object)UIPackage.CreateObject("GvGWorldMap3", "com_MoonIslandFunctions");
	}

	public static UI_com_MoonIslandFunctions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MoonIslandFunctions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpe4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		OccupyTip = (GTextField)((GComponent)this).GetChild("OccupyTip");
		Functions = (GList)((GComponent)this).GetChild("Functions");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://4eq8fgd2h4tpe4".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
	}

	public void OnLoad()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		CurCardWorldPos = ((GObject)((GObject)this).parent).LocalToRoot(Vector2.zero, GRoot.inst);
		Functions.onClickItem.Set(new EventCallback0(ShowFunctionDesc));
	}

	public void OnClose()
	{
		Functions.onClickItem.Clear();
	}

	public void OnRender(IslandStateModel islandState, IslandFuncStatus status)
	{
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		Type.SetSelectedIndex((int)status);
		LoadOccupyTip();
		Dictionary<string, List<string>> dictionary = "GvG3IslandFunctions".ToConfiguration<Dictionary<string, List<string>>>();
		List<string> list = dictionary[WorldMapConfigHelper.Configs.TryGetIsland(islandState.IslandId).Props.Type.ToString()];
		List<IslandFunction> funcList = new List<IslandFunction>(6);
		foreach (string item in list)
		{
			funcList.Add((IslandFunction)Enum.Parse(typeof(IslandFunction), item));
		}
		Functions.SetVirtual();
		Functions.itemProvider = new ListItemProvider(GetItemUrl);
		Functions.itemRenderer = new ListItemRenderer(ItemRender);
		Functions.numItems = funcList.Count;
		string GetItemUrl(int index)
		{
			return funcList[index] switch
			{
				IslandFunction.补充兵力 => "ui://4eq8fgd2h4tpe5", 
				IslandFunction.就近复活 => "ui://4eq8fgd2h4tpeb", 
				IslandFunction.拆建飞艇 => "ui://4eq8fgd2h4tped", 
				IslandFunction.补充食物 => "ui://4eq8fgd2h4tpea", 
				IslandFunction.调整配置 => "ui://4eq8fgd2h4tpe9", 
				IslandFunction.跃迁折扣 => "ui://4eq8fgd2h4tpec", 
				_ => string.Empty, 
			};
		}
		void ItemRender(int index, GObject obj)
		{
			if (!(obj is IIslandFunction islandFunction))
			{
				ILRuntimeDebug.LogError("UI_com_FlagshipIslandFunctions.ItemRender:obj is not IIslandFunction");
			}
			else
			{
				IslandFunction islandFunction2 = funcList[index];
				islandFunction.Render(status, islandFunction2.ToString());
			}
		}
		void LoadOccupyTip()
		{
			if (status == IslandFuncStatus.Preview)
			{
				GvGMode3CampProgressConfigModel gvGMode3CampProgressConfigModel = GvG3FlagShipMissionsConfigHelper.CampMainProgressConfig.Find((GvGMode3CampProgressConfigModel mission) => mission.CampControlMoonIsland == islandState.IslandId);
				if (gvGMode3CampProgressConfigModel != null)
				{
					int progress = gvGMode3CampProgressConfigModel.Progress;
					((GObject)OccupyTip).text = $"GvG3CaptureIslandProgress{progress}".ToLanguage();
				}
			}
		}
	}

	private void ShowFunctionDesc()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		int num = Functions.ItemIndexToChildIndex(Functions.selectedIndex);
		GObject childAt = ((GComponent)Functions).GetChildAt(num);
		IIslandFunction islandFunction = (IIslandFunction)childAt;
		if (islandFunction != null)
		{
			UI_com_FunctionDesc uI_com_FunctionDesc = FairyGUITip.ShowTip<UI_com_FunctionDesc>(childAt, eFairyGUITipDir.Up, null, new Rect(CurCardWorldPos.x, CurCardWorldPos.y, ((GObject)((GObject)this).parent).size.x, ((GObject)((GObject)this).parent).size.y));
			((GObject)uI_com_FunctionDesc.Desc).text = islandFunction.FunctionDesc;
		}
	}
}
