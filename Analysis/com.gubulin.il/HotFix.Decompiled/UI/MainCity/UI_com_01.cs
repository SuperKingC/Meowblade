using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_com_01 : GComponent
{
	public Controller c1;

	public GImage n131;

	public GLoader n132;

	public const string URL = "ui://j611zmymiianv45o";

	public static string Name = "UI_com_01";

	public static string GetURL()
	{
		return "ui://j611zmymiianv45o";
	}

	public static UI_com_01 CreateInstance()
	{
		return (UI_com_01)(object)UIPackage.CreateObject("MainCity", "com_01");
	}

	public static UI_com_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmymiianv45o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		n131 = (GImage)((GComponent)this).GetChild("n131");
		n132 = (GLoader)((GComponent)this).GetChild("n132");
	}
}
