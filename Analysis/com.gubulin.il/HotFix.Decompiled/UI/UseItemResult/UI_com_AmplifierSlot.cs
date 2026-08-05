using FairyGUI;
using FairyGUI.Utils;

namespace UI.UseItemResult;

public class UI_com_AmplifierSlot : GComponent
{
	public Controller IsCriticalStrike;

	public Controller Quatity;

	public GImage n158;

	public GImage n159;

	public GGroup Critical_light;

	public GComponent AmplifierIcon;

	public GComponent AffectedRange;

	public GTextField Count;

	public GImage n157;

	public Transition t0;

	public Transition Appear;

	public const string URL = "ui://800w3r8rq2d9q";

	public static string Name = "UI_com_AmplifierSlot";

	public static string GetURL()
	{
		return "ui://800w3r8rq2d9q";
	}

	public static UI_com_AmplifierSlot CreateInstance()
	{
		return (UI_com_AmplifierSlot)(object)UIPackage.CreateObject("UseItemResult", "com_AmplifierSlot");
	}

	public static UI_com_AmplifierSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AmplifierSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rq2d9q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		IsCriticalStrike = ((GComponent)this).GetController("IsCriticalStrike");
		Quatity = ((GComponent)this).GetController("Quatity");
		n158 = (GImage)((GComponent)this).GetChild("n158");
		n159 = (GImage)((GComponent)this).GetChild("n159");
		Critical_light = (GGroup)((GComponent)this).GetChild("Critical_light");
		AmplifierIcon = (GComponent)((GComponent)this).GetChild("AmplifierIcon");
		AffectedRange = (GComponent)((GComponent)this).GetChild("AffectedRange");
		Count = (GTextField)((GComponent)this).GetChild("Count");
		n157 = (GImage)((GComponent)this).GetChild("n157");
		t0 = ((GComponent)this).GetTransition("t0");
		Appear = ((GComponent)this).GetTransition("Appear");
	}
}
