using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_com_TechSlotBigGroup : GComponent
{
	public Controller showArrow;

	public UI_com_02 stage1;

	public GImage n2;

	public UI_btn_TechSlotBig Card1;

	public UI_btn_TechSlotBig Card2;

	public const string URL = "ui://th385mttjt7wo8j";

	public static string Name = "UI_com_TechSlotBigGroup";

	public static string GetURL()
	{
		return "ui://th385mttjt7wo8j";
	}

	public static UI_com_TechSlotBigGroup CreateInstance()
	{
		return (UI_com_TechSlotBigGroup)(object)UIPackage.CreateObject("GvGOuterTech", "com_TechSlotBigGroup");
	}

	public static UI_com_TechSlotBigGroup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TechSlotBigGroup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttjt7wo8j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		showArrow = ((GComponent)this).GetController("showArrow");
		stage1 = (UI_com_02)(object)((GComponent)this).GetChild("stage1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Card1 = (UI_btn_TechSlotBig)(object)((GComponent)this).GetChild("Card1");
		Card2 = (UI_btn_TechSlotBig)(object)((GComponent)this).GetChild("Card2");
	}
}
