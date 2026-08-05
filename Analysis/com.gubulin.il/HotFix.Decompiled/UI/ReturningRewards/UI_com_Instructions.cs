using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_com_Instructions : GComponent
{
	public GImage Background;

	public GImage n1;

	public UI_exit Close;

	public const string URL = "ui://rx5ntv98yvss2e";

	public static string Name = "UI_com_Instructions";

	public static string GetURL()
	{
		return "ui://rx5ntv98yvss2e";
	}

	public static UI_com_Instructions CreateInstance()
	{
		return (UI_com_Instructions)(object)UIPackage.CreateObject("ReturningRewards", "com_Instructions");
	}

	public static UI_com_Instructions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Instructions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98yvss2e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		Close = (UI_exit)(object)((GComponent)this).GetChild("Close");
	}
}
