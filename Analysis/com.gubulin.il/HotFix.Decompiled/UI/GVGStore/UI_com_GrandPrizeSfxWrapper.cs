using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.GVGStore;

public class UI_com_GrandPrizeSfxWrapper : GComponent
{
	public GGraph CardIdle1;

	public GGraph CardIdle2;

	public GGraph CardAppear;

	public const string URL = "ui://fvc33k3ggctm2k";

	public static string Name = "UI_com_GrandPrizeSfxWrapper";

	public static string GetURL()
	{
		return "ui://fvc33k3ggctm2k";
	}

	public static UI_com_GrandPrizeSfxWrapper CreateInstance()
	{
		return (UI_com_GrandPrizeSfxWrapper)(object)UIPackage.CreateObject("GVGStore", "com_GrandPrizeSfxWrapper");
	}

	public static UI_com_GrandPrizeSfxWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GrandPrizeSfxWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3ggctm2k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CardIdle1 = (GGraph)((GComponent)this).GetChild("CardIdle1");
		CardIdle2 = (GGraph)((GComponent)this).GetChild("CardIdle2");
		CardAppear = (GGraph)((GComponent)this).GetChild("CardAppear");
	}

	public void PlayAppearParticleEffects()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.Instance.AddTextSpecialEffects(CardAppear, "ui_gvgshop_card_appear2", Vector3.one * 100f, "Default", 0.5f, delegate(GameObject ui_gvgshop_card_appear)
		{
			UiHelper.DestoryUiSfx(CardAppear, ui_gvgshop_card_appear, 3f);
		});
	}

	public void PlayIdleParticleEffects()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		((GObject)CardIdle1).displayObject.Dispose();
		FGUIManager.Instance.AddTextSpecialEffects(CardIdle1, "ui_gvgshop_card_idle", Vector3.one * 100f);
	}
}
