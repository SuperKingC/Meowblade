using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_NianSpineCom : GComponent
{
	public GGraph n0;

	public GGraph spineBack;

	public const string URL = "ui://29q48tv6iqfl2w";

	public static string Name = "UI_NianSpineCom";

	public static string GetURL()
	{
		return "ui://29q48tv6iqfl2w";
	}

	public static UI_NianSpineCom CreateInstance()
	{
		return (UI_NianSpineCom)(object)UIPackage.CreateObject("GameActivity", "NianSpineCom");
	}

	public static UI_NianSpineCom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_NianSpineCom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6iqfl2w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		spineBack = (GGraph)((GComponent)this).GetChild("spineBack");
	}
}
