using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_JumpModeSwitch : GButton
{
	public Controller button;

	public GImage n49;

	public GImage n50;

	public GTextField n46;

	public GLoader n48;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2mk4p9r";

	public static string Name = "UI_btn_JumpModeSwitch";

	public static string GetURL()
	{
		return "ui://4eq8fgd2mk4p9r";
	}

	public static UI_btn_JumpModeSwitch CreateInstance()
	{
		return (UI_btn_JumpModeSwitch)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_JumpModeSwitch");
	}

	public static UI_btn_JumpModeSwitch CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_JumpModeSwitch).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mk4p9r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n46 = (GTextField)((GComponent)this).GetChild("n46");
		string id = "ui://4eq8fgd2mk4p9r".Replace("ui://", "") + "-" + ((GObject)n46).id;
		((GObject)n46).text = LanguagesManager.GetDesc(id);
		n48 = (GLoader)((GComponent)this).GetChild("n48");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
