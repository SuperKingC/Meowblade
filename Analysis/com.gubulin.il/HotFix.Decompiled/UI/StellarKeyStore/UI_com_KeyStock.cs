using FairyGUI;
using FairyGUI.Utils;

namespace UI.StellarKeyStore;

public class UI_com_KeyStock : GComponent
{
	public Controller Type;

	public GImage n52;

	public GImage n53;

	public GImage n54;

	public GLoader Icon;

	public GTextField Count;

	public const string URL = "ui://khops95ljjo11a";

	public static string Name = "UI_com_KeyStock";

	public static string GetURL()
	{
		return "ui://khops95ljjo11a";
	}

	public static UI_com_KeyStock CreateInstance()
	{
		return (UI_com_KeyStock)(object)UIPackage.CreateObject("StellarKeyStore", "com_KeyStock");
	}

	public static UI_com_KeyStock CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_KeyStock).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://khops95ljjo11a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Type = ((GComponent)this).GetController("Type");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Count = (GTextField)((GComponent)this).GetChild("Count");
	}
}
