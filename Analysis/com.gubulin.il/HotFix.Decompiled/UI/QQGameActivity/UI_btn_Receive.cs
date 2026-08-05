using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.QQGameActivity;

public class UI_btn_Receive : GButton
{
	public Controller button;

	public GImage n11;

	public GTextField title;

	public const string URL = "ui://r1j1a2l0szly3t";

	public static string Name = "UI_btn_Receive";

	public static string GetURL()
	{
		return "ui://r1j1a2l0szly3t";
	}

	public static UI_btn_Receive CreateInstance()
	{
		return (UI_btn_Receive)(object)UIPackage.CreateObject("QQGameActivity", "btn_Receive");
	}

	public static UI_btn_Receive CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Receive).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r1j1a2l0szly3t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n11 = (GImage)((GComponent)this).GetChild("n11");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://r1j1a2l0szly3t".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
