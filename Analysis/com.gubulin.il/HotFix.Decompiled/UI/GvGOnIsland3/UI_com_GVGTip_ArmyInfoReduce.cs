using System;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_GVGTip_ArmyInfoReduce : GComponent
{
	public Controller Type;

	public GTextField n7;

	public GTextField Content0;

	public GImage n20;

	public GImage n4;

	public GTextField Content1;

	public GTextField n5;

	public GTextField Content2;

	public GImage n26;

	public GTextField Content4;

	public GImage n22;

	public GImage n19;

	public GTextField Content3;

	public const string URL = "ui://ebc4ciwrpwqhq5u";

	public static string Name = "UI_com_GVGTip_ArmyInfoReduce";

	public static string GetURL()
	{
		return "ui://ebc4ciwrpwqhq5u";
	}

	public static UI_com_GVGTip_ArmyInfoReduce CreateInstance()
	{
		return (UI_com_GVGTip_ArmyInfoReduce)(object)UIPackage.CreateObject("GvGOnIsland3", "com_GVGTip_ArmyInfoReduce");
	}

	public static UI_com_GVGTip_ArmyInfoReduce CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GVGTip_ArmyInfoReduce).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrpwqhq5u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://ebc4ciwrpwqhq5u".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		Content0 = (GTextField)((GComponent)this).GetChild("Content0");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		Content1 = (GTextField)((GComponent)this).GetChild("Content1");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id2 = "ui://ebc4ciwrpwqhq5u".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id2);
		Content2 = (GTextField)((GComponent)this).GetChild("Content2");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		Content4 = (GTextField)((GComponent)this).GetChild("Content4");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		Content3 = (GTextField)((GComponent)this).GetChild("Content3");
	}

	public void SetContent(string content)
	{
		GObject val = ((GComponent)this).GetChild($"Content{Type.selectedIndex}") ?? throw new Exception($"UI_com_GVGTip_ArmyInfoReduce : Content{Type.selectedIndex} is non-existent");
		val.text = content;
	}
}
