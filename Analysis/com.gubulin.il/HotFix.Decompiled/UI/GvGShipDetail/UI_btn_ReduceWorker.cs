using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_ReduceWorker : GButton
{
	public Controller button;

	public GImage background;

	public const string URL = "ui://u6x0b1gnw9n02z";

	public static string Name = "UI_btn_ReduceWorker";

	public static string GetURL()
	{
		return "ui://u6x0b1gnw9n02z";
	}

	public static UI_btn_ReduceWorker CreateInstance()
	{
		return (UI_btn_ReduceWorker)(object)UIPackage.CreateObject("GvGShipDetail", "btn_ReduceWorker");
	}

	public static UI_btn_ReduceWorker CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ReduceWorker).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnw9n02z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
	}
}
