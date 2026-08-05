using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_VictoryLight : GComponent
{
	public GImage n0;

	public UI_rotateLightBtn n1;

	public Transition lightRotate;

	public Transition t1;

	public const string URL = "ui://kt6rg65oqtmo42";

	public static string Name = "UI_VictoryLight";

	public static string GetURL()
	{
		return "ui://kt6rg65oqtmo42";
	}

	public static UI_VictoryLight CreateInstance()
	{
		return (UI_VictoryLight)(object)UIPackage.CreateObject("PublicResources", "VictoryLight");
	}

	public static UI_VictoryLight CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_VictoryLight).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oqtmo42", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (UI_rotateLightBtn)(object)((GComponent)this).GetChild("n1");
		lightRotate = ((GComponent)this).GetTransition("lightRotate");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
