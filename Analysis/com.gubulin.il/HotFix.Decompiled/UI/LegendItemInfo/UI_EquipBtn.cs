using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemInfo;

public class UI_EquipBtn : GButton
{
	public Controller button;

	public GImage background;

	public GTextField Title;

	public const string URL = "ui://lzvt5p2vx6d3d";

	public static string Name = "UI_EquipBtn";

	public static string GetURL()
	{
		return "ui://lzvt5p2vx6d3d";
	}

	public static UI_EquipBtn CreateInstance()
	{
		return (UI_EquipBtn)(object)UIPackage.CreateObject("LegendItemInfo", "EquipBtn");
	}

	public static UI_EquipBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EquipBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lzvt5p2vx6d3d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://lzvt5p2vx6d3d".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
	}
}
