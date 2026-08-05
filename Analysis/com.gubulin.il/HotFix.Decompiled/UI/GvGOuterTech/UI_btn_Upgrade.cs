using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_btn_Upgrade : GButton
{
	public Controller button;

	public GImage n16;

	public GTextField title;

	public const string URL = "ui://th385mttuucj2c";

	public static string Name = "UI_btn_Upgrade";

	public static string GetURL()
	{
		return "ui://th385mttuucj2c";
	}

	public static UI_btn_Upgrade CreateInstance()
	{
		return (UI_btn_Upgrade)(object)UIPackage.CreateObject("GvGOuterTech", "btn_Upgrade");
	}

	public static UI_btn_Upgrade CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Upgrade).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttuucj2c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n16 = (GImage)((GComponent)this).GetChild("n16");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://th385mttuucj2c".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
