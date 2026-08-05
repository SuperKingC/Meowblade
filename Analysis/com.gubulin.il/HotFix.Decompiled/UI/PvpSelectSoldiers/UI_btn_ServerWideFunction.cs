using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_ServerWideFunction : GButton
{
	public Controller button;

	public GLoader icon;

	public GTextField title;

	public const string URL = "ui://82mo10n5u344jdrm";

	public static string Name = "UI_btn_ServerWideFunction";

	public static string GetURL()
	{
		return "ui://82mo10n5u344jdrm";
	}

	public static UI_btn_ServerWideFunction CreateInstance()
	{
		return (UI_btn_ServerWideFunction)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_ServerWideFunction");
	}

	public static UI_btn_ServerWideFunction CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ServerWideFunction).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5u344jdrm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://82mo10n5u344jdrm".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
