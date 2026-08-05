using FairyGUI;
using FairyGUI.Utils;

namespace UI.Dungeons;

public class UI_upgradeBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GImage title;

	public GImage redPoint;

	public const string URL = "ui://e3srq2g9kpclf";

	public static string Name = "UI_upgradeBtn";

	public static string GetURL()
	{
		return "ui://e3srq2g9kpclf";
	}

	public static UI_upgradeBtn CreateInstance()
	{
		return (UI_upgradeBtn)(object)UIPackage.CreateObject("Dungeons", "upgradeBtn");
	}

	public static UI_upgradeBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_upgradeBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3srq2g9kpclf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		title = (GImage)((GComponent)this).GetChild("title");
		redPoint = (GImage)((GComponent)this).GetChild("redPoint");
	}
}
