using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_nodeRewardIcon : GButton
{
	public GLoader leftIcon;

	public GTextField num;

	public GGraph SfxBack;

	public const string URL = "ui://zko5n3veme5j17";

	public static string Name = "UI_nodeRewardIcon";

	public static string GetURL()
	{
		return "ui://zko5n3veme5j17";
	}

	public static UI_nodeRewardIcon CreateInstance()
	{
		return (UI_nodeRewardIcon)(object)UIPackage.CreateObject("PrinceOfTheDevils", "nodeRewardIcon");
	}

	public static UI_nodeRewardIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_nodeRewardIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3veme5j17", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		leftIcon = (GLoader)((GComponent)this).GetChild("leftIcon");
		num = (GTextField)((GComponent)this).GetChild("num");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}
}
