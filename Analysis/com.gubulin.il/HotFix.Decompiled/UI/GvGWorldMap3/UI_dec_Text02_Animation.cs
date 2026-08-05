using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_dec_Text02_Animation : GComponent
{
	public UI_dec_Text02 n111;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2q0ucfh";

	public static string Name = "UI_dec_Text02_Animation";

	public static string GetURL()
	{
		return "ui://4eq8fgd2q0ucfh";
	}

	public static UI_dec_Text02_Animation CreateInstance()
	{
		return (UI_dec_Text02_Animation)(object)UIPackage.CreateObject("GvGWorldMap3", "dec_Text02_Animation");
	}

	public static UI_dec_Text02_Animation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_Text02_Animation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2q0ucfh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		n111 = (UI_dec_Text02)(object)((GComponent)this).GetChild("n111");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
