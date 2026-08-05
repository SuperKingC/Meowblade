using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_com_MissionSlotContent : GComponent
{
	public Controller ReceiveStatus;

	public GImage back;

	public GTextField Title;

	public GTextField Requirement;

	public GGroup n31;

	public GList BonusLineList;

	public UI_receiveBtn ClaimBtn;

	public GGraph mask;

	public const string URL = "ui://kozswd8hiqdsf33";

	public static string Name = "UI_com_MissionSlotContent";

	public static string GetURL()
	{
		return "ui://kozswd8hiqdsf33";
	}

	public static UI_com_MissionSlotContent CreateInstance()
	{
		return (UI_com_MissionSlotContent)(object)UIPackage.CreateObject("SpecialActivity", "com_MissionSlotContent");
	}

	public static UI_com_MissionSlotContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MissionSlotContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hiqdsf33", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ReceiveStatus = ((GComponent)this).GetController("ReceiveStatus");
		back = (GImage)((GComponent)this).GetChild("back");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		Requirement = (GTextField)((GComponent)this).GetChild("Requirement");
		n31 = (GGroup)((GComponent)this).GetChild("n31");
		BonusLineList = (GList)((GComponent)this).GetChild("BonusLineList");
		ClaimBtn = (UI_receiveBtn)(object)((GComponent)this).GetChild("ClaimBtn");
		mask = (GGraph)((GComponent)this).GetChild("mask");
	}
}
