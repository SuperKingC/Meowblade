using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.GvGWorldMap2;

public class UI_GvG2Tip : GComponent, IUiController
{
	public Controller Type;

	public UI_GVGTip_Armyinfo SoldierCost;

	public Transition B1;

	public const string URL = "ui://hd2s9kukzebn4s";

	public static string Name = "UI_GvG2Tip";

	public static string GetURL()
	{
		return "ui://hd2s9kukzebn4s";
	}

	public static UI_GvG2Tip CreateInstance()
	{
		return (UI_GvG2Tip)(object)UIPackage.CreateObject("GvGWorldMap2", "GvG2Tip");
	}

	public static UI_GvG2Tip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvG2Tip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukzebn4s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		SoldierCost = (UI_GVGTip_Armyinfo)(object)((GComponent)this).GetChild("SoldierCost");
		B1 = ((GComponent)this).GetTransition("B1");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("Content", out var value))
		{
			((GObject)SoldierCost.Content).text = value.ToString();
		}
		if (parameters.TryGetValue("Pos", out var value2))
		{
			Vector2 val = (Vector2)value2;
			((GObject)this).SetXY(val.x, val.y);
		}
		if (parameters.TryGetValue("Scale", out var value3))
		{
			((GObject)this).scaleX = (float)value3;
			((GObject)this).scaleY = (float)value3;
		}
		Type.selectedIndex = 1;
		B1.Play(new PlayCompleteCallback(End));
	}

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener("ON_GVG_TIP_CLEAR", End);
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener("ON_GVG_TIP_CLEAR", End);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
	}

	public void End()
	{
		if (!((GObject)this).isDisposed)
		{
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)this, true);
		}
	}
}
