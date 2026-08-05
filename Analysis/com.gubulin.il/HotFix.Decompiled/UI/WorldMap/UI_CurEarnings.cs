using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_CurEarnings : GComponent
{
	public Controller Status;

	public GImage n8;

	public GImage n19;

	public GImage n18;

	public GImage n9;

	public GTextField conquestNum;

	public GList earningsList;

	public GImage n20;

	public GTextField n11;

	public UI_EarningsDetial detials;

	public UI_arrow2 arrow;

	public GTextField tip1;

	public const string URL = "ui://c9n2h0ksng4ra4";

	public static string Name = "UI_CurEarnings";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://c9n2h0ksng4ra4".Replace("ui://", ""), ((GObject)tip1).id, Status.selectedIndex);
		((GObject)tip1).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://c9n2h0ksng4ra4";
	}

	public static UI_CurEarnings CreateInstance()
	{
		return (UI_CurEarnings)(object)UIPackage.CreateObject("WorldMap", "CurEarnings");
	}

	public static UI_CurEarnings CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CurEarnings).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksng4ra4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		conquestNum = (GTextField)((GComponent)this).GetChild("conquestNum");
		string id = "ui://c9n2h0ksng4ra4".Replace("ui://", "") + "-" + ((GObject)conquestNum).id;
		((GObject)conquestNum).text = LanguagesManager.GetDesc(id);
		earningsList = (GList)((GComponent)this).GetChild("earningsList");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id2 = "ui://c9n2h0ksng4ra4".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id2);
		detials = (UI_EarningsDetial)(object)((GComponent)this).GetChild("detials");
		arrow = (UI_arrow2)(object)((GComponent)this).GetChild("arrow");
		tip1 = (GTextField)((GComponent)this).GetChild("tip1");
		string id3 = "ui://c9n2h0ksng4ra4".Replace("ui://", "") + "-" + ((GObject)tip1).id;
		((GObject)tip1).text = LanguagesManager.GetDesc(id3);
	}
}
