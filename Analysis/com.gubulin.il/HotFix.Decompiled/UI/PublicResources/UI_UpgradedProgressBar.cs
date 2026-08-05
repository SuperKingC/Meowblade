using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_UpgradedProgressBar : GProgressBar
{
	public GImage back;

	public GImage bar;

	public GTextField time;

	public GImage icon;

	public GTextField upgradeTitle;

	public GTextField repairedTitle;

	public const string URL = "ui://kt6rg65omol0io";

	public static string Name = "UI_UpgradedProgressBar";

	public static string GetURL()
	{
		return "ui://kt6rg65omol0io";
	}

	public static UI_UpgradedProgressBar CreateInstance()
	{
		return (UI_UpgradedProgressBar)(object)UIPackage.CreateObject("PublicResources", "UpgradedProgressBar");
	}

	public static UI_UpgradedProgressBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UpgradedProgressBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65omol0io", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		bar = (GImage)((GComponent)this).GetChild("bar");
		time = (GTextField)((GComponent)this).GetChild("time");
		string id = "ui://kt6rg65omol0io".Replace("ui://", "") + "-" + ((GObject)time).id;
		((GObject)time).text = LanguagesManager.GetDesc(id);
		icon = (GImage)((GComponent)this).GetChild("icon");
		upgradeTitle = (GTextField)((GComponent)this).GetChild("upgradeTitle");
		string id2 = "ui://kt6rg65omol0io".Replace("ui://", "") + "-" + ((GObject)upgradeTitle).id;
		((GObject)upgradeTitle).text = LanguagesManager.GetDesc(id2);
		repairedTitle = (GTextField)((GComponent)this).GetChild("repairedTitle");
		string id3 = "ui://kt6rg65omol0io".Replace("ui://", "") + "-" + ((GObject)repairedTitle).id;
		((GObject)repairedTitle).text = LanguagesManager.GetDesc(id3);
	}
}
