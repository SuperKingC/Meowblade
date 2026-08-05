using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_TotalRankFilter : GButton
{
	public Controller button;

	public GGraph n7;

	public GImage n3;

	public GImage bg;

	public GImage n5;

	public const string URL = "ui://82mo10n5lt7m9t";

	public static string Name = "UI_TotalRankFilter";

	public static string GetURL()
	{
		return "ui://82mo10n5lt7m9t";
	}

	public static UI_TotalRankFilter CreateInstance()
	{
		return (UI_TotalRankFilter)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TotalRankFilter");
	}

	public static UI_TotalRankFilter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TotalRankFilter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5lt7m9t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GGraph)((GComponent)this).GetChild("n7");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
