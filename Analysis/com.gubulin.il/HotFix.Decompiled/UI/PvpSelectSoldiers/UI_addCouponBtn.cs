using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_addCouponBtn : GComponent
{
	public Controller button;

	public GImage n3;

	public GButton addButton;

	public GLoader icon;

	public GGraph textSFXBack;

	public GTextField num;

	public const string URL = "ui://82mo10n5ch138k";

	public static string Name = "UI_addCouponBtn";

	public static string GetURL()
	{
		return "ui://82mo10n5ch138k";
	}

	public static UI_addCouponBtn CreateInstance()
	{
		return (UI_addCouponBtn)(object)UIPackage.CreateObject("PvpSelectSoldiers", "addCouponBtn");
	}

	public static UI_addCouponBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_addCouponBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5ch138k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		addButton = (GButton)((GComponent)this).GetChild("addButton");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		textSFXBack = (GGraph)((GComponent)this).GetChild("textSFXBack");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://82mo10n5ch138k".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
	}
}
