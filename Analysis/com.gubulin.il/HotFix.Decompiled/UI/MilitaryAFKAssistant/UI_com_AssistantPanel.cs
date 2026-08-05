using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryAFKAssistant;

public class UI_com_AssistantPanel : GComponent
{
	public Controller stateController;

	public GImage n1;

	public GList LevelSelecters;

	public GImage n2;

	public GTextField n3;

	public GButton startBtn;

	public GButton pauseBtn;

	public GImage n7;

	public GTextField n8;

	public GGroup n9;

	public Transition t0;

	public const string URL = "ui://8x5gc8j2o7bu2";

	public static string Name = "UI_com_AssistantPanel";

	public static string GetURL()
	{
		return "ui://8x5gc8j2o7bu2";
	}

	public static UI_com_AssistantPanel CreateInstance()
	{
		return (UI_com_AssistantPanel)(object)UIPackage.CreateObject("MilitaryAFKAssistant", "com_AssistantPanel");
	}

	public static UI_com_AssistantPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AssistantPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8x5gc8j2o7bu2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		stateController = ((GComponent)this).GetController("stateController");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		LevelSelecters = (GList)((GComponent)this).GetChild("LevelSelecters");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://8x5gc8j2o7bu2".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		startBtn = (GButton)((GComponent)this).GetChild("startBtn");
		pauseBtn = (GButton)((GComponent)this).GetChild("pauseBtn");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id2 = "ui://8x5gc8j2o7bu2".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id2);
		n9 = (GGroup)((GComponent)this).GetChild("n9");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
