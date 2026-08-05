using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_FFAModeInstructions : GComponent
{
	public GImage n2;

	public GImage n0;

	public GImage bg;

	public GImage n3;

	public GList rewardList;

	public GTextField n8;

	public const string URL = "ui://hozu168rniiv6u";

	public static string Name = "UI_com_FFAModeInstructions";

	public static string GetURL()
	{
		return "ui://hozu168rniiv6u";
	}

	public static UI_com_FFAModeInstructions CreateInstance()
	{
		return (UI_com_FFAModeInstructions)(object)UIPackage.CreateObject("GvGBrawlFight", "com_FFAModeInstructions");
	}

	public static UI_com_FFAModeInstructions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FFAModeInstructions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rniiv6u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		rewardList = (GList)((GComponent)this).GetChild("rewardList");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id = "ui://hozu168rniiv6u".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id);
	}
}
