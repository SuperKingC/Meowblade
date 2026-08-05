using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorkShop;

public class UI_IconBtn : GButton
{
	public GLoader frame;

	public const string URL = "ui://k6y9jq3alyq02t";

	public static string Name = "UI_IconBtn";

	public static string GetURL()
	{
		return "ui://k6y9jq3alyq02t";
	}

	public static UI_IconBtn CreateInstance()
	{
		return (UI_IconBtn)(object)UIPackage.CreateObject("WorkShop", "IconBtn");
	}

	public static UI_IconBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IconBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k6y9jq3alyq02t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		frame = (GLoader)((GComponent)this).GetChild("frame");
	}
}
