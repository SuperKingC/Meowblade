using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_yes : GButton
{
	public Controller button;

	public GImage n4;

	public GTextField title0;

	public const string URL = "ui://4eq8fgd2kszvs99";

	public static string Name = "UI_btn_yes";

	public static string GetURL()
	{
		return "ui://4eq8fgd2kszvs99";
	}

	public static UI_btn_yes CreateInstance()
	{
		return (UI_btn_yes)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_yes");
	}

	public static UI_btn_yes CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_yes).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2kszvs99", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		title0 = (GTextField)((GComponent)this).GetChild("title0");
		string id = "ui://4eq8fgd2kszvs99".Replace("ui://", "") + "-" + ((GObject)title0).id;
		((GObject)title0).text = LanguagesManager.GetDesc(id);
	}
}
