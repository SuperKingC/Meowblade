using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_SoulStoneIconBtn : GButton
{
	public Controller button;

	public Controller Status;

	public GImage back;

	public GLoader icon;

	public GImage n6;

	public GImage mask;

	public const string URL = "ui://kt6rg65obunlt86";

	public static string Name = "UI_SoulStoneIconBtn";

	public static string GetURL()
	{
		return "ui://kt6rg65obunlt86";
	}

	public static UI_SoulStoneIconBtn CreateInstance()
	{
		return (UI_SoulStoneIconBtn)(object)UIPackage.CreateObject("PublicResources", "SoulStoneIconBtn");
	}

	public static UI_SoulStoneIconBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoulStoneIconBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65obunlt86", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		back = (GImage)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		mask = (GImage)((GComponent)this).GetChild("mask");
	}
}
