using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_GVGPlayerHolding : GComponent
{
	public GImage Frame;

	public GMovieClip HoldingIcon;

	public GImage ProgressBar;

	public GTextField Tip;

	public Transition t0;

	public const string URL = "ui://ebc4ciwrjkzvq2d";

	public static string Name = "UI_com_GVGPlayerHolding";

	public static string GetURL()
	{
		return "ui://ebc4ciwrjkzvq2d";
	}

	public static UI_com_GVGPlayerHolding CreateInstance()
	{
		return (UI_com_GVGPlayerHolding)(object)UIPackage.CreateObject("GvGOnIsland3", "com_GVGPlayerHolding");
	}

	public static UI_com_GVGPlayerHolding CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GVGPlayerHolding).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrjkzvq2d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Frame = (GImage)((GComponent)this).GetChild("Frame");
		HoldingIcon = (GMovieClip)((GComponent)this).GetChild("HoldingIcon");
		ProgressBar = (GImage)((GComponent)this).GetChild("ProgressBar");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id = "ui://ebc4ciwrjkzvq2d".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id);
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
