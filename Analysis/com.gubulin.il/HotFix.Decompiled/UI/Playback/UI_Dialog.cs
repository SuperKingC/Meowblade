using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Playback;

public class UI_Dialog : GComponent
{
	public Controller Type;

	public Controller TipController;

	public Controller ContentController;

	public GGraph Mask;

	public GImage Back;

	public GImage n12;

	public GTextField n13;

	public GList Video;

	public GTextField Tip;

	public GTextField Tip1;

	public UI_PageBtnFoo PageBtnFoo;

	public UI_PageBtnBar PageBtnBar;

	public UI_RepairBtn Refresh;

	public UI_DialogMaskZBOSS n14;

	public GGraph SfxBack;

	public Transition ZBOSSExtraScene;

	public const string URL = "ui://9u6qpm6pt6gc4";

	public static string Name = "UI_Dialog";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://9u6qpm6pt6gc4".Replace("ui://", ""), ((GObject)Tip).id, TipController.selectedIndex);
		((GObject)Tip).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://9u6qpm6pt6gc4";
	}

	public static UI_Dialog CreateInstance()
	{
		return (UI_Dialog)(object)UIPackage.CreateObject("Playback", "Dialog");
	}

	public static UI_Dialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Dialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://9u6qpm6pt6gc4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		TipController = ((GComponent)this).GetController("TipController");
		ContentController = ((GComponent)this).GetController("ContentController");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Back = (GImage)((GComponent)this).GetChild("Back");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id = "ui://9u6qpm6pt6gc4".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id);
		Video = (GList)((GComponent)this).GetChild("Video");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id2 = "ui://9u6qpm6pt6gc4".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id2);
		Tip1 = (GTextField)((GComponent)this).GetChild("Tip1");
		string id3 = "ui://9u6qpm6pt6gc4".Replace("ui://", "") + "-" + ((GObject)Tip1).id;
		((GObject)Tip1).text = LanguagesManager.GetDesc(id3);
		PageBtnFoo = (UI_PageBtnFoo)(object)((GComponent)this).GetChild("PageBtnFoo");
		PageBtnBar = (UI_PageBtnBar)(object)((GComponent)this).GetChild("PageBtnBar");
		Refresh = (UI_RepairBtn)(object)((GComponent)this).GetChild("Refresh");
		n14 = (UI_DialogMaskZBOSS)(object)((GComponent)this).GetChild("n14");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		ZBOSSExtraScene = ((GComponent)this).GetTransition("ZBOSSExtraScene");
	}
}
