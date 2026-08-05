using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_CurAreaEarnings : GComponent
{
	public GImage n27;

	public GImage n28;

	public GImage n29;

	public GImage n30;

	public GTextField curAreaInstructions;

	public GList earningsList;

	public UI_EnterBattlefieldBtn EnterBattlefieldBtn;

	public GTextField percentage;

	public GImage n23;

	public GImage n19;

	public const string URL = "ui://c9n2h0ksee14j";

	public static string Name = "UI_CurAreaEarnings";

	public static string GetURL()
	{
		return "ui://c9n2h0ksee14j";
	}

	public static UI_CurAreaEarnings CreateInstance()
	{
		return (UI_CurAreaEarnings)(object)UIPackage.CreateObject("WorldMap", "CurAreaEarnings");
	}

	public static UI_CurAreaEarnings CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CurAreaEarnings).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksee14j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		curAreaInstructions = (GTextField)((GComponent)this).GetChild("curAreaInstructions");
		earningsList = (GList)((GComponent)this).GetChild("earningsList");
		EnterBattlefieldBtn = (UI_EnterBattlefieldBtn)(object)((GComponent)this).GetChild("EnterBattlefieldBtn");
		percentage = (GTextField)((GComponent)this).GetChild("percentage");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n19 = (GImage)((GComponent)this).GetChild("n19");
	}
}
