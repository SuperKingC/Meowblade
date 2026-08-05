using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_PatronPanel : GComponent
{
	public GImage n40;

	public GImage n41;

	public GImage n39;

	public GList PatronList;

	public const string URL = "ui://29q48tv6hkkt21";

	public static string Name = "UI_PatronPanel";

	public static string GetURL()
	{
		return "ui://29q48tv6hkkt21";
	}

	public static UI_PatronPanel CreateInstance()
	{
		return (UI_PatronPanel)(object)UIPackage.CreateObject("GameActivity", "PatronPanel");
	}

	public static UI_PatronPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PatronPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6hkkt21", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		PatronList = (GList)((GComponent)this).GetChild("PatronList");
	}
}
