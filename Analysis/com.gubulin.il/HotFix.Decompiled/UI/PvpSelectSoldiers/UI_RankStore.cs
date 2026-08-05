using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_RankStore : GButton
{
	public Controller button;

	public Controller Type;

	public GGraph mask;

	public GImage n5;

	public GImage n6;

	public const string URL = "ui://82mo10n5x1jlddc";

	public static string Name = "UI_RankStore";

	public static string GetURL()
	{
		return "ui://82mo10n5x1jlddc";
	}

	public static UI_RankStore CreateInstance()
	{
		return (UI_RankStore)(object)UIPackage.CreateObject("PvpSelectSoldiers", "RankStore");
	}

	public static UI_RankStore CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RankStore).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5x1jlddc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		mask = (GGraph)((GComponent)this).GetChild("mask");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
