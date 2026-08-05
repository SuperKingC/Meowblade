using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_btn_ShowOwnedOnly : GComponent
{
	public GImage n124;

	public GTextField n122;

	public UI_btn_CheckBox CheckBox;

	public const string URL = "ui://th385mtty3efm";

	public static string Name = "UI_btn_ShowOwnedOnly";

	public static string GetURL()
	{
		return "ui://th385mtty3efm";
	}

	public static UI_btn_ShowOwnedOnly CreateInstance()
	{
		return (UI_btn_ShowOwnedOnly)(object)UIPackage.CreateObject("GvGOuterTech", "btn_ShowOwnedOnly");
	}

	public static UI_btn_ShowOwnedOnly CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ShowOwnedOnly).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtty3efm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n124 = (GImage)((GComponent)this).GetChild("n124");
		n122 = (GTextField)((GComponent)this).GetChild("n122");
		string id = "ui://th385mtty3efm".Replace("ui://", "") + "-" + ((GObject)n122).id;
		((GObject)n122).text = LanguagesManager.GetDesc(id);
		CheckBox = (UI_btn_CheckBox)(object)((GComponent)this).GetChild("CheckBox");
	}
}
