using FairyGUI;
using FairyGUI.Utils;

namespace UI.Dungeons;

public class UI_acceptanceBtn : GButton
{
	public Controller button;

	public GImage n6;

	public GImage title;

	public const string URL = "ui://e3srq2g9kpclg";

	public static string Name = "UI_acceptanceBtn";

	public static string GetURL()
	{
		return "ui://e3srq2g9kpclg";
	}

	public static UI_acceptanceBtn CreateInstance()
	{
		return (UI_acceptanceBtn)(object)UIPackage.CreateObject("Dungeons", "acceptanceBtn");
	}

	public static UI_acceptanceBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_acceptanceBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3srq2g9kpclg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
		title = (GImage)((GComponent)this).GetChild("title");
	}
}
