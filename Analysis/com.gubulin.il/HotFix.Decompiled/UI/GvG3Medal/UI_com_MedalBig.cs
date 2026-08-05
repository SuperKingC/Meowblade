using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Medal;

namespace UI.GvG3Medal;

public class UI_com_MedalBig : GComponent
{
	public Controller Rarity;

	public Controller Activated;

	public GImage n4;

	public GImage n1;

	public GImage n2;

	public GTextField MedalName0;

	public UI_com_MedalActivated ActivatedMedal;

	public GTextField MedalName1;

	public GTextField MedalName2;

	public UI_com_NotActiveMedal NotActiveMedal;

	public GTextField MedalDesc;

	public const string URL = "ui://g5hi1peosxgwv";

	public static string Name = "UI_com_MedalBig";

	public string DisplayMedalId { get; set; }

	public static string GetURL()
	{
		return "ui://g5hi1peosxgwv";
	}

	public static UI_com_MedalBig CreateInstance()
	{
		return (UI_com_MedalBig)(object)UIPackage.CreateObject("GvG3Medal", "com_MedalBig");
	}

	public static UI_com_MedalBig CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MedalBig).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peosxgwv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Rarity = ((GComponent)this).GetController("Rarity");
		Activated = ((GComponent)this).GetController("Activated");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		MedalName0 = (GTextField)((GComponent)this).GetChild("MedalName0");
		ActivatedMedal = (UI_com_MedalActivated)(object)((GComponent)this).GetChild("ActivatedMedal");
		MedalName1 = (GTextField)((GComponent)this).GetChild("MedalName1");
		MedalName2 = (GTextField)((GComponent)this).GetChild("MedalName2");
		NotActiveMedal = (UI_com_NotActiveMedal)(object)((GComponent)this).GetChild("NotActiveMedal");
		MedalDesc = (GTextField)((GComponent)this).GetChild("MedalDesc");
	}

	public void OnRender(GvGMedalRecord medalRecord, EventCallback1 changeMedal)
	{
		DisplayMedalId = medalRecord.MedalId;
		ActivatedMedal.OnRender(medalRecord, changeMedal);
		NotActiveMedal.MedalIcon.url = medalRecord.Config.BigIcon;
		((GObject)MedalDesc).text = medalRecord.Config.PostScript;
		Rarity.SetSelectedIndex(medalRecord.Config.Rarity - 1);
		SetMedalName(medalRecord.Config.Name);
		Activated.SetSelectedIndex(medalRecord.Activated ? 1 : 0);
	}

	private void SetMedalName(string medalName)
	{
		((GComponent)this).GetChild($"MedalName{Rarity.selectedIndex}").text = medalName;
	}
}
