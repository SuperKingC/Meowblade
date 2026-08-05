using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_StrategyBtn : GButton
{
	public Controller button;

	public Controller CampId;

	public GImage n5;

	public GLoader Icon;

	public GImage n6;

	public GTextField n7;

	public const string URL = "ui://hd2s9kukjm2l49";

	public static string Name = "UI_StrategyBtn";

	public static string GetURL()
	{
		return "ui://hd2s9kukjm2l49";
	}

	public static UI_StrategyBtn CreateInstance()
	{
		return (UI_StrategyBtn)(object)UIPackage.CreateObject("GvGWorldMap2", "StrategyBtn");
	}

	public static UI_StrategyBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StrategyBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukjm2l49", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		CampId = ((GComponent)this).GetController("CampId");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://hd2s9kukjm2l49".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
	}
}
