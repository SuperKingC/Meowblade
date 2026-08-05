using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_WorkerOnMap : GButton
{
	public Controller button;

	public GProgressBar ProgressBar;

	public GGraph workerBase;

	public GGraph SfxBase;

	public const string URL = "ui://c9n2h0ksmol02y";

	public static string Name = "UI_WorkerOnMap";

	public static string GetURL()
	{
		return "ui://c9n2h0ksmol02y";
	}

	public static UI_WorkerOnMap CreateInstance()
	{
		return (UI_WorkerOnMap)(object)UIPackage.CreateObject("WorldMap", "WorkerOnMap");
	}

	public static UI_WorkerOnMap CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WorkerOnMap).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksmol02y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		ProgressBar = (GProgressBar)((GComponent)this).GetChild("ProgressBar");
		workerBase = (GGraph)((GComponent)this).GetChild("workerBase");
		SfxBase = (GGraph)((GComponent)this).GetChild("SfxBase");
	}
}
