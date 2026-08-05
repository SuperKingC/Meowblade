using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_ScoreBonusSlotWrapper : GComponent
{
	public GImage n10;

	public GTextField n4;

	public GTextField Title;

	public UI_BonusItem Icon;

	public GGraph n17;

	public GTextField TargetScore;

	public GImage n18;

	public const string URL = "ui://0i520nzmtajuo90";

	public static string Name = "UI_ScoreBonusSlotWrapper";

	public static string GetURL()
	{
		return "ui://0i520nzmtajuo90";
	}

	public static UI_ScoreBonusSlotWrapper CreateInstance()
	{
		return (UI_ScoreBonusSlotWrapper)(object)UIPackage.CreateObject("LordOfDreams", "ScoreBonusSlotWrapper");
	}

	public static UI_ScoreBonusSlotWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScoreBonusSlotWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmtajuo90", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://0i520nzmtajuo90".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id2 = "ui://0i520nzmtajuo90".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id2);
		Icon = (UI_BonusItem)(object)((GComponent)this).GetChild("Icon");
		n17 = (GGraph)((GComponent)this).GetChild("n17");
		TargetScore = (GTextField)((GComponent)this).GetChild("TargetScore");
		n18 = (GImage)((GComponent)this).GetChild("n18");
	}
}
