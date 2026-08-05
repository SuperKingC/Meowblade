using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpdateResources;

public class UI_UpdateProgressBar : GProgressBar
{
	public GGraph n0;

	public GGraph bar1;

	public GTextField progress;

	public GTextField info;

	public GGraph n5;

	public GImage bar;

	public const string URL = "ui://sui7dihfk1jj4";

	public static string Name = "UI_UpdateProgressBar";

	public static string GetURL()
	{
		return "ui://sui7dihfk1jj4";
	}

	public static UI_UpdateProgressBar CreateInstance()
	{
		return (UI_UpdateProgressBar)(object)UIPackage.CreateObject("UpdateResources", "UpdateProgressBar");
	}

	public static UI_UpdateProgressBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UpdateProgressBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://sui7dihfk1jj4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		bar1 = (GGraph)((GComponent)this).GetChild("bar1");
		progress = (GTextField)((GComponent)this).GetChild("progress");
		info = (GTextField)((GComponent)this).GetChild("info");
		string id = "ui://sui7dihfk1jj4".Replace("ui://", "") + "-" + ((GObject)info).id;
		((GObject)info).text = LanguagesManager.GetDesc(id);
		n5 = (GGraph)((GComponent)this).GetChild("n5");
		bar = (GImage)((GComponent)this).GetChild("bar");
	}
}
