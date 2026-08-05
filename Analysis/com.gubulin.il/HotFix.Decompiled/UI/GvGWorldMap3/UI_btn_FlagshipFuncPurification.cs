using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_FlagshipFuncPurification : GButton, IFlagshipFunction
{
	public Controller button;

	public Controller Status;

	public GImage n9;

	public GImage n10;

	public const string URL = "ui://4eq8fgd2h4tpej";

	public static string Name = "UI_btn_FlagshipFuncPurification";

	public GvG3FlagshipFunctionBase FunctionBase { get; set; }

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpej";
	}

	public static UI_btn_FlagshipFuncPurification CreateInstance()
	{
		return (UI_btn_FlagshipFuncPurification)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_FlagshipFuncPurification");
	}

	public static UI_btn_FlagshipFuncPurification CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_FlagshipFuncPurification).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpej", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
