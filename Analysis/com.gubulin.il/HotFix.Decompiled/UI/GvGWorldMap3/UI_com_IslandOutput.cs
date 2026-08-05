using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_IslandOutput : GComponent
{
	public Controller State;

	public GImage back;

	public GImage n10;

	public GTextField IslandName;

	public GTextField descPreview;

	public GList Output;

	public GRichTextField descSelect;

	public GButton exitButton;

	public UI_btn_AllSelect SelectAll;

	public UI_btn_SaveCollectConfig SaveCollectConfig;

	public const string URL = "ui://4eq8fgd2o8el2w";

	public static string Name = "UI_com_IslandOutput";

	public static string GetURL()
	{
		return "ui://4eq8fgd2o8el2w";
	}

	public static UI_com_IslandOutput CreateInstance()
	{
		return (UI_com_IslandOutput)(object)UIPackage.CreateObject("GvGWorldMap3", "com_IslandOutput");
	}

	public static UI_com_IslandOutput CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandOutput).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2o8el2w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		back = (GImage)((GComponent)this).GetChild("back");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		IslandName = (GTextField)((GComponent)this).GetChild("IslandName");
		descPreview = (GTextField)((GComponent)this).GetChild("descPreview");
		string id = "ui://4eq8fgd2o8el2w".Replace("ui://", "") + "-" + ((GObject)descPreview).id;
		((GObject)descPreview).text = LanguagesManager.GetDesc(id);
		Output = (GList)((GComponent)this).GetChild("Output");
		descSelect = (GRichTextField)((GComponent)this).GetChild("descSelect");
		string id2 = "ui://4eq8fgd2o8el2w".Replace("ui://", "") + "-" + ((GObject)descSelect).id;
		((GObject)descSelect).text = LanguagesManager.GetDesc(id2);
		exitButton = (GButton)((GComponent)this).GetChild("exitButton");
		SelectAll = (UI_btn_AllSelect)(object)((GComponent)this).GetChild("SelectAll");
		SaveCollectConfig = (UI_btn_SaveCollectConfig)(object)((GComponent)this).GetChild("SaveCollectConfig");
	}
}
