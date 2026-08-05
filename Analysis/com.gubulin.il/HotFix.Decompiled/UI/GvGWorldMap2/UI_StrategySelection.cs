using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_StrategySelection : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n3;

	public GTextField StrategyTitle;

	public GLoader n6;

	public const string URL = "ui://hd2s9kukcqf74h";

	public static string Name = "UI_StrategySelection";

	public static string GetURL()
	{
		return "ui://hd2s9kukcqf74h";
	}

	public static UI_StrategySelection CreateInstance()
	{
		return (UI_StrategySelection)(object)UIPackage.CreateObject("GvGWorldMap2", "StrategySelection");
	}

	public static UI_StrategySelection CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StrategySelection).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukcqf74h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		StrategyTitle = (GTextField)((GComponent)this).GetChild("StrategyTitle");
		string id = "ui://hd2s9kukcqf74h".Replace("ui://", "") + "-" + ((GObject)StrategyTitle).id;
		((GObject)StrategyTitle).text = LanguagesManager.GetDesc(id);
		n6 = (GLoader)((GComponent)this).GetChild("n6");
	}
}
