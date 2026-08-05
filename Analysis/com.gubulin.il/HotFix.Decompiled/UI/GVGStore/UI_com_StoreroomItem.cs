using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Models;
using UnityEngine;

namespace UI.GVGStore;

public class UI_com_StoreroomItem : GComponent
{
	public Controller Type;

	public Controller Rarity;

	public GImage n2;

	public GMovieClip n4;

	public GLoader Icon;

	public GImage n1;

	public GGraph RareSfxWrapper;

	public Transition ShowIcon;

	public const string URL = "ui://fvc33k3gv6i7p";

	public static string Name = "UI_com_StoreroomItem";

	public static string GetURL()
	{
		return "ui://fvc33k3gv6i7p";
	}

	public static UI_com_StoreroomItem CreateInstance()
	{
		return (UI_com_StoreroomItem)(object)UIPackage.CreateObject("GVGStore", "com_StoreroomItem");
	}

	public static UI_com_StoreroomItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_StoreroomItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gv6i7p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Rarity = ((GComponent)this).GetController("Rarity");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n4 = (GMovieClip)((GComponent)this).GetChild("n4");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		RareSfxWrapper = (GGraph)((GComponent)this).GetChild("RareSfxWrapper");
		ShowIcon = ((GComponent)this).GetTransition("ShowIcon");
	}

	public void RenderRarity(string itemId)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		bool flag = Item.Rarity(itemId) >= 5;
		Rarity.SetSelectedIndex(flag ? 1 : 0);
		if (flag)
		{
			FGUIManager.Instance.AddTextSpecialEffects(RareSfxWrapper, "ui_gvgshop_card_idle", Vector3.one * 100f);
		}
	}
}
