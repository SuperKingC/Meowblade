using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_BrawlFightFinalCloudTip : GComponent
{
	public GImage n1;

	public GImage n2;

	public GImage n3;

	public GTextField textInfo;

	public UI_btn_exit closeBtn;

	public const string URL = "ui://hozu168r8u5g95";

	public static string Name = "UI_com_BrawlFightFinalCloudTip";

	public static string GetURL()
	{
		return "ui://hozu168r8u5g95";
	}

	public static UI_com_BrawlFightFinalCloudTip CreateInstance()
	{
		return (UI_com_BrawlFightFinalCloudTip)(object)UIPackage.CreateObject("GvGBrawlFight", "com_BrawlFightFinalCloudTip");
	}

	public static UI_com_BrawlFightFinalCloudTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BrawlFightFinalCloudTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168r8u5g95", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		textInfo = (GTextField)((GComponent)this).GetChild("textInfo");
		string id = "ui://hozu168r8u5g95".Replace("ui://", "") + "-" + ((GObject)textInfo).id;
		((GObject)textInfo).text = LanguagesManager.GetDesc(id);
		closeBtn = (UI_btn_exit)(object)((GComponent)this).GetChild("closeBtn");
	}
}
