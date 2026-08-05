using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.QQGameActivity;

public class UI_popup_01 : GComponent
{
	public GImage n0;

	public GTextField n2;

	public GTextField n3;

	public const string URL = "ui://r1j1a2l0iian3f";

	public static string Name = "UI_popup_01";

	public static string GetURL()
	{
		return "ui://r1j1a2l0iian3f";
	}

	public static UI_popup_01 CreateInstance()
	{
		return (UI_popup_01)(object)UIPackage.CreateObject("QQGameActivity", "popup_01");
	}

	public static UI_popup_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_popup_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r1j1a2l0iian3f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://r1j1a2l0iian3f".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id2 = "ui://r1j1a2l0iian3f".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id2);
	}
}
