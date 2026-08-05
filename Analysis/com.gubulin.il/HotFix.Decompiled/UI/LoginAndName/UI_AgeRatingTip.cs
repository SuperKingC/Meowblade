using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_AgeRatingTip : GComponent
{
	public GRichTextField tip;

	public const string URL = "ui://yb3s7uv7p18i3d";

	public static string Name = "UI_AgeRatingTip";

	public static string GetURL()
	{
		return "ui://yb3s7uv7p18i3d";
	}

	public static UI_AgeRatingTip CreateInstance()
	{
		return (UI_AgeRatingTip)(object)UIPackage.CreateObject("LoginAndName", "AgeRatingTip");
	}

	public static UI_AgeRatingTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AgeRatingTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7p18i3d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		tip = (GRichTextField)((GComponent)this).GetChild("tip");
		string id = "ui://yb3s7uv7p18i3d".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
	}
}
