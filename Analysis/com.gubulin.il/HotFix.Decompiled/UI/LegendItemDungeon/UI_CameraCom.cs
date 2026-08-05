using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_CameraCom : GComponent
{
	public GImage Mask;

	public UI_CameraMain MapMain;

	public GImage Lens;

	public GGraph SpineBack;

	public GGraph Curtain;

	public Transition t0;

	public const string URL = "ui://2eraz3j9kod04";

	public static string Name = "UI_CameraCom";

	public static string GetURL()
	{
		return "ui://2eraz3j9kod04";
	}

	public static UI_CameraCom CreateInstance()
	{
		return (UI_CameraCom)(object)UIPackage.CreateObject("LegendItemDungeon", "CameraCom");
	}

	public static UI_CameraCom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CameraCom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9kod04", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GImage)((GComponent)this).GetChild("Mask");
		MapMain = (UI_CameraMain)(object)((GComponent)this).GetChild("MapMain");
		Lens = (GImage)((GComponent)this).GetChild("Lens");
		SpineBack = (GGraph)((GComponent)this).GetChild("SpineBack");
		Curtain = (GGraph)((GComponent)this).GetChild("Curtain");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
