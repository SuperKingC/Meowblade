using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_ProfileDisplayRecordCenter : GComponent
{
	public Controller Style;

	public UI_com_ShipAvatar Avatar;

	public GList Medals;

	public GTextField PlayerName;

	public const string URL = "ui://kt6rg65ocryjv4o1";

	public static string Name = "UI_com_ProfileDisplayRecordCenter";

	public static string GetURL()
	{
		return "ui://kt6rg65ocryjv4o1";
	}

	public static UI_com_ProfileDisplayRecordCenter CreateInstance()
	{
		return (UI_com_ProfileDisplayRecordCenter)(object)UIPackage.CreateObject("PublicResources", "com_ProfileDisplayRecordCenter");
	}

	public static UI_com_ProfileDisplayRecordCenter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ProfileDisplayRecordCenter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ocryjv4o1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Style = ((GComponent)this).GetController("Style");
		Avatar = (UI_com_ShipAvatar)(object)((GComponent)this).GetChild("Avatar");
		Medals = (GList)((GComponent)this).GetChild("Medals");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
	}
}
