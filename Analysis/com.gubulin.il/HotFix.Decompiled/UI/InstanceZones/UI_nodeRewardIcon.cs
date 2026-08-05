using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_nodeRewardIcon : GButton
{
	public Controller Type;

	public GLoader leftIcon;

	public GImage debris;

	public GTextField num;

	public GGraph SfxBack;

	public const string URL = "ui://f4wr270rkpq61x";

	public static string Name = "UI_nodeRewardIcon";

	public static string GetURL()
	{
		return "ui://f4wr270rkpq61x";
	}

	public static UI_nodeRewardIcon CreateInstance()
	{
		return (UI_nodeRewardIcon)(object)UIPackage.CreateObject("InstanceZones", "nodeRewardIcon");
	}

	public static UI_nodeRewardIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_nodeRewardIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rkpq61x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		leftIcon = (GLoader)((GComponent)this).GetChild("leftIcon");
		debris = (GImage)((GComponent)this).GetChild("debris");
		num = (GTextField)((GComponent)this).GetChild("num");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}
}
