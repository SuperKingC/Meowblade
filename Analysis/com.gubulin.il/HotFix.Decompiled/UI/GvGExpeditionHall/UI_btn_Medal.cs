using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_btn_Medal : GButton
{
	public Controller button;

	public GImage n7;

	public GImage n8;

	public GImage n9;

	public GTextField n118;

	public Transition t0;

	public const string URL = "ui://k19peou7gwf8p6f";

	public static string Name = "UI_btn_Medal";

	public static string GetURL()
	{
		return "ui://k19peou7gwf8p6f";
	}

	public static UI_btn_Medal CreateInstance()
	{
		return (UI_btn_Medal)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_Medal");
	}

	public static UI_btn_Medal CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Medal).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7gwf8p6f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n118 = (GTextField)((GComponent)this).GetChild("n118");
		string id = "ui://k19peou7gwf8p6f".Replace("ui://", "") + "-" + ((GObject)n118).id;
		((GObject)n118).text = LanguagesManager.GetDesc(id);
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
