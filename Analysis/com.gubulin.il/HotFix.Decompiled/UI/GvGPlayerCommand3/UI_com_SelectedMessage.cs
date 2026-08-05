using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPlayerCommand3;

public class UI_com_SelectedMessage : GComponent
{
	public Controller Type;

	public GTextField n0;

	public GTextField Text1;

	public GTextField Text2;

	public const string URL = "ui://vheg8vabeai3f";

	public static string Name = "UI_com_SelectedMessage";

	public static string GetURL()
	{
		return "ui://vheg8vabeai3f";
	}

	public static UI_com_SelectedMessage CreateInstance()
	{
		return (UI_com_SelectedMessage)(object)UIPackage.CreateObject("GvGPlayerCommand3", "com_SelectedMessage");
	}

	public static UI_com_SelectedMessage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SelectedMessage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai3f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://vheg8vabeai3f".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		Text1 = (GTextField)((GComponent)this).GetChild("Text1");
		Text2 = (GTextField)((GComponent)this).GetChild("Text2");
	}
}
