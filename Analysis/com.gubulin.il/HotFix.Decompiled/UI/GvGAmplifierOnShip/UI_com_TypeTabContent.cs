using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_com_TypeTabContent : GComponent
{
	public Controller Type;

	public GImage n105;

	public GImage n106;

	public GImage n107;

	public const string URL = "ui://pwlamcyxgp1610";

	public static string Name = "UI_com_TypeTabContent";

	public static string GetURL()
	{
		return "ui://pwlamcyxgp1610";
	}

	public static UI_com_TypeTabContent CreateInstance()
	{
		return (UI_com_TypeTabContent)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "com_TypeTabContent");
	}

	public static UI_com_TypeTabContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TypeTabContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxgp1610", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Type = ((GComponent)this).GetController("Type");
		n105 = (GImage)((GComponent)this).GetChild("n105");
		n106 = (GImage)((GComponent)this).GetChild("n106");
		n107 = (GImage)((GComponent)this).GetChild("n107");
	}
}
