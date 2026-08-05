using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_btn_AccelerateClaim : GButton
{
	public Controller AccStatus;

	public GImage n153;

	public GImage n161;

	public GLoader n154;

	public GTextField Qty;

	public GImage n156;

	public GImage n160;

	public GImage n162;

	public Transition t0;

	public const string URL = "ui://th385mttn6wlo8y";

	public static string Name = "UI_btn_AccelerateClaim";

	public static string GetURL()
	{
		return "ui://th385mttn6wlo8y";
	}

	public static UI_btn_AccelerateClaim CreateInstance()
	{
		return (UI_btn_AccelerateClaim)(object)UIPackage.CreateObject("GvGOuterTech", "btn_AccelerateClaim");
	}

	public static UI_btn_AccelerateClaim CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_AccelerateClaim).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttn6wlo8y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		AccStatus = ((GComponent)this).GetController("AccStatus");
		n153 = (GImage)((GComponent)this).GetChild("n153");
		n161 = (GImage)((GComponent)this).GetChild("n161");
		n154 = (GLoader)((GComponent)this).GetChild("n154");
		Qty = (GTextField)((GComponent)this).GetChild("Qty");
		n156 = (GImage)((GComponent)this).GetChild("n156");
		n160 = (GImage)((GComponent)this).GetChild("n160");
		n162 = (GImage)((GComponent)this).GetChild("n162");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
