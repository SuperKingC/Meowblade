using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_com_ContributionDetail : GComponent
{
	public GImage n3;

	public GImage n4;

	public GTextField Desc;

	public GLoader Icon;

	public GTextField Score;

	public const string URL = "ui://pobej4q7mo53k";

	public static string Name = "UI_com_ContributionDetail";

	public static string GetURL()
	{
		return "ui://pobej4q7mo53k";
	}

	public static UI_com_ContributionDetail CreateInstance()
	{
		return (UI_com_ContributionDetail)(object)UIPackage.CreateObject("GvG3SupplyDepot", "com_ContributionDetail");
	}

	public static UI_com_ContributionDetail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ContributionDetail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7mo53k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Score = (GTextField)((GComponent)this).GetChild("Score");
	}
}
