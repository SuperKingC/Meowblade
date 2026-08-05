using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_btn_Receive : GButton
{
	public Controller button;

	public Controller RedDot;

	public GImage n11;

	public GTextField title;

	public GImage n10;

	public const string URL = "ui://249h3k3dqf7c1m";

	public static string Name = "UI_btn_Receive";

	public static string GetURL()
	{
		return "ui://249h3k3dqf7c1m";
	}

	public static UI_btn_Receive CreateInstance()
	{
		return (UI_btn_Receive)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "btn_Receive");
	}

	public static UI_btn_Receive CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Receive).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dqf7c1m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RedDot = ((GComponent)this).GetController("RedDot");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://249h3k3dqf7c1m".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
