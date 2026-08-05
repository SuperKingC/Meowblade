using FairyGUI;
using FairyGUI.Utils;

namespace UI.Dungeons;

public class UI_DungeonLevel : GProgressBar
{
	public GImage back;

	public GImage bar;

	public GGraph SfxBack;

	public GTextField num;

	public const string URL = "ui://e3srq2g9o7r0a";

	public static string Name = "UI_DungeonLevel";

	public static string GetURL()
	{
		return "ui://e3srq2g9o7r0a";
	}

	public static UI_DungeonLevel CreateInstance()
	{
		return (UI_DungeonLevel)(object)UIPackage.CreateObject("Dungeons", "DungeonLevel");
	}

	public static UI_DungeonLevel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DungeonLevel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3srq2g9o7r0a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GImage)((GComponent)this).GetChild("back");
		bar = (GImage)((GComponent)this).GetChild("bar");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		num = (GTextField)((GComponent)this).GetChild("num");
	}
}
