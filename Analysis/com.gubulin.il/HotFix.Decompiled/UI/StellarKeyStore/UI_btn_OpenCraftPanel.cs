using FairyGUI;
using FairyGUI.Utils;

namespace UI.StellarKeyStore;

public class UI_btn_OpenCraftPanel : GButton
{
	public GImage n53;

	public const string URL = "ui://khops95lk7x91b";

	public static string Name = "UI_btn_OpenCraftPanel";

	public static string GetURL()
	{
		return "ui://khops95lk7x91b";
	}

	public static UI_btn_OpenCraftPanel CreateInstance()
	{
		return (UI_btn_OpenCraftPanel)(object)UIPackage.CreateObject("StellarKeyStore", "btn_OpenCraftPanel");
	}

	public static UI_btn_OpenCraftPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_OpenCraftPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://khops95lk7x91b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n53 = (GImage)((GComponent)this).GetChild("n53");
	}
}
