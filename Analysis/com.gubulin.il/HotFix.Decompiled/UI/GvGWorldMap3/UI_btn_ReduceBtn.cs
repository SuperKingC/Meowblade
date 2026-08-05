using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_ReduceBtn : GButton
{
	public Controller button;

	public GImage background;

	public const string URL = "ui://4eq8fgd2efz66scx";

	public static string Name = "UI_btn_ReduceBtn";

	public static string GetURL()
	{
		return "ui://4eq8fgd2efz66scx";
	}

	public static UI_btn_ReduceBtn CreateInstance()
	{
		return (UI_btn_ReduceBtn)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_ReduceBtn");
	}

	public static UI_btn_ReduceBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ReduceBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2efz66scx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
	}
}
