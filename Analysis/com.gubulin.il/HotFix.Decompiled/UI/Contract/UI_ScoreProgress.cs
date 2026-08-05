using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

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

	public const string URL = "ui://avplaivdnacht63";

	public static string Name = "UI_ScoreProgress";

	public static string GetURL()
	{
		return "ui://avplaivdnacht63";
	}

	public static UI_ScoreProgress CreateInstance()
	{
		return (UI_ScoreProgress)(object)UIPackage.CreateObject("Contract", "ScoreProgress");
	}

	public static UI_ScoreProgress CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScoreProgress).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdnacht63", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Tyep = ((GComponent)this).GetController("Tyep");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		bar = (UI_ScoreBar)(object)((GComponent)this).GetChild("bar");
		sfxBack = (GGraph)((GComponent)this).GetChild("sfxBack");
		chest = (UI_ScoreChest)(object)((GComponent)this).GetChild("chest");
		curNum = (GTextField)((GComponent)this).GetChild("curNum");
		string id = "ui://avplaivdnacht63".Replace("ui://", "") + "-" + ((GObject)curNum).id;
		((GObject)curNum).text = LanguagesManager.GetDesc(id);
		totalNum = (GTextField)((GComponent)this).GetChild("totalNum");
		string id2 = "ui://avplaivdnacht63".Replace("ui://", "") + "-" + ((GObject)totalNum).id;
		((GObject)totalNum).text = LanguagesManager.GetDesc(id2);
		split = (GTextField)((GComponent)this).GetChild("split");
		BoxBreathing = ((GComponent)this).GetTransition("BoxBreathing");
	}
}
