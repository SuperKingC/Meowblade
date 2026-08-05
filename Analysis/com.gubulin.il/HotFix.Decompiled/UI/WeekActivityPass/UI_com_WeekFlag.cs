using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivityPass;

public class UI_com_WeekFlag : GComponent
{
	public Controller State;

	public GImage n160;

	public GImage n161;

	public GGroup n162;

	public GImage n153;

	public GImage n146;

	public GGroup n163;

	public GImage n155;

	public GImage n157;

	public GGroup n164;

	public Transition t0;

	public const string URL = "ui://11dkggb8nk8f24";

	public static string Name = "UI_com_WeekFlag";

	public static string GetURL()
	{
		return "ui://11dkggb8nk8f24";
	}

	public static UI_com_WeekFlag CreateInstance()
	{
		return (UI_com_WeekFlag)(object)UIPackage.CreateObject("WeekActivityPass", "com_WeekFlag");
	}

	public static UI_com_WeekFlag CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_WeekFlag).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8nk8f24", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n160 = (GImage)((GComponent)this).GetChild("n160");
		n161 = (GImage)((GComponent)this).GetChild("n161");
		n162 = (GGroup)((GComponent)this).GetChild("n162");
		n153 = (GImage)((GComponent)this).GetChild("n153");
		n146 = (GImage)((GComponent)this).GetChild("n146");
		n163 = (GGroup)((GComponent)this).GetChild("n163");
		n155 = (GImage)((GComponent)this).GetChild("n155");
		n157 = (GImage)((GComponent)this).GetChild("n157");
		n164 = (GGroup)((GComponent)this).GetChild("n164");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
