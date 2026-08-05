using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_btn_ShenJiPoolTab : GButton
{
	public Controller button;

	public GImage n5;

	public GImage n6;

	public GLoader iconUp;

	public GLoader iconDown;

	public const string URL = "ui://fvc33k3gss1d3a";

	public static string Name = "UI_btn_ShenJiPoolTab";

	public static string GetURL()
	{
		return "ui://fvc33k3gss1d3a";
	}

	public static UI_btn_ShenJiPoolTab CreateInstance()
	{
		return (UI_btn_ShenJiPoolTab)(object)UIPackage.CreateObject("GVGStore", "btn_ShenJiPoolTab");
	}

	public static UI_btn_ShenJiPoolTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ShenJiPoolTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gss1d3a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		iconUp = (GLoader)((GComponent)this).GetChild("iconUp");
		iconDown = (GLoader)((GComponent)this).GetChild("iconDown");
	}
}
