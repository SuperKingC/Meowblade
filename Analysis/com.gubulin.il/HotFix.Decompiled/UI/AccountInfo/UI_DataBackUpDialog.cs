using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_DataBackUpDialog : GComponent
{
	public Controller Type;

	public GImage back;

	public GImage n1;

	public GImage n2;

	public GImage n3;

	public GList UserArchives;

	public const string URL = "ui://b9yxt7u0k38948";

	public static string Name = "UI_DataBackUpDialog";

	public static string GetURL()
	{
		return "ui://b9yxt7u0k38948";
	}

	public static UI_DataBackUpDialog CreateInstance()
	{
		return (UI_DataBackUpDialog)(object)UIPackage.CreateObject("AccountInfo", "DataBackUpDialog");
	}

	public static UI_DataBackUpDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DataBackUpDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0k38948", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GImage)((GComponent)this).GetChild("back");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		UserArchives = (GList)((GComponent)this).GetChild("UserArchives");
	}
}
