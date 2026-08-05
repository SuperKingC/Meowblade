using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_btn_LoadedInfo : GButton
{
	public GImage n156;

	public GTextField n157;

	public GTextField n158;

	public GTextField LoadedCount;

	public GTextField LoadedScore;

	public GImage n162;

	public GButton ExtraAmplifierCountLimitBtn;

	public const string URL = "ui://pwlamcyxgp16u";

	public static string Name = "UI_btn_LoadedInfo";

	public static string GetURL()
	{
		return "ui://pwlamcyxgp16u";
	}

	public static UI_btn_LoadedInfo CreateInstance()
	{
		return (UI_btn_LoadedInfo)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "btn_LoadedInfo");
	}

	public static UI_btn_LoadedInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_LoadedInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxgp16u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n156 = (GImage)((GComponent)this).GetChild("n156");
		n157 = (GTextField)((GComponent)this).GetChild("n157");
		string id = "ui://pwlamcyxgp16u".Replace("ui://", "") + "-" + ((GObject)n157).id;
		((GObject)n157).text = LanguagesManager.GetDesc(id);
		n158 = (GTextField)((GComponent)this).GetChild("n158");
		string id2 = "ui://pwlamcyxgp16u".Replace("ui://", "") + "-" + ((GObject)n158).id;
		((GObject)n158).text = LanguagesManager.GetDesc(id2);
		LoadedCount = (GTextField)((GComponent)this).GetChild("LoadedCount");
		LoadedScore = (GTextField)((GComponent)this).GetChild("LoadedScore");
		n162 = (GImage)((GComponent)this).GetChild("n162");
		ExtraAmplifierCountLimitBtn = (GButton)((GComponent)this).GetChild("ExtraAmplifierCountLimitBtn");
	}
}
