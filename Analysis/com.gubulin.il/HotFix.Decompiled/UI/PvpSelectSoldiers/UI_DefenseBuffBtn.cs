using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_DefenseBuffBtn : GButton
{
	public Controller button;

	public GImage n4;

	public const string URL = "ui://82mo10n5lt7m8v";

	public static string Name = "UI_DefenseBuffBtn";

	public static string GetURL()
	{
		return "ui://82mo10n5lt7m8v";
	}

	public static UI_DefenseBuffBtn CreateInstance()
	{
		return (UI_DefenseBuffBtn)(object)UIPackage.CreateObject("PvpSelectSoldiers", "DefenseBuffBtn");
	}

	public static UI_DefenseBuffBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DefenseBuffBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5lt7m8v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
