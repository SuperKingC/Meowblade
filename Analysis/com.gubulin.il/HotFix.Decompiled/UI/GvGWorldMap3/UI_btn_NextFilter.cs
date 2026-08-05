using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_NextFilter : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://4eq8fgd2kivrsbt";

	public static string Name = "UI_btn_NextFilter";

	public static string GetURL()
	{
		return "ui://4eq8fgd2kivrsbt";
	}

	public static UI_btn_NextFilter CreateInstance()
	{
		return (UI_btn_NextFilter)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_NextFilter");
	}

	public static UI_btn_NextFilter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_NextFilter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2kivrsbt", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
