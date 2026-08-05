using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.StellarKeyStore;

public class UI_btn_ProductCard : GButton
{
	public Controller button;

	public Controller CanBuy;

	public Controller HasLimit;

	public UI_com_ProductCardContent Content;

	public GTextField n11;

	public GTextField BoughtCountLimit;

	public GGroup n39;

	public GImage n40;

	public const string URL = "ui://khops95lyjovb";

	public static string Name = "UI_btn_ProductCard";

	public static string GetURL()
	{
		return "ui://khops95lyjovb";
	}

	public static UI_btn_ProductCard CreateInstance()
	{
		return (UI_btn_ProductCard)(object)UIPackage.CreateObject("StellarKeyStore", "btn_ProductCard");
	}

	public static UI_btn_ProductCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ProductCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://khops95lyjovb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		CanBuy = ((GComponent)this).GetController("CanBuy");
		HasLimit = ((GComponent)this).GetController("HasLimit");
		Content = (UI_com_ProductCardContent)(object)((GComponent)this).GetChild("Content");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://khops95lyjovb".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		BoughtCountLimit = (GTextField)((GComponent)this).GetChild("BoughtCountLimit");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
		n40 = (GImage)((GComponent)this).GetChild("n40");
	}
}
