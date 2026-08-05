using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_IslandFuncFillup : GButton, IIslandFunction
{
	public Controller button;

	public Controller Status;

	public GImage n5;

	public GImage n6;

	public const string URL = "ui://4eq8fgd2h4tpe5";

	public static string Name = "UI_btn_IslandFuncFillup";

	public GvG3IslandFunctionBase FunctionBase { get; private set; }

	public string FunctionDesc => FunctionBase.Desc;

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpe5";
	}

	public static UI_btn_IslandFuncFillup CreateInstance()
	{
		return (UI_btn_IslandFuncFillup)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_IslandFuncFillup");
	}

	public static UI_btn_IslandFuncFillup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_IslandFuncFillup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpe5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}

	public void Render(IslandFuncStatus funcStatus, string functionType)
	{
		if (FunctionBase == null)
		{
			FunctionBase = new GvG3IslandFunctionBase();
			FunctionBase.Init(funcStatus, (GButton)(object)this, functionType);
		}
		else
		{
			FunctionBase.Update(funcStatus, (GButton)(object)this);
		}
	}
}
