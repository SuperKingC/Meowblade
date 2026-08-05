using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpdateResources;

public class UI_UniversalConfirmDialog : GComponent
{
	public GImage back;

	public GTextField tip;

	public UI_ClearBtn ClearBtn;

	public UI_RestartBtn RestartBtn;

	public const string URL = "ui://sui7dihff4sz9";

	public static string Name = "UI_UniversalConfirmDialog";

	public static string GetURL()
	{
		return "ui://sui7dihff4sz9";
	}

	public static UI_UniversalConfirmDialog CreateInstance()
	{
		return (UI_UniversalConfirmDialog)(object)UIPackage.CreateObject("UpdateResources", "UniversalConfirmDialog");
	}

	public static UI_UniversalConfirmDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UniversalConfirmDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://sui7dihff4sz9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		ClearBtn = (UI_ClearBtn)(object)((GComponent)this).GetChild("ClearBtn");
		RestartBtn = (UI_RestartBtn)(object)((GComponent)this).GetChild("RestartBtn");
	}
}
