using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_segment : GButton
{
	public Controller button;

	public Controller Type;

	public GGraph line;

	public const string URL = "ui://c9n2h0ksm7wz63";

	public static string Name = "UI_segment";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz63";
	}

	public static UI_segment CreateInstance()
	{
		return (UI_segment)(object)UIPackage.CreateObject("WorldMap", "segment");
	}

	public static UI_segment CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_segment).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz63", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		line = (GGraph)((GComponent)this).GetChild("line");
	}
}
