using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_DailyMissionCom : GComponent
{
	public Controller state;

	public GImage n3;

	public GImage n14;

	public GTextField desc;

	public GTextField progressTip;

	public GGroup n6;

	public UI_DailyMissinItemBtn reward;

	public const string URL = "ui://k2sprg26ke8pai";

	public static string Name = "UI_DailyMissionCom";

	public static string GetURL()
	{
		return "ui://k2sprg26ke8pai";
	}

	public static UI_DailyMissionCom CreateInstance()
	{
		return (UI_DailyMissionCom)(object)UIPackage.CreateObject("IslandComeAgain", "DailyMissionCom");
	}

	public static UI_DailyMissionCom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DailyMissionCom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26ke8pai", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		state = ((GComponent)this).GetController("state");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		desc = (GTextField)((GComponent)this).GetChild("desc");
		string id = "ui://k2sprg26ke8pai".Replace("ui://", "") + "-" + ((GObject)desc).id;
		((GObject)desc).text = LanguagesManager.GetDesc(id);
		progressTip = (GTextField)((GComponent)this).GetChild("progressTip");
		string id2 = "ui://k2sprg26ke8pai".Replace("ui://", "") + "-" + ((GObject)progressTip).id;
		((GObject)progressTip).text = LanguagesManager.GetDesc(id2);
		n6 = (GGroup)((GComponent)this).GetChild("n6");
		reward = (UI_DailyMissinItemBtn)(object)((GComponent)this).GetChild("reward");
	}
}
