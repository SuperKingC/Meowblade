using System;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_GVGTip_ArmyIncrease : GComponent
{
	public Controller Type;

	public GImage n2;

	public GTextField Content0;

	public GTextField n6;

	public GTextField Content1;

	public GImage n13;

	public GImage n17;

	public GTextField Content3;

	public GImage n15;

	public GTextField n5;

	public GTextField Content2;

	public const string URL = "ui://ebc4ciwrdhf7q5w";

	public static string Name = "UI_com_GVGTip_ArmyIncrease";

	public static string GetURL()
	{
		return "ui://ebc4ciwrdhf7q5w";
	}

	public static UI_com_GVGTip_ArmyIncrease CreateInstance()
	{
		return (UI_com_GVGTip_ArmyIncrease)(object)UIPackage.CreateObject("GvGOnIsland3", "com_GVGTip_ArmyIncrease");
	}

	public static UI_com_GVGTip_ArmyIncrease CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GVGTip_ArmyIncrease).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrdhf7q5w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Content0 = (GTextField)((GComponent)this).GetChild("Content0");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://ebc4ciwrdhf7q5w".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		Content1 = (GTextField)((GComponent)this).GetChild("Content1");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		Content3 = (GTextField)((GComponent)this).GetChild("Content3");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id2 = "ui://ebc4ciwrdhf7q5w".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id2);
		Content2 = (GTextField)((GComponent)this).GetChild("Content2");
	}

	public void SetContent(string content)
	{
		string text = $"Content{Type.selectedIndex}";
		GObject val = ((GComponent)this).GetChild(text) ?? throw new Exception("UI_com_GVGTip_ArmyIncrease : " + text + " is non-existent");
		val.text = content;
	}
}
