using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_btn_PageTab0 : GButton
{
	public Controller button;

	public GImage n162;

	public GImage n161;

	public GTextField n160;

	public const string URL = "ui://91jxdrkap3r716";

	public static string Name = "UI_btn_PageTab0";

	public static string GetURL()
	{
		return "ui://91jxdrkap3r716";
	}

	public static UI_btn_PageTab0 CreateInstance()
	{
		return (UI_btn_PageTab0)(object)UIPackage.CreateObject("GvGSettlement", "btn_PageTab0");
	}

	public static UI_btn_PageTab0 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_PageTab0).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkap3r716", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n162 = (GImage)((GComponent)this).GetChild("n162");
		n161 = (GImage)((GComponent)this).GetChild("n161");
		n160 = (GTextField)((GComponent)this).GetChild("n160");
		string id = "ui://91jxdrkap3r716".Replace("ui://", "") + "-" + ((GObject)n160).id;
		((GObject)n160).text = LanguagesManager.GetDesc(id);
	}
}
