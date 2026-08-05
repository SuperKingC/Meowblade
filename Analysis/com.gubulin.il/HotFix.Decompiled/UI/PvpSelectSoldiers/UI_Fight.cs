using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_Fight : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n11;

	public GImage n9;

	public GImage n13;

	public const string URL = "ui://82mo10n5frebaz";

	public static string Name = "UI_Fight";

	public static string GetURL()
	{
		return "ui://82mo10n5frebaz";
	}

	public static UI_Fight CreateInstance()
	{
		return (UI_Fight)(object)UIPackage.CreateObject("PvpSelectSoldiers", "Fight");
	}

	public static UI_Fight CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Fight).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5frebaz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n13 = (GImage)((GComponent)this).GetChild("n13");
	}
}
