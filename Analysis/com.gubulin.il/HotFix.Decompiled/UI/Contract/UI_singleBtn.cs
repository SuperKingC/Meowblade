using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_singleBtn : GButton
{
	public Controller button;

	public GLoader icon;

	public GImage n8;

	public const string URL = "ui://avplaivdo5ta2w";

	public static string Name = "UI_singleBtn";

	public static string GetURL()
	{
		return "ui://avplaivdo5ta2w";
	}

	public static UI_singleBtn CreateInstance()
	{
		return (UI_singleBtn)(object)UIPackage.CreateObject("Contract", "singleBtn");
	}

	public static UI_singleBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_singleBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdo5ta2w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
