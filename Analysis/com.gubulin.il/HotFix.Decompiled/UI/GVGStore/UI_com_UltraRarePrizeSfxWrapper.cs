using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.GVGStore;

public class UI_com_UltraRarePrizeSfxWrapper : GComponent
{
	public GGraph CardIdle;

	public GGraph CardAppear;

	public const string URL = "ui://fvc33k3ggctm2l";

	public static string Name = "UI_com_UltraRarePrizeSfxWrapper";

	public static string GetURL()
	{
		return "ui://fvc33k3ggctm2l";
	}

	public static UI_com_UltraRarePrizeSfxWrapper CreateInstance()
	{
		return (UI_com_UltraRarePrizeSfxWrapper)(object)UIPackage.CreateObject("GVGStore", "com_UltraRarePrizeSfxWrapper");
	}

	public static UI_com_UltraRarePrizeSfxWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_UltraRarePrizeSfxWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3ggctm2l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CardIdle = (GGraph)((GComponent)this).GetChild("CardIdle");
		CardAppear = (GGraph)((GComponent)this).GetChild("CardAppear");
	}

	public void PlayAppearParticleEffects()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.Instance.AddTextSpecialEffects(CardAppear, "ui_gvgshop_card_appear", Vector3.one * 100f, "Default", 0.5f, delegate(GameObject uiGvgshopCardAppear)
		{
			UiHelper.DestoryUiSfx(CardAppear, uiGvgshopCardAppear, 3f);
		});
	}

	public void PlayIdleParticleEffects()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		((GObject)CardIdle).displayObject.Dispose();
		FGUIManager.Instance.AddTextSpecialEffects(CardIdle, "ui_gvgshop_card_idle", Vector3.one * 100f);
	}
}
