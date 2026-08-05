using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_RankTopThree : GComponent
{
	public Controller RankType;

	public GImage n17;

	public GImage n14;

	public GImage n15;

	public GGroup n22;

	public GImage n18;

	public GImage n19;

	public GImage n20;

	public GGroup n21;

	public GImage n23;

	public GImage n24;

	public GImage n25;

	public GGroup n26;

	public GList NoList;

	public const string URL = "ui://82mo10n5pmghdnj";

	public static string Name = "UI_RankTopThree";

	public static string GetURL()
	{
		return "ui://82mo10n5pmghdnj";
	}

	public static UI_RankTopThree CreateInstance()
	{
		return (UI_RankTopThree)(object)UIPackage.CreateObject("PvpSelectSoldiers", "RankTopThree");
	}

	public static UI_RankTopThree CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RankTopThree).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5pmghdnj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RankType = ((GComponent)this).GetController("RankType");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n22 = (GGroup)((GComponent)this).GetChild("n22");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n21 = (GGroup)((GComponent)this).GetChild("n21");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GGroup)((GComponent)this).GetChild("n26");
		NoList = (GList)((GComponent)this).GetChild("NoList");
	}
}
