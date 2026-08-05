using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpGrade;

public class UI_Upgrade : GButton
{
	public Controller button;

	public Controller state;

	public GLoader backGround;

	public GLoader n7;

	public const string URL = "ui://lrjfe94hqp165";

	public static string Name = "UI_Upgrade";

	public static string GetURL()
	{
		return "ui://lrjfe94hqp165";
	}

	public static UI_Upgrade CreateInstance()
	{
		return (UI_Upgrade)(object)UIPackage.CreateObject("UpGrade", "Upgrade");
	}

	public static UI_Upgrade CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Upgrade).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hqp165", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		state = ((GComponent)this).GetController("state");
		backGround = (GLoader)((GComponent)this).GetChild("backGround");
		n7 = (GLoader)((GComponent)this).GetChild("n7");
	}
}
