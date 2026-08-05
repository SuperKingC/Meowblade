using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_02 : GComponent
{
	public GImage n70;

	public GImage n71;

	public GLoader rewardIconAdvance;

	public GTextField num;

	public Transition t0;

	public const string URL = "ui://29q48tv6cp085f9m";

	public static string Name = "UI_com_02";

	public static string GetURL()
	{
		return "ui://29q48tv6cp085f9m";
	}

	public static UI_com_02 CreateInstance()
	{
		return (UI_com_02)(object)UIPackage.CreateObject("GameActivity", "com_02");
	}

	public static UI_com_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6cp085f9m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n70 = (GImage)((GComponent)this).GetChild("n70");
		n71 = (GImage)((GComponent)this).GetChild("n71");
		rewardIconAdvance = (GLoader)((GComponent)this).GetChild("rewardIconAdvance");
		num = (GTextField)((GComponent)this).GetChild("num");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
