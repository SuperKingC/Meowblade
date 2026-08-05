using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecruitingCamp;

public class UI_WeaponItem : GButton
{
	public GLoader WeaponFrameLoader;

	public GLoader WeaponIconLoader;

	public GTextField WeaponName_t;

	public GTextField WeaponAmount_t;

	public GTextField title;

	public Transition breathing;

	public const string URL = "ui://72fujxhkpipj8";

	public static string Name = "UI_WeaponItem";

	public static string GetURL()
	{
		return "ui://72fujxhkpipj8";
	}

	public static UI_WeaponItem CreateInstance()
	{
		return (UI_WeaponItem)(object)UIPackage.CreateObject("RecruitingCamp", "WeaponItem");
	}

	public static UI_WeaponItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WeaponItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72fujxhkpipj8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		WeaponFrameLoader = (GLoader)((GComponent)this).GetChild("WeaponFrameLoader");
		WeaponIconLoader = (GLoader)((GComponent)this).GetChild("WeaponIconLoader");
		WeaponName_t = (GTextField)((GComponent)this).GetChild("WeaponName_t");
		string id = "ui://72fujxhkpipj8".Replace("ui://", "") + "-" + ((GObject)WeaponName_t).id;
		((GObject)WeaponName_t).text = LanguagesManager.GetDesc(id);
		WeaponAmount_t = (GTextField)((GComponent)this).GetChild("WeaponAmount_t");
		string id2 = "ui://72fujxhkpipj8".Replace("ui://", "") + "-" + ((GObject)WeaponAmount_t).id;
		((GObject)WeaponAmount_t).text = LanguagesManager.GetDesc(id2);
		title = (GTextField)((GComponent)this).GetChild("title");
		string id3 = "ui://72fujxhkpipj8".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id3);
		breathing = ((GComponent)this).GetTransition("breathing");
	}
}
