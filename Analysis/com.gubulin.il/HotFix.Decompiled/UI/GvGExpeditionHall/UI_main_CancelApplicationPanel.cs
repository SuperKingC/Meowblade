using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_main_CancelApplicationPanel : GComponent
{
	public Controller IsShow;

	public GGraph Mask;

	public UI_com_CancelApplicationDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://k19peou7h7l7p5i";

	public static string Name = "UI_main_CancelApplicationPanel";

	public static string GetURL()
	{
		return "ui://k19peou7h7l7p5i";
	}

	public static UI_main_CancelApplicationPanel CreateInstance()
	{
		return (UI_main_CancelApplicationPanel)(object)UIPackage.CreateObject("GvGExpeditionHall", "main_CancelApplicationPanel");
	}

	public static UI_main_CancelApplicationPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_CancelApplicationPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7h7l7p5i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsShow = ((GComponent)this).GetController("IsShow");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_CancelApplicationDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}
}
