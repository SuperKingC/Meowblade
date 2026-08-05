using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ShowLevelChange : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n3;

	public GRichTextField LastLevel;

	public GImage n4;

	public GRichTextField CurrentLevel;

	public const string URL = "ui://82mo10n5e1phdir";

	public static string Name = "UI_ShowLevelChange";

	public static string GetURL()
	{
		return "ui://82mo10n5e1phdir";
	}

	public static UI_ShowLevelChange CreateInstance()
	{
		return (UI_ShowLevelChange)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ShowLevelChange");
	}

	public static UI_ShowLevelChange CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ShowLevelChange).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5e1phdir", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Type = ((GComponent)this).GetController("Type");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		LastLevel = (GRichTextField)((GComponent)this).GetChild("LastLevel");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		CurrentLevel = (GRichTextField)((GComponent)this).GetChild("CurrentLevel");
	}
}
