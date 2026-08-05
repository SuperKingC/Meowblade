using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_btn_MyContribution : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField n4;

	public const string URL = "ui://ylvfgf90nmfq71";

	public static string Name = "UI_btn_MyContribution";

	public static string GetURL()
	{
		return "ui://ylvfgf90nmfq71";
	}

	public static UI_btn_MyContribution CreateInstance()
	{
		return (UI_btn_MyContribution)(object)UIPackage.CreateObject("GvG3Leaderboard", "btn_MyContribution");
	}

	public static UI_btn_MyContribution CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_MyContribution).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90nmfq71", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://ylvfgf90nmfq71".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
	}
}
