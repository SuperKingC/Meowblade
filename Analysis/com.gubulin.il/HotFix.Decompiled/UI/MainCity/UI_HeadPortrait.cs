using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_HeadPortrait : GComponent
{
	public Controller button;

	public GImage n20;

	public GLoader icon;

	public UI_ProgressBar1 articleExperience;

	public GTextField level;

	public GTextField title;

	public GGraph AccountInfoBack;

	public GImage bullyIcon;

	public GGraph bullyIconBtn;

	public GImage supremeIcon;

	public GGraph supremeIconBtn;

	public const string URL = "ui://j611zmymgsomv42k";

	public static string Name = "UI_HeadPortrait";

	public static string GetURL()
	{
		return "ui://j611zmymgsomv42k";
	}

	public static UI_HeadPortrait CreateInstance()
	{
		return (UI_HeadPortrait)(object)UIPackage.CreateObject("MainCity", "HeadPortrait");
	}

	public static UI_HeadPortrait CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HeadPortrait).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmymgsomv42k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		articleExperience = (UI_ProgressBar1)(object)((GComponent)this).GetChild("articleExperience");
		level = (GTextField)((GComponent)this).GetChild("level");
		string id = "ui://j611zmymgsomv42k".Replace("ui://", "") + "-" + ((GObject)level).id;
		((GObject)level).text = LanguagesManager.GetDesc(id);
		title = (GTextField)((GComponent)this).GetChild("title");
		string id2 = "ui://j611zmymgsomv42k".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id2);
		AccountInfoBack = (GGraph)((GComponent)this).GetChild("AccountInfoBack");
		bullyIcon = (GImage)((GComponent)this).GetChild("bullyIcon");
		bullyIconBtn = (GGraph)((GComponent)this).GetChild("bullyIconBtn");
		supremeIcon = (GImage)((GComponent)this).GetChild("supremeIcon");
		supremeIconBtn = (GGraph)((GComponent)this).GetChild("supremeIconBtn");
	}
}
