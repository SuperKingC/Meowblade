using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_userLevelUpDescItem : GButton
{
	public GRichTextField title;

	public GGroup n13;

	public UI_com_LevelUpEffect LevelUpEffect;

	public Transition t0;

	public const string URL = "ui://47lbpgx9f3r62u";

	public static string Name = "UI_userLevelUpDescItem";

	public static string GetURL()
	{
		return "ui://47lbpgx9f3r62u";
	}

	public static UI_userLevelUpDescItem CreateInstance()
	{
		return (UI_userLevelUpDescItem)(object)UIPackage.CreateObject("Tips", "userLevelUpDescItem");
	}

	public static UI_userLevelUpDescItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_userLevelUpDescItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9f3r62u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://47lbpgx9f3r62u".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n13 = (GGroup)((GComponent)this).GetChild("n13");
		LevelUpEffect = (UI_com_LevelUpEffect)(object)((GComponent)this).GetChild("LevelUpEffect");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
