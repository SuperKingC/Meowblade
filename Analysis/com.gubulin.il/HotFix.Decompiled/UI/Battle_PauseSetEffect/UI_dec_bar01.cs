using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle_PauseSetEffect;

public class UI_dec_bar01 : GComponent
{
	public GImage n8;

	public const string URL = "ui://e9jxbc7wwt9zp";

	public static string Name = "UI_dec_bar01";

	public static string GetURL()
	{
		return "ui://e9jxbc7wwt9zp";
	}

	public static UI_dec_bar01 CreateInstance()
	{
		return (UI_dec_bar01)(object)UIPackage.CreateObject("Battle_PauseSetEffect", "dec_bar01");
	}

	public static UI_dec_bar01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_bar01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e9jxbc7wwt9zp", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
