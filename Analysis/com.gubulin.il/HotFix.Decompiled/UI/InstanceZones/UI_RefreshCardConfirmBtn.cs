using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_RefreshCardConfirmBtn : GButton
{
	public Controller button;

	public GImage back;

	public GTextField title;

	public const string URL = "ui://f4wr270rhbas3k";

	public static string Name = "UI_RefreshCardConfirmBtn";

	public static string GetURL()
	{
		return "ui://f4wr270rhbas3k";
	}

	public static UI_RefreshCardConfirmBtn CreateInstance()
	{
		return (UI_RefreshCardConfirmBtn)(object)UIPackage.CreateObject("InstanceZones", "RefreshCardConfirmBtn");
	}

	public static UI_RefreshCardConfirmBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RefreshCardConfirmBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rhbas3k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://f4wr270rhbas3k".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
