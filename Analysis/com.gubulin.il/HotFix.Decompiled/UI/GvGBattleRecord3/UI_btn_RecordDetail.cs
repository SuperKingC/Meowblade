using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_btn_RecordDetail : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://b3fc6085stwv1q";

	public static string Name = "UI_btn_RecordDetail";

	public static string GetURL()
	{
		return "ui://b3fc6085stwv1q";
	}

	public static UI_btn_RecordDetail CreateInstance()
	{
		return (UI_btn_RecordDetail)(object)UIPackage.CreateObject("GvGBattleRecord3", "btn_RecordDetail");
	}

	public static UI_btn_RecordDetail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RecordDetail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwv1q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
