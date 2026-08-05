using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_Item2 : GComponent
{
	public Controller button;

	public Controller RankingTopThree;

	public GImage n7;

	public GLoader Icon;

	public GTextField Num;

	public const string URL = "ui://4eq8fgd2mfues73";

	public static string Name = "UI_com_Item2";

	public static string GetURL()
	{
		return "ui://4eq8fgd2mfues73";
	}

	public static UI_com_Item2 CreateInstance()
	{
		return (UI_com_Item2)(object)UIPackage.CreateObject("GvGWorldMap3", "com_Item2");
	}

	public static UI_com_Item2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Item2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mfues73", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RankingTopThree = ((GComponent)this).GetController("RankingTopThree");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
	}
}
