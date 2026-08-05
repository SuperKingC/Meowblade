using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_rewardWeekTree : GComponent
{
	public GLoader n63;

	public GLoader n60;

	public GLoader n59;

	public GLoader n61;

	public GLoader n62;

	public GLoader n65;

	public GLoader n64;

	public GLoader n66;

	public GGroup iconGroup;

	public const string URL = "ui://29q48tv6kf8gf71";

	public static string Name = "UI_com_rewardWeekTree";

	public static string GetURL()
	{
		return "ui://29q48tv6kf8gf71";
	}

	public static UI_com_rewardWeekTree CreateInstance()
	{
		return (UI_com_rewardWeekTree)(object)UIPackage.CreateObject("GameActivity", "com_rewardWeekTree");
	}

	public static UI_com_rewardWeekTree CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_rewardWeekTree).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6kf8gf71", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n63 = (GLoader)((GComponent)this).GetChild("n63");
		n60 = (GLoader)((GComponent)this).GetChild("n60");
		n59 = (GLoader)((GComponent)this).GetChild("n59");
		n61 = (GLoader)((GComponent)this).GetChild("n61");
		n62 = (GLoader)((GComponent)this).GetChild("n62");
		n65 = (GLoader)((GComponent)this).GetChild("n65");
		n64 = (GLoader)((GComponent)this).GetChild("n64");
		n66 = (GLoader)((GComponent)this).GetChild("n66");
		iconGroup = (GGroup)((GComponent)this).GetChild("iconGroup");
	}
}
