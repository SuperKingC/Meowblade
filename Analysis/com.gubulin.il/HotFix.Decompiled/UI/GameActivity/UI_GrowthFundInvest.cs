using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_GrowthFundInvest : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n11;

	public GImage n4;

	public GImage n10;

	public GImage note;

	public const string URL = "ui://29q48tv6iw2l7h";

	public static string Name = "UI_GrowthFundInvest";

	public static string GetURL()
	{
		return "ui://29q48tv6iw2l7h";
	}

	public static UI_GrowthFundInvest CreateInstance()
	{
		return (UI_GrowthFundInvest)(object)UIPackage.CreateObject("GameActivity", "GrowthFundInvest");
	}

	public static UI_GrowthFundInvest CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GrowthFundInvest).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6iw2l7h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
