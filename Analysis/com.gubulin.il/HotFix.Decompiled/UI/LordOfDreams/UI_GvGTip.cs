using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.LordOfDreams;

public class UI_GvGTip : GComponent, IUiController
{
	public Controller Type;

	public UI_GVGTip_Damageinfo Damage;

	public UI_GVGTip_Armyinfo SoldierCost;

	public Transition S1;

	public Transition B1;

	public const string URL = "ui://0i520nzmmdrxobt";

	public static string Name = "UI_GvGTip";

	public static string GetURL()
	{
		return "ui://0i520nzmmdrxobt";
	}

	public static UI_GvGTip CreateInstance()
	{
		return (UI_GvGTip)(object)UIPackage.CreateObject("LordOfDreams", "GvGTip");
	}

	public static UI_GvGTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmmdrxobt", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Damage = (UI_GVGTip_Damageinfo)(object)((GComponent)this).GetChild("Damage");
		SoldierCost = (UI_GVGTip_Armyinfo)(object)((GComponent)this).GetChild("SoldierCost");
		S1 = ((GComponent)this).GetTransition("S1");
		B1 = ((GComponent)this).GetTransition("B1");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("Content", out var value))
		{
			((GObject)Damage.Content).text = value.ToString();
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
		if (parameters.TryGetValue("Type", out var value4))
		{
			Type.selectedIndex = (int)value4;
			if (Type.selectedIndex == 1)
			{
				S1.Play(new PlayCompleteCallback(End));
			}
			else if (Type.selectedIndex == 2)
			{
				B1.Play(new PlayCompleteCallback(End));
			}
			else
			{
				End();
			}
		}
		else
		{
			End();
		}
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
