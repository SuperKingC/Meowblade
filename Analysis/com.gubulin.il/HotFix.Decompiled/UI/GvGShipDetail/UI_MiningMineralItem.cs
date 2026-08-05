using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_MiningMineralItem : GComponent
{
	public Controller IsMax;

	public Controller state;

	public GLoader frame;

	public GLoader icon;

	public GImage max;

	public GImage n119;

	public GImage n117;

	public GTextField num;

	public GGroup n118;

	public const string URL = "ui://u6x0b1gnb5tq2x";

	public static string Name = "UI_MiningMineralItem";

	public static string GetURL()
	{
		return "ui://u6x0b1gnb5tq2x";
	}

	public static UI_MiningMineralItem CreateInstance()
	{
		return (UI_MiningMineralItem)(object)UIPackage.CreateObject("GvGShipDetail", "MiningMineralItem");
	}

	public static UI_MiningMineralItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MiningMineralItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnb5tq2x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsMax = ((GComponent)this).GetController("IsMax");
		state = ((GComponent)this).GetController("state");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		max = (GImage)((GComponent)this).GetChild("max");
		n119 = (GImage)((GComponent)this).GetChild("n119");
		n117 = (GImage)((GComponent)this).GetChild("n117");
		num = (GTextField)((GComponent)this).GetChild("num");
		n118 = (GGroup)((GComponent)this).GetChild("n118");
	}
}
