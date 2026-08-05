using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_com_AdvancedFlag : GComponent
{
	public Controller State;

	public GImage n155;

	public GImage n159;

	public GImage n153;

	public GImage n145;

	public GImage n146;

	public GImage n154;

	public GImage n157;

	public Transition t0;

	public const string URL = "ui://bfjg32hukcdl5x";

	public static string Name = "UI_com_AdvancedFlag";

	public static string GetURL()
	{
		return "ui://bfjg32hukcdl5x";
	}

	public static UI_com_AdvancedFlag CreateInstance()
	{
		return (UI_com_AdvancedFlag)(object)UIPackage.CreateObject("GvGBattlePass3", "com_AdvancedFlag");
	}

	public static UI_com_AdvancedFlag CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AdvancedFlag).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32hukcdl5x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		State = ((GComponent)this).GetController("State");
		n155 = (GImage)((GComponent)this).GetChild("n155");
		n159 = (GImage)((GComponent)this).GetChild("n159");
		n153 = (GImage)((GComponent)this).GetChild("n153");
		n145 = (GImage)((GComponent)this).GetChild("n145");
		n146 = (GImage)((GComponent)this).GetChild("n146");
		n154 = (GImage)((GComponent)this).GetChild("n154");
		n157 = (GImage)((GComponent)this).GetChild("n157");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
