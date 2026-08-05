using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_PeakBattleTab : GButton
{
	public Controller button;

	public GImage InfoBtnDark;

	public GGraph mask;

	public GImage InfoBtnLight;

	public GTextField title;

	public const string URL = "ui://82mo10n5pd2sjdv0";

	public static string Name = "UI_btn_PeakBattleTab";

	public static string GetURL()
	{
		return "ui://82mo10n5pd2sjdv0";
	}

	public static UI_btn_PeakBattleTab CreateInstance()
	{
		return (UI_btn_PeakBattleTab)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_PeakBattleTab");
	}

	public static UI_btn_PeakBattleTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_PeakBattleTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5pd2sjdv0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		InfoBtnDark = (GImage)((GComponent)this).GetChild("InfoBtnDark");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		InfoBtnLight = (GImage)((GComponent)this).GetChild("InfoBtnLight");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://82mo10n5pd2sjdv0".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
