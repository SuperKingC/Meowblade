using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_btn_DailySupplyBos : GButton
{
	public Controller button;

	public Controller RedDot;

	public GImage n3;

	public GTextField n4;

	public GImage n5;

	public const string URL = "ui://pobej4q7uado3";

	public static string Name = "UI_btn_DailySupplyBos";

	public static string GetURL()
	{
		return "ui://pobej4q7uado3";
	}

	public static UI_btn_DailySupplyBos CreateInstance()
	{
		return (UI_btn_DailySupplyBos)(object)UIPackage.CreateObject("GvG3SupplyDepot", "btn_DailySupplyBos");
	}

	public static UI_btn_DailySupplyBos CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_DailySupplyBos).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7uado3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RedDot = ((GComponent)this).GetController("RedDot");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://pobej4q7uado3".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
