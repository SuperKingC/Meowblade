using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGIslandBuff;

public class UI_btn_MyCamp : GButton
{
	public Controller button;

	public GImage n2;

	public GTextField n5;

	public const string URL = "ui://zh7jgfijnewqfi";

	public static string Name = "UI_btn_MyCamp";

	public static string GetURL()
	{
		return "ui://zh7jgfijnewqfi";
	}

	public static UI_btn_MyCamp CreateInstance()
	{
		return (UI_btn_MyCamp)(object)UIPackage.CreateObject("GvGIslandBuff", "btn_MyCamp");
	}

	public static UI_btn_MyCamp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_MyCamp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqfi", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://zh7jgfijnewqfi".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}
