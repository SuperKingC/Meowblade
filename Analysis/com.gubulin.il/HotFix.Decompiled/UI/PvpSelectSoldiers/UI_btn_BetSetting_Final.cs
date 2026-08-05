using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_BetSetting_Final : GButton
{
	public Controller HasBet;

	public Controller IsLocked;

	public GImage n102;

	public GLoader FlagFrame;

	public GTextField title;

	public GImage n98;

	public GImage n101;

	public const string URL = "ui://82mo10n5ielxjdso";

	public static string Name = "UI_btn_BetSetting_Final";

	public static string GetURL()
	{
		return "ui://82mo10n5ielxjdso";
	}

	public static UI_btn_BetSetting_Final CreateInstance()
	{
		return (UI_btn_BetSetting_Final)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_BetSetting_Final");
	}

	public static UI_btn_BetSetting_Final CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BetSetting_Final).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5ielxjdso", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasBet = ((GComponent)this).GetController("HasBet");
		IsLocked = ((GComponent)this).GetController("IsLocked");
		n102 = (GImage)((GComponent)this).GetChild("n102");
		FlagFrame = (GLoader)((GComponent)this).GetChild("FlagFrame");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://82mo10n5ielxjdso".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n98 = (GImage)((GComponent)this).GetChild("n98");
		n101 = (GImage)((GComponent)this).GetChild("n101");
	}
}
