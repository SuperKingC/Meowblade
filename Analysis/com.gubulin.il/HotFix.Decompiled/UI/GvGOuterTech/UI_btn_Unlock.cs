using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_btn_Unlock : GButton
{
	public Controller button;

	public GImage n17;

	public GTextField title;

	public const string URL = "ui://th385mttzih3o2i";

	public static string Name = "UI_btn_Unlock";

	public static string GetURL()
	{
		return "ui://th385mttzih3o2i";
	}

	public static UI_btn_Unlock CreateInstance()
	{
		return (UI_btn_Unlock)(object)UIPackage.CreateObject("GvGOuterTech", "btn_Unlock");
	}

	public static UI_btn_Unlock CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Unlock).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttzih3o2i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n17 = (GImage)((GComponent)this).GetChild("n17");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://th385mttzih3o2i".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
