using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_com_BackDetail : GComponent
{
	public Controller Type;

	public GImage n0;

	public const string URL = "ui://rx5ntv98ypgu1q";

	public static string Name = "UI_com_BackDetail";

	public static string GetURL()
	{
		return "ui://rx5ntv98ypgu1q";
	}

	public static UI_com_BackDetail CreateInstance()
	{
		return (UI_com_BackDetail)(object)UIPackage.CreateObject("ReturningRewards", "com_BackDetail");
	}

	public static UI_com_BackDetail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BackDetail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98ypgu1q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
	}
}
