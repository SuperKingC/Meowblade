using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_FlagshipFunctions : GComponent
{
	public GImage n4;

	public GTextField n3;

	public GList Functions;

	public const string URL = "ui://4eq8fgd2h4tpew";

	public static string Name = "UI_com_FlagshipFunctions";

	private Vector2 CurCardWorldPos;

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpew";
	}

	public static UI_com_FlagshipFunctions CreateInstance()
	{
		return (UI_com_FlagshipFunctions)(object)UIPackage.CreateObject("GvGWorldMap3", "com_FlagshipFunctions");
	}

	public static UI_com_FlagshipFunctions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FlagshipFunctions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpew", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://4eq8fgd2h4tpew".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		Functions = (GList)((GComponent)this).GetChild("Functions");
	}

	public void OnLoad()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		CurCardWorldPos = ((GObject)((GObject)this).parent).LocalToRoot(Vector2.zero, GRoot.inst);
		Functions.SetVirtual();
		Functions.onClickItem.Set(new EventCallback0(ShowFunctionDesc));
	}

	public void OnClose()
	{
		Functions.onClickItem.Clear();
	}

	public void OnRender(FlagshipFuncStatus status)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		List<string> list = "GvG3FlagshipFunctions".ToConfiguration<List<string>>();
		List<FlagshipFunction> funcList = new List<FlagshipFunction>(4);
		foreach (string item in list)
		{
			funcList.Add((FlagshipFunction)Enum.Parse(typeof(FlagshipFunction), item));
		}
		Functions.itemProvider = new ListItemProvider(GetItemUrl);
		Functions.itemRenderer = new ListItemRenderer(ItemRender);
		Functions.numItems = funcList.Count;
		string GetItemUrl(int index)
		{
			return funcList[index] switch
			{
				FlagshipFunction.交换所 => "ui://4eq8fgd2h4tpek", 
				FlagshipFunction.净化中心 => "ui://4eq8fgd2h4tpej", 
				FlagshipFunction.每日奖励 => "ui://4eq8fgd2h4tpeh", 
				FlagshipFunction.食物补给 => "ui://4eq8fgd2h4tpei", 
				_ => string.Empty, 
			};
		}
		void ItemRender(int index, GObject obj)
		{
			if (!(obj is IFlagshipFunction flagshipFunction))
			{
				ILRuntimeDebug.LogError("UI_com_FlagshipIslandFunctions.ItemRender:obj is not IIslandFunction");
			}
			else
			{
				FlagshipFunction flagshipFunction2 = funcList[index];
				if (flagshipFunction.FunctionBase == null)
				{
					flagshipFunction.FunctionBase = new GvG3FlagshipFunctionBase();
					flagshipFunction.FunctionBase.Init(status, obj.asButton, flagshipFunction2.ToString());
				}
				else
				{
					flagshipFunction.FunctionBase.Update(status, obj.asButton);
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
		IFlagshipFunction flagshipFunction = (IFlagshipFunction)childAt;
		if (flagshipFunction != null)
		{
			UI_com_FunctionDesc uI_com_FunctionDesc = FairyGUITip.ShowTip<UI_com_FunctionDesc>(childAt, eFairyGUITipDir.Up, null, new Rect(CurCardWorldPos.x, CurCardWorldPos.y, ((GObject)((GObject)this).parent).size.x, ((GObject)((GObject)this).parent).size.y));
			((GObject)uI_com_FunctionDesc.Desc).text = flagshipFunction.FunctionBase.Desc;
		}
	}
}
