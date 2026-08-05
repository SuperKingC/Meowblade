using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Waiting;

public class UI_btn_Retry : GButton
{
	public GImage back;

	public GTextField n3;

	public const string URL = "ui://f36jspecflt26";

	public static string Name = "UI_btn_Retry";

	public static string GetURL()
	{
		return "ui://f36jspecflt26";
	}

	public static UI_btn_Retry CreateInstance()
	{
		return (UI_btn_Retry)(object)UIPackage.CreateObject("Waiting", "btn_Retry");
	}

	public static UI_btn_Retry CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Retry).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f36jspecflt26", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://f36jspecflt26".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
	}
}
