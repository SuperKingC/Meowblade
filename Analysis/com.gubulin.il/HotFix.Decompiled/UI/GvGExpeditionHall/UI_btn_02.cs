using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_btn_02 : GButton
{
	public Controller button;

	public GImage n10;

	public GTextField n11;

	public GImage n12;

	public const string URL = "ui://k19peou795pe6p92";

	public static string Name = "UI_btn_02";

	public static string GetURL()
	{
		return "ui://k19peou795pe6p92";
	}

	public static UI_btn_02 CreateInstance()
	{
		return (UI_btn_02)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_02");
	}

	public static UI_btn_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou795pe6p92", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://k19peou795pe6p92".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		n12 = (GImage)((GComponent)this).GetChild("n12");
	}
}
