using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_com_ForgeResultDialog : GComponent
{
	public Controller Count;

	public GImage n191;

	public GImage n192;

	public UI_com_ForgeResultContent Content;

	public UI_btn_ConfirmBtn ConfirmBrn;

	public UI_com_ArrowTip ScrollTip;

	public GGraph ui_amplifier_forge_result_title;

	public Transition t0;

	public const string URL = "ui://fpjheycbnh8y11";

	public static string Name = "UI_com_ForgeResultDialog";

	public static string GetURL()
	{
		return "ui://fpjheycbnh8y11";
	}

	public static UI_com_ForgeResultDialog CreateInstance()
	{
		return (UI_com_ForgeResultDialog)(object)UIPackage.CreateObject("GvGAmplifierForge", "com_ForgeResultDialog");
	}

	public static UI_com_ForgeResultDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ForgeResultDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbnh8y11", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Count = ((GComponent)this).GetController("Count");
		n191 = (GImage)((GComponent)this).GetChild("n191");
		n192 = (GImage)((GComponent)this).GetChild("n192");
		Content = (UI_com_ForgeResultContent)(object)((GComponent)this).GetChild("Content");
		ConfirmBrn = (UI_btn_ConfirmBtn)(object)((GComponent)this).GetChild("ConfirmBrn");
		ScrollTip = (UI_com_ArrowTip)(object)((GComponent)this).GetChild("ScrollTip");
		ui_amplifier_forge_result_title = (GGraph)((GComponent)this).GetChild("ui_amplifier_forge_result_title");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
