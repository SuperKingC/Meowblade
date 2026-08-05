using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_btn_SettlementInfo : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField n5;

	public const string URL = "ui://k19peou7p3r7p5x";

	public static string Name = "UI_btn_SettlementInfo";

	public static string GetURL()
	{
		return "ui://k19peou7p3r7p5x";
	}

	public static UI_btn_SettlementInfo CreateInstance()
	{
		return (UI_btn_SettlementInfo)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_SettlementInfo");
	}

	public static UI_btn_SettlementInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SettlementInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7p3r7p5x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://k19peou7p3r7p5x".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}
