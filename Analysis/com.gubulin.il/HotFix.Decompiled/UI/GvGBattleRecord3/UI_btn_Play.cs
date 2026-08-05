using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_btn_Play : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n4;

	public const string URL = "ui://b3fc6085stwv20";

	public static string Name = "UI_btn_Play";

	public static string GetURL()
	{
		return "ui://b3fc6085stwv20";
	}

	public static UI_btn_Play CreateInstance()
	{
		return (UI_btn_Play)(object)UIPackage.CreateObject("GvGBattleRecord3", "btn_Play");
	}

	public static UI_btn_Play CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Play).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwv20", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
