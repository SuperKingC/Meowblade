using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_btn_RequirementTasks : GButton
{
	public Controller button;

	public GImage n6;

	public GImage n7;

	public GImage n8;

	public GButton BoxIcon;

	public const string URL = "ui://tvr786zlpba44d";

	public static string Name = "UI_btn_RequirementTasks";

	public static string GetURL()
	{
		return "ui://tvr786zlpba44d";
	}

	public static UI_btn_RequirementTasks CreateInstance()
	{
		return (UI_btn_RequirementTasks)(object)UIPackage.CreateObject("GvGFlagship3", "btn_RequirementTasks");
	}

	public static UI_btn_RequirementTasks CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RequirementTasks).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zlpba44d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		BoxIcon = (GButton)((GComponent)this).GetChild("BoxIcon");
	}
}
