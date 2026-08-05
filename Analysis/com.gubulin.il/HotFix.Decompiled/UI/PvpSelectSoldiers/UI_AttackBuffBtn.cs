using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_AttackBuffBtn : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://82mo10n5lt7m8u";

	public static string Name = "UI_AttackBuffBtn";

	public static string GetURL()
	{
		return "ui://82mo10n5lt7m8u";
	}

	public static UI_AttackBuffBtn CreateInstance()
	{
		return (UI_AttackBuffBtn)(object)UIPackage.CreateObject("PvpSelectSoldiers", "AttackBuffBtn");
	}

	public static UI_AttackBuffBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AttackBuffBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5lt7m8u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
