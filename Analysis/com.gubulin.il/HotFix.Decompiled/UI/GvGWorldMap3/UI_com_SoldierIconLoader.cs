using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_SoldierIconLoader : GComponent
{
	public GImage Mask;

	public GLoader IconLoader;

	public const string URL = "ui://4eq8fgd2mdde2f";

	public static string Name = "UI_com_SoldierIconLoader";

	public static string GetURL()
	{
		return "ui://4eq8fgd2mdde2f";
	}

	public static UI_com_SoldierIconLoader CreateInstance()
	{
		return (UI_com_SoldierIconLoader)(object)UIPackage.CreateObject("GvGWorldMap3", "com_SoldierIconLoader");
	}

	public static UI_com_SoldierIconLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SoldierIconLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mdde2f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GImage)((GComponent)this).GetChild("Mask");
		IconLoader = (GLoader)((GComponent)this).GetChild("IconLoader");
	}
}
