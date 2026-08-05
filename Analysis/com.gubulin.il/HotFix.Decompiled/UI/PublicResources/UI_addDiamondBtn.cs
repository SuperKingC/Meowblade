using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_addDiamondBtn : GComponent
{
	public Controller button;

	public GImage n7;

	public UI_addButton addButton;

	public GLoader diamond;

	public GGraph textSFXBack;

	public GTextField num;

	public const string URL = "ui://kt6rg65ok67uac";

	public static string Name = "UI_addDiamondBtn";

	public static string GetURL()
	{
		return "ui://kt6rg65ok67uac";
	}

	public static UI_addDiamondBtn CreateInstance()
	{
		return (UI_addDiamondBtn)(object)UIPackage.CreateObject("PublicResources", "addDiamondBtn");
	}

	public static UI_addDiamondBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_addDiamondBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ok67uac", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		addButton = (UI_addButton)(object)((GComponent)this).GetChild("addButton");
		diamond = (GLoader)((GComponent)this).GetChild("diamond");
		textSFXBack = (GGraph)((GComponent)this).GetChild("textSFXBack");
		num = (GTextField)((GComponent)this).GetChild("num");
	}
}
