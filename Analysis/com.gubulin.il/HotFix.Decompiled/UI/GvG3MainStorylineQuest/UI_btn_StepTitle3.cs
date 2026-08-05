using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_btn_StepTitle3 : GButton
{
	public Controller button;

	public Controller Status;

	public GImage n3;

	public GImage n8;

	public GImage n4;

	public GLoader n7;

	public GImage n9;

	public GImage n10;

	public GGroup n11;

	public GImage n5;

	public GImage n6;

	public GGroup n12;

	public Transition t0;

	public const string URL = "ui://249h3k3diemus5t";

	public static string Name = "UI_btn_StepTitle3";

	public static string GetURL()
	{
		return "ui://249h3k3diemus5t";
	}

	public static UI_btn_StepTitle3 CreateInstance()
	{
		return (UI_btn_StepTitle3)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "btn_StepTitle3");
	}

	public static UI_btn_StepTitle3 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_StepTitle3).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3diemus5t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n7 = (GLoader)((GComponent)this).GetChild("n7");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GGroup)((GComponent)this).GetChild("n11");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n12 = (GGroup)((GComponent)this).GetChild("n12");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
