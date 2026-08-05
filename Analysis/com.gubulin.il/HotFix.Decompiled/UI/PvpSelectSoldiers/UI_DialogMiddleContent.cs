using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_DialogMiddleContent : GComponent
{
	public GButton ConsumptionItem;

	public const string URL = "ui://82mo10n5qxbi7s";

	public static string Name = "UI_DialogMiddleContent";

	private const string reqColor = "#F6E2B2";

	private GComponent reqDesc;

	private GTextField curPrice;

	public static string GetURL()
	{
		return "ui://82mo10n5qxbi7s";
	}

	public static UI_DialogMiddleContent CreateInstance()
	{
		return (UI_DialogMiddleContent)(object)UIPackage.CreateObject("PvpSelectSoldiers", "DialogMiddleContent");
	}

	public static UI_DialogMiddleContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DialogMiddleContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5qxbi7s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ConsumptionItem = (GButton)((GComponent)this).GetChild("ConsumptionItem");
	}

	public void DialogMiddleContentInit()
	{
		reqDesc = ((GComponent)ConsumptionItem).GetChild("reqDesc").asCom;
		curPrice = reqDesc.GetChild("curPrice").asTextField;
		GComponent asCom = reqDesc.GetChild("originPrice").asCom;
		((GObject)asCom).SetSize(0f, 0f);
		((GObject)asCom).visible = false;
	}

	public bool RenderDialogMiddleContent(Dictionary<string, int> _costDic)
	{
		if (_costDic == null)
		{
			((GObject)this).visible = false;
			return false;
		}
		((GObject)this).visible = true;
		string key = _costDic.First().Key;
		int value = _costDic.First().Value;
		FGUIManager.Instance.SetItemIconAndFrame(((GComponent)ConsumptionItem).GetChild("icon").asLoader, key);
		int stock = GameManagers.Instance.StockController.GetStock(key);
		string text = ((stock < value) ? "#DC143C" : "#F6E2B2");
		int number = stock;
		((GObject)curPrice).text = string.Format("[color={0}]{1}[/color][color={2}]/{3}[/color]", text, number.ShortNumberFormat(), "#F6E2B2", value);
		return stock >= value;
	}

	public bool RenderDialogMiddleContent(Dictionary<string, int> _costDic, float multiple)
	{
		if (_costDic == null)
		{
			((GObject)this).visible = false;
			return false;
		}
		((GObject)this).visible = true;
		string key = _costDic.First().Key;
		int num = Mathf.CeilToInt((float)_costDic.First().Value * multiple);
		FGUIManager.Instance.SetItemIconAndFrame(((GComponent)ConsumptionItem).GetChild("icon").asLoader, key);
		int stock = GameManagers.Instance.StockController.GetStock(key);
		string text = ((stock < num) ? "#DC143C" : "#F6E2B2");
		int number = stock;
		((GObject)curPrice).text = string.Format("[color={0}]{1}[/color][color={2}]/{3}[/color]", text, number.ShortNumberFormat(), "#F6E2B2", num);
		return stock >= num;
	}
}
