using FairyGUI;
using FairyGUI.Utils;

namespace UI.Collection;

public class UI_workerBack : GButton
{
	public Controller button;

	public GImage reduce;

	public const string URL = "ui://ehe4tm5zb8ch1r";

	public static string Name = "UI_workerBack";

	public static string GetURL()
	{
		return "ui://ehe4tm5zb8ch1r";
	}

	public static UI_workerBack CreateInstance()
	{
		return (UI_workerBack)(object)UIPackage.CreateObject("Collection", "workerBack");
	}

	public static UI_workerBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_workerBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ehe4tm5zb8ch1r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		reduce = (GImage)((GComponent)this).GetChild("reduce");
	}
}
