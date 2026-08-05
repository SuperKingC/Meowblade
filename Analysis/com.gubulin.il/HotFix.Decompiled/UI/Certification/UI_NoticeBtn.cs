using FairyGUI;
using FairyGUI.Utils;

namespace UI.Certification;

public class UI_NoticeBtn : GButton
{
	public Controller button;

	public GImage n4;

	public const string URL = "ui://56q48tcqm13tf";

	public static string Name = "UI_NoticeBtn";

	public static string GetURL()
	{
		return "ui://56q48tcqm13tf";
	}

	public static UI_NoticeBtn CreateInstance()
	{
		return (UI_NoticeBtn)(object)UIPackage.CreateObject("Certification", "NoticeBtn");
	}

	public static UI_NoticeBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_NoticeBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13tf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
