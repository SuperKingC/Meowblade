using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsDraw;

public class UI_ScoreProgress : GProgressBar
{
	public Controller Tyep;

	public GImage n3;

	public UI_ScoreBar bar;

	public GGraph sfxBack;

	public UI_ScoreChest chest;

	public GTextField curNum;

	public GTextField totalNum;

	public GTextField split;

	public Transition BoxBreathing;

	public const string URL = "ui://xogvri2hkoygr";

	public static string Name = "UI_ScoreProgress";

	public static string GetURL()
	{
		return "ui://xogvri2hkoygr";
	}

	public static UI_ScoreProgress CreateInstance()
	{
		return (UI_ScoreProgress)(object)UIPackage.CreateObject("LegendItemsDraw", "ScoreProgress");
	}

	public static UI_ScoreProgress CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScoreProgress).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://xogvri2hkoygr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Tyep = ((GComponent)this).GetController("Tyep");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		bar = (UI_ScoreBar)(object)((GComponent)this).GetChild("bar");
		sfxBack = (GGraph)((GComponent)this).GetChild("sfxBack");
		chest = (UI_ScoreChest)(object)((GComponent)this).GetChild("chest");
		curNum = (GTextField)((GComponent)this).GetChild("curNum");
		totalNum = (GTextField)((GComponent)this).GetChild("totalNum");
		split = (GTextField)((GComponent)this).GetChild("split");
		BoxBreathing = ((GComponent)this).GetTransition("BoxBreathing");
	}
}
