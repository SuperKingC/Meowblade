using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_03 : GComponent
{
	public GImage n70;

	public GLoader rewardIconAdvance;

	public GTextField num;

	public const string URL = "ui://29q48tv6cp085f9n";

	public static string Name = "UI_com_03";

	public static string GetURL()
	{
		return "ui://29q48tv6cp085f9n";
	}

	public static UI_com_03 CreateInstance()
	{
		return (UI_com_03)(object)UIPackage.CreateObject("GameActivity", "com_03");
	}

	public static UI_com_03 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_03).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6cp085f9n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n70 = (GImage)((GComponent)this).GetChild("n70");
		rewardIconAdvance = (GLoader)((GComponent)this).GetChild("rewardIconAdvance");
		num = (GTextField)((GComponent)this).GetChild("num");
	}
}
