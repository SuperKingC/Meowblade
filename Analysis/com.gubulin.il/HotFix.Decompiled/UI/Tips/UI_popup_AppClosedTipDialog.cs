using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_popup_AppClosedTipDialog : GComponent
{
	public GImage n32;

	public GImage n33;

	public GImage n39;

	public GImage n36;

	public GImage n34;

	public GImage n35;

	public GImage n38;

	public GImage n37;

	public Transition t0;

	public const string URL = "ui://47lbpgx9lunaj5ltgi";

	public static string Name = "UI_popup_AppClosedTipDialog";

	public static string GetURL()
	{
		return "ui://47lbpgx9lunaj5ltgi";
	}

	public static UI_popup_AppClosedTipDialog CreateInstance()
	{
		return (UI_popup_AppClosedTipDialog)(object)UIPackage.CreateObject("Tips", "popup_AppClosedTipDialog");
	}

	public static UI_popup_AppClosedTipDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_popup_AppClosedTipDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9lunaj5ltgi", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n35 = (GImage)((GComponent)this).GetChild("n35");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
