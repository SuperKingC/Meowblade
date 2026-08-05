using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_Item : GComponent
{
	public Controller button;

	public Controller RankingTopThree;

	public Controller NumType;

	public GLoader Icon;

	public GTextField Num;

	public GImage n7;

	public GImage n8;

	public GImage n9;

	public GImage n10;

	public const string URL = "ui://4eq8fgd2hgjzfb";

	public static string Name = "UI_com_Item";

	public static string GetURL()
	{
		return "ui://4eq8fgd2hgjzfb";
	}

	public static UI_com_Item CreateInstance()
	{
		return (UI_com_Item)(object)UIPackage.CreateObject("GvGWorldMap3", "com_Item");
	}

	public static UI_com_Item CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Item).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2hgjzfb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RankingTopThree = ((GComponent)this).GetController("RankingTopThree");
		NumType = ((GComponent)this).GetController("NumType");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
