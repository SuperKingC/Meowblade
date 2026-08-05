using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_btn_StepTitle : GButton
{
	public Controller button;

	public Controller Status;

	public GImage n3;

	public GImage n8;

	public GImage n4;

	public GImage n5;

	public GImage n6;

	public GLoader n7;

	public Transition t0;

	public const string URL = "ui://249h3k3dqf7c1f";

	public static string Name = "UI_btn_StepTitle";

	public static string GetURL()
	{
		return "ui://249h3k3dqf7c1f";
	}

	public static UI_btn_StepTitle CreateInstance()
	{
		return (UI_btn_StepTitle)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "btn_StepTitle");
	}

	public static UI_btn_StepTitle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_StepTitle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dqf7c1f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GLoader)((GComponent)this).GetChild("n7");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
