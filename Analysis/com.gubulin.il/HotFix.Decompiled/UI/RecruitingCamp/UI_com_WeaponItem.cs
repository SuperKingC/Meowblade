using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecruitingCamp;

public class UI_com_WeaponItem : GComponent
{
	public GLoader WeaponFrameLoader;

	public GLoader WeaponIconLoader;

	public GTextField WeaponAmount_t;

	public GTextField title;

	public Transition breathing;

	public const string URL = "ui://72fujxhkzmkj32";

	public static string Name = "UI_com_WeaponItem";

	public static string GetURL()
	{
		return "ui://72fujxhkzmkj32";
	}

	public static UI_com_WeaponItem CreateInstance()
	{
		return (UI_com_WeaponItem)(object)UIPackage.CreateObject("RecruitingCamp", "com_WeaponItem");
	}

	public static UI_com_WeaponItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_WeaponItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72fujxhkzmkj32", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		WeaponFrameLoader = (GLoader)((GComponent)this).GetChild("WeaponFrameLoader");
		WeaponIconLoader = (GLoader)((GComponent)this).GetChild("WeaponIconLoader");
		WeaponAmount_t = (GTextField)((GComponent)this).GetChild("WeaponAmount_t");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://72fujxhkzmkj32".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		breathing = ((GComponent)this).GetTransition("breathing");
	}
}
