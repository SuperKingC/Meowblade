using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_btn_BonusDetail : GButton
{
	public Controller button;

	public GImage n190;

	public GTextField n191;

	public const string URL = "ui://ylvfgf90530y5w";

	public static string Name = "UI_btn_BonusDetail";

	public static string GetURL()
	{
		return "ui://ylvfgf90530y5w";
	}

	public static UI_btn_BonusDetail CreateInstance()
	{
		return (UI_btn_BonusDetail)(object)UIPackage.CreateObject("GvG3Leaderboard", "btn_BonusDetail");
	}

	public static UI_btn_BonusDetail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BonusDetail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90530y5w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n190 = (GImage)((GComponent)this).GetChild("n190");
		n191 = (GTextField)((GComponent)this).GetChild("n191");
		string id = "ui://ylvfgf90530y5w".Replace("ui://", "") + "-" + ((GObject)n191).id;
		((GObject)n191).text = LanguagesManager.GetDesc(id);
	}
}
