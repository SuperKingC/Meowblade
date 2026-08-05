using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_FlagshipMission : GComponent
{
	public Controller Type;

	public GImage n0;

	public GImage n6;

	public GImage n7;

	public GImage n8;

	public GTextField MissionName;

	public GTextField MissionTimes;

	public GList Requirements;

	public GList Bonus;

	public UI_btn_Submit Submit;

	public const string URL = "ui://tt2iq07odwxtf";

	public static string Name = "UI_com_FlagshipMission";

	public static string GetURL()
	{
		return "ui://tt2iq07odwxtf";
	}

	public static UI_com_FlagshipMission CreateInstance()
	{
		return (UI_com_FlagshipMission)(object)UIPackage.CreateObject("GvGExchange3", "com_FlagshipMission");
	}

	public static UI_com_FlagshipMission CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FlagshipMission).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odwxtf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		MissionName = (GTextField)((GComponent)this).GetChild("MissionName");
		MissionTimes = (GTextField)((GComponent)this).GetChild("MissionTimes");
		Requirements = (GList)((GComponent)this).GetChild("Requirements");
		Bonus = (GList)((GComponent)this).GetChild("Bonus");
		Submit = (UI_btn_Submit)(object)((GComponent)this).GetChild("Submit");
	}
}
