using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_btn_StepRank : GButton
{
	public Controller IsMe;

	public Controller button;

	public GImage n0;

	public GImage n2;

	public GImage n1;

	public GGroup n3;

	public Transition t0;

	public const string URL = "ui://249h3k3dvihg1r";

	public static string Name = "UI_btn_StepRank";

	public static string GetURL()
	{
		return "ui://249h3k3dvihg1r";
	}

	public static UI_btn_StepRank CreateInstance()
	{
		return (UI_btn_StepRank)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "btn_StepRank");
	}

	public static UI_btn_StepRank CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_StepRank).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dvihg1r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		IsMe = ((GComponent)this).GetController("IsMe");
		button = ((GComponent)this).GetController("button");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n3 = (GGroup)((GComponent)this).GetChild("n3");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
