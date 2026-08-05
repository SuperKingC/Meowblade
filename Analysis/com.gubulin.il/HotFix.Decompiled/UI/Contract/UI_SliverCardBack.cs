using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_SliverCardBack : GComponent
{
	public GButton n12;

	public const string URL = "ui://avplaivdvecsb";

	public static string Name = "UI_SliverCardBack";

	public static string GetURL()
	{
		return "ui://avplaivdvecsb";
	}

	public static UI_SliverCardBack CreateInstance()
	{
		return (UI_SliverCardBack)(object)UIPackage.CreateObject("Contract", "SliverCardBack");
	}

	public static UI_SliverCardBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SliverCardBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdvecsb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n12 = (GButton)((GComponent)this).GetChild("n12");
	}
}
