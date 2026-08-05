using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_BuildingTitleNotEnabled : GComponent
{
	public Controller PageController;

	public Controller Status;

	public GImage back;

	public GTextField name;

	public GTextField tip;

	public GImage note;

	public Transition t0;

	public const string URL = "ui://kt6rg65og2r7t8k";

	public static string Name = "UI_BuildingTitleNotEnabled";

	public static string GetURL()
	{
		return "ui://kt6rg65og2r7t8k";
	}

	public static UI_BuildingTitleNotEnabled CreateInstance()
	{
		return (UI_BuildingTitleNotEnabled)(object)UIPackage.CreateObject("PublicResources", "BuildingTitleNotEnabled");
	}

	public static UI_BuildingTitleNotEnabled CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BuildingTitleNotEnabled).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65og2r7t8k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		Status = ((GComponent)this).GetController("Status");
		back = (GImage)((GComponent)this).GetChild("back");
		name = (GTextField)((GComponent)this).GetChild("name");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://kt6rg65og2r7t8k".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
