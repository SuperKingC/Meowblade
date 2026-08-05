using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_btn_Cancel : GButton
{
	public Controller button;

	public GImage n9;

	public GTextField title0;

	public const string URL = "ui://4r1llhd8f7ku5c";

	public static string Name = "UI_btn_Cancel";

	public static string GetURL()
	{
		return "ui://4r1llhd8f7ku5c";
	}

	public static UI_btn_Cancel CreateInstance()
	{
		return (UI_btn_Cancel)(object)UIPackage.CreateObject("GvGTalent", "btn_Cancel");
	}

	public static UI_btn_Cancel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Cancel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8f7ku5c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n9 = (GImage)((GComponent)this).GetChild("n9");
		title0 = (GTextField)((GComponent)this).GetChild("title0");
		string id = "ui://4r1llhd8f7ku5c".Replace("ui://", "") + "-" + ((GObject)title0).id;
		((GObject)title0).text = LanguagesManager.GetDesc(id);
	}
}
