using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle_PauseSetEffect;

public class UI_dec_02 : GComponent
{
	public Controller c1;

	public GImage n3;

	public Transition t0;

	public const string URL = "ui://e9jxbc7wh7t3h";

	public static string Name = "UI_dec_02";

	public static string GetURL()
	{
		return "ui://e9jxbc7wh7t3h";
	}

	public static UI_dec_02 CreateInstance()
	{
		return (UI_dec_02)(object)UIPackage.CreateObject("Battle_PauseSetEffect", "dec_02");
	}

	public static UI_dec_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e9jxbc7wh7t3h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
