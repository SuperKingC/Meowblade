using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_com_AmplifierModel : GComponent
{
	public Controller Quatity;

	public GLoader QualityFrame;

	public GMovieClip n154;

	public Transition t0;

	public const string URL = "ui://fpjheycbkl87v4fc";

	public static string Name = "UI_com_AmplifierModel";

	public static string GetURL()
	{
		return "ui://fpjheycbkl87v4fc";
	}

	public static UI_com_AmplifierModel CreateInstance()
	{
		return (UI_com_AmplifierModel)(object)UIPackage.CreateObject("GvGAmplifierForge", "com_AmplifierModel");
	}

	public static UI_com_AmplifierModel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AmplifierModel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbkl87v4fc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Quatity = ((GComponent)this).GetController("Quatity");
		QualityFrame = (GLoader)((GComponent)this).GetChild("QualityFrame");
		n154 = (GMovieClip)((GComponent)this).GetChild("n154");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
