using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_BossSpinWrapper : GComponent
{
	public GImage n22;

	public GGraph SpineWrapper;

	public const string URL = "ui://4eq8fgd2wp0gs88";

	public static string Name = "UI_com_BossSpinWrapper";

	public static string GetURL()
	{
		return "ui://4eq8fgd2wp0gs88";
	}

	public static UI_com_BossSpinWrapper CreateInstance()
	{
		return (UI_com_BossSpinWrapper)(object)UIPackage.CreateObject("GvGWorldMap3", "com_BossSpinWrapper");
	}

	public static UI_com_BossSpinWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BossSpinWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2wp0gs88", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n22 = (GImage)((GComponent)this).GetChild("n22");
		SpineWrapper = (GGraph)((GComponent)this).GetChild("SpineWrapper");
	}
}
