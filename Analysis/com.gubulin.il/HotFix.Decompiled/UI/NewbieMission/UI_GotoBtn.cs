using FairyGUI;
using FairyGUI.Utils;

namespace UI.NewbieMission;

public class UI_GotoBtn : GButton
{
	public Controller button;

	public Controller goNow;

	public GGraph n8;

	public GLoader icon;

	public GLoader GotoBtnIcon;

	public GLoader ClameBtnIcon;

	public const string URL = "ui://kmmwvr7cu32t9";

	public static string Name = "UI_GotoBtn";

	public static string GetURL()
	{
		return "ui://kmmwvr7cu32t9";
	}

	public static UI_GotoBtn CreateInstance()
	{
		return (UI_GotoBtn)(object)UIPackage.CreateObject("NewbieMission", "GotoBtn");
	}

	public static UI_GotoBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GotoBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kmmwvr7cu32t9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		goNow = ((GComponent)this).GetController("goNow");
		n8 = (GGraph)((GComponent)this).GetChild("n8");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		GotoBtnIcon = (GLoader)((GComponent)this).GetChild("GotoBtnIcon");
		ClameBtnIcon = (GLoader)((GComponent)this).GetChild("ClameBtnIcon");
	}
}
