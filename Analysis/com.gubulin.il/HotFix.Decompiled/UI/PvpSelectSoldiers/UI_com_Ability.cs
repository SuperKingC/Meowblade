using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_com_Ability : GComponent
{
	public Controller Type;

	public GLoader icon;

	public GImage n4;

	public GImage n5;

	public const string URL = "ui://82mo10n5hrekjdui";

	public static string Name = "UI_com_Ability";

	public static string GetURL()
	{
		return "ui://82mo10n5hrekjdui";
	}

	public static UI_com_Ability CreateInstance()
	{
		return (UI_com_Ability)(object)UIPackage.CreateObject("PvpSelectSoldiers", "com_Ability");
	}

	public static UI_com_Ability CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Ability).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5hrekjdui", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Type = ((GComponent)this).GetController("Type");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
