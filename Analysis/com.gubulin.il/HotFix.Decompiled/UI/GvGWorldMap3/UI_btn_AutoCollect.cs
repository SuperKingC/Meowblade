using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_AutoCollect : GButton
{
	public Controller button;

	public GGraph n7;

	public GImage bg;

	public GImage n9;

	public GTextField n8;

	public const string URL = "ui://4eq8fgd2v3u539";

	public static string Name = "UI_btn_AutoCollect";

	public static string GetURL()
	{
		return "ui://4eq8fgd2v3u539";
	}

	public static UI_btn_AutoCollect CreateInstance()
	{
		return (UI_btn_AutoCollect)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_AutoCollect");
	}

	public static UI_btn_AutoCollect CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_AutoCollect).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2v3u539", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		button = ((GComponent)this).GetController("button");
		n7 = (GGraph)((GComponent)this).GetChild("n7");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id = "ui://4eq8fgd2v3u539".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id);
	}
}
