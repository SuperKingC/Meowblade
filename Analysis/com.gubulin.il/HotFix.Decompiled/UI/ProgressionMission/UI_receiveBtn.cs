using FairyGUI;
using FairyGUI.Utils;

namespace UI.ProgressionMission;

public class UI_receiveBtn : GButton
{
	public Controller button;

	public GImage n8;

	public GLoader icon;

	public GImage note;

	public const string URL = "ui://mapat4i5fktcv4qx";

	public static string Name = "UI_receiveBtn";

	public static string GetURL()
	{
		return "ui://mapat4i5fktcv4qx";
	}

	public static UI_receiveBtn CreateInstance()
	{
		return (UI_receiveBtn)(object)UIPackage.CreateObject("ProgressionMission", "receiveBtn");
	}

	public static UI_receiveBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_receiveBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5fktcv4qx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GImage)((GComponent)this).GetChild("n8");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
