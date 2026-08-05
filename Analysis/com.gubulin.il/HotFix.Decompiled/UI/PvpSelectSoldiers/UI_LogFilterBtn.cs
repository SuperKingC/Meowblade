using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_LogFilterBtn : GButton
{
	public Controller Type;

	public Controller Checked;

	public GImage bg;

	public GImage n8;

	public GImage n5;

	public GImage n6;

	public const string URL = "ui://82mo10n5t7wpdf0";

	public static string Name = "UI_LogFilterBtn";

	public static string GetURL()
	{
		return "ui://82mo10n5t7wpdf0";
	}

	public static UI_LogFilterBtn CreateInstance()
	{
		return (UI_LogFilterBtn)(object)UIPackage.CreateObject("PvpSelectSoldiers", "LogFilterBtn");
	}

	public static UI_LogFilterBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LogFilterBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5t7wpdf0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Type = ((GComponent)this).GetController("Type");
		Checked = ((GComponent)this).GetController("Checked");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
