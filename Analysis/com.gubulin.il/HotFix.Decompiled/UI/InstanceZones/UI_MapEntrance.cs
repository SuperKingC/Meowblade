using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_MapEntrance : GButton
{
	public Controller button;

	public Controller TypeController;

	public GGraph SfxContainer;

	public GTextField Title;

	public GImage note;

	public GGraph MaskSfxContainer;

	public const string URL = "ui://f4wr270rg9y75p";

	public static string Name = "UI_MapEntrance";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://f4wr270rg9y75p".Replace("ui://", ""), ((GObject)Title).id, TypeController.selectedIndex);
		((GObject)Title).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://f4wr270rg9y75p";
	}

	public static UI_MapEntrance CreateInstance()
	{
		return (UI_MapEntrance)(object)UIPackage.CreateObject("InstanceZones", "MapEntrance");
	}

	public static UI_MapEntrance CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MapEntrance).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rg9y75p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		TypeController = ((GComponent)this).GetController("TypeController");
		SfxContainer = (GGraph)((GComponent)this).GetChild("SfxContainer");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://f4wr270rg9y75p".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
		MaskSfxContainer = (GGraph)((GComponent)this).GetChild("MaskSfxContainer");
	}
}
