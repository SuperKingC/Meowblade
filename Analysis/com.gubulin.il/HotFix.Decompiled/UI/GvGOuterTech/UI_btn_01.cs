using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_btn_01 : GButton
{
	public GImage n142;

	public GImage n143;

	public GTextField n144;

	public const string URL = "ui://th385mttj7x6o8f";

	public static string Name = "UI_btn_01";

	public static string GetURL()
	{
		return "ui://th385mttj7x6o8f";
	}

	public static UI_btn_01 CreateInstance()
	{
		return (UI_btn_01)(object)UIPackage.CreateObject("GvGOuterTech", "btn_01");
	}

	public static UI_btn_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttj7x6o8f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n142 = (GImage)((GComponent)this).GetChild("n142");
		n143 = (GImage)((GComponent)this).GetChild("n143");
		n144 = (GTextField)((GComponent)this).GetChild("n144");
		string id = "ui://th385mttj7x6o8f".Replace("ui://", "") + "-" + ((GObject)n144).id;
		((GObject)n144).text = LanguagesManager.GetDesc(id);
	}
}
