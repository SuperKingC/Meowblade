using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_AmplifierSlot : GComponent
{
	public Controller IsCriticalStrike;

	public Controller Quatity;

	public Controller Count;

	public Controller TalentSrc;

	public GImage n158;

	public GImage n159;

	public GGroup Critical_light;

	public GComponent AmplifierIcon;

	public GComponent AffectedRange;

	public GImage n162;

	public GTextField AmpCount;

	public GImage n157;

	public GLoader TalentSrcIcon;

	public Transition t0;

	public Transition Appear;

	public const string URL = "ui://tt2iq07opg601z";

	public static string Name = "UI_com_AmplifierSlot";

	public static string GetURL()
	{
		return "ui://tt2iq07opg601z";
	}

	public static UI_com_AmplifierSlot CreateInstance()
	{
		return (UI_com_AmplifierSlot)(object)UIPackage.CreateObject("GvGExchange3", "com_AmplifierSlot");
	}

	public static UI_com_AmplifierSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AmplifierSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07opg601z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsCriticalStrike = ((GComponent)this).GetController("IsCriticalStrike");
		Quatity = ((GComponent)this).GetController("Quatity");
		Count = ((GComponent)this).GetController("Count");
		TalentSrc = ((GComponent)this).GetController("TalentSrc");
		n158 = (GImage)((GComponent)this).GetChild("n158");
		n159 = (GImage)((GComponent)this).GetChild("n159");
		Critical_light = (GGroup)((GComponent)this).GetChild("Critical_light");
		AmplifierIcon = (GComponent)((GComponent)this).GetChild("AmplifierIcon");
		AffectedRange = (GComponent)((GComponent)this).GetChild("AffectedRange");
		n162 = (GImage)((GComponent)this).GetChild("n162");
		AmpCount = (GTextField)((GComponent)this).GetChild("AmpCount");
		n157 = (GImage)((GComponent)this).GetChild("n157");
		TalentSrcIcon = (GLoader)((GComponent)this).GetChild("TalentSrcIcon");
		t0 = ((GComponent)this).GetTransition("t0");
		Appear = ((GComponent)this).GetTransition("Appear");
	}
}
