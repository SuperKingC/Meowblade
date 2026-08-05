using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_IslandSpeciality : GComponent
{
	public Controller Source;

	public GLoader Icon;

	public UI_com_SourceMark SourceMark;

	public const string URL = "ui://4eq8fgd2mdde2q";

	public static string Name = "UI_com_IslandSpeciality";

	public static string GetURL()
	{
		return "ui://4eq8fgd2mdde2q";
	}

	public static UI_com_IslandSpeciality CreateInstance()
	{
		return (UI_com_IslandSpeciality)(object)UIPackage.CreateObject("GvGWorldMap3", "com_IslandSpeciality");
	}

	public static UI_com_IslandSpeciality CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandSpeciality).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mdde2q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Source = ((GComponent)this).GetController("Source");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		SourceMark = (UI_com_SourceMark)(object)((GComponent)this).GetChild("SourceMark");
	}
}
