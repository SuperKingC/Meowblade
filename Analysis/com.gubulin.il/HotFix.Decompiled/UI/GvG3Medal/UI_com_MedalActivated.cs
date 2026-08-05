using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Medal;

namespace UI.GvG3Medal;

public class UI_com_MedalActivated : GComponent
{
	public Controller Display;

	public GImage n0;

	public GLoader MedalIcon;

	public GLoader MedalEffect;

	public GImage n1;

	public GTextField n2;

	public GImage n4;

	public GImage n5;

	public GTextField MedalLevel;

	public UI_btn_ChangeMedal Change;

	public UI_btn_RemoveMedal Remove;

	public GTextField n11;

	public const string URL = "ui://g5hi1peosxgww";

	public static string Name = "UI_com_MedalActivated";

	public static string GetURL()
	{
		return "ui://g5hi1peosxgww";
	}

	public static UI_com_MedalActivated CreateInstance()
	{
		return (UI_com_MedalActivated)(object)UIPackage.CreateObject("GvG3Medal", "com_MedalActivated");
	}

	public static UI_com_MedalActivated CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MedalActivated).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peosxgww", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Display = ((GComponent)this).GetController("Display");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		MedalIcon = (GLoader)((GComponent)this).GetChild("MedalIcon");
		MedalEffect = (GLoader)((GComponent)this).GetChild("MedalEffect");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://g5hi1peosxgww".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		MedalLevel = (GTextField)((GComponent)this).GetChild("MedalLevel");
		Change = (UI_btn_ChangeMedal)(object)((GComponent)this).GetChild("Change");
		Remove = (UI_btn_RemoveMedal)(object)((GComponent)this).GetChild("Remove");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id2 = "ui://g5hi1peosxgww".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id2);
	}

	public void OnRender(GvGMedalRecord medalRecord, EventCallback1 changeMedal)
	{
		MedalIcon.url = medalRecord.Config.BigIcon;
		((GObject)MedalLevel).text = $"Lv{medalRecord.Level}";
		Display.SetSelectedIndex((int)medalRecord.UiState);
		((GObject)Remove).data = medalRecord.MedalId;
		((GObject)Remove).onClick.Set(changeMedal);
		((GObject)Change).data = medalRecord.MedalId;
		((GObject)Change).onClick.Set(changeMedal);
		((GObject)Change).visible = medalRecord.Config.Rarity != 1;
		((GObject)MedalEffect).visible = medalRecord.MedalId == "I66000";
	}

	public void Update(GvGMedalRecord medalRecord)
	{
		Display.SetSelectedIndex((int)medalRecord.UiState);
	}
}
