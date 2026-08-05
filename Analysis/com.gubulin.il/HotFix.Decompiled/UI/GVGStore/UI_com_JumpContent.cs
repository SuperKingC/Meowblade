using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_JumpContent : GComponent
{
	public GGraph n2;

	public GLoader Icon;

	public GTextField Title;

	public GTextField Tip;

	public GTextField Num;

	public UI_btn_Jump Jump;

	public const string URL = "ui://fvc33k3gnf4q19";

	public static string Name = "UI_com_JumpContent";

	public static string GetURL()
	{
		return "ui://fvc33k3gnf4q19";
	}

	public static UI_com_JumpContent CreateInstance()
	{
		return (UI_com_JumpContent)(object)UIPackage.CreateObject("GVGStore", "com_JumpContent");
	}

	public static UI_com_JumpContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_JumpContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gnf4q19", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GGraph)((GComponent)this).GetChild("n2");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		Jump = (UI_btn_Jump)(object)((GComponent)this).GetChild("Jump");
	}
}
