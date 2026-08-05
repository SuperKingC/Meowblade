using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_btn_CheckDetail : GButton
{
	public Controller button;

	public GImage n5;

	public GImage n3;

	public GTextField n4;

	public const string URL = "ui://b3fc6085stwvf";

	public static string Name = "UI_btn_CheckDetail";

	public static string GetURL()
	{
		return "ui://b3fc6085stwvf";
	}

	public static UI_btn_CheckDetail CreateInstance()
	{
		return (UI_btn_CheckDetail)(object)UIPackage.CreateObject("GvGBattleRecord3", "btn_CheckDetail");
	}

	public static UI_btn_CheckDetail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CheckDetail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwvf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://b3fc6085stwvf".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
	}
}
