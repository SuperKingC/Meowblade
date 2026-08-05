using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_ReplayDialog : GComponent
{
	public GImage n3;

	public GButton ReplayBtn;

	public GButton ExitBtn;

	public GTextField n6;

	public const string URL = "ui://hda5vzklp57v52";

	public static string Name = "UI_ReplayDialog";

	public static string GetURL()
	{
		return "ui://hda5vzklp57v52";
	}

	public static UI_ReplayDialog CreateInstance()
	{
		return (UI_ReplayDialog)(object)UIPackage.CreateObject("GameEndPanels", "ReplayDialog");
	}

	public static UI_ReplayDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReplayDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklp57v52", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GImage)((GComponent)this).GetChild("n3");
		ReplayBtn = (GButton)((GComponent)this).GetChild("ReplayBtn");
		ExitBtn = (GButton)((GComponent)this).GetChild("ExitBtn");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://hda5vzklp57v52".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
	}
}
