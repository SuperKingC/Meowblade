using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_NeutralDungeonBack : GComponent
{
	public GGraph n19;

	public GLoader Image;

	public const string URL = "ui://kozswd8haxd7f2z";

	public static string Name = "UI_NeutralDungeonBack";

	public static string GetURL()
	{
		return "ui://kozswd8haxd7f2z";
	}

	public static UI_NeutralDungeonBack CreateInstance()
	{
		return (UI_NeutralDungeonBack)(object)UIPackage.CreateObject("SpecialActivity", "NeutralDungeonBack");
	}

	public static UI_NeutralDungeonBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_NeutralDungeonBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8haxd7f2z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n19 = (GGraph)((GComponent)this).GetChild("n19");
		Image = (GLoader)((GComponent)this).GetChild("Image");
	}
}
