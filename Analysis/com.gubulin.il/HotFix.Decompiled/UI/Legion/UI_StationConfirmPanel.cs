using FairyGUI;
using FairyGUI.Utils;

namespace UI.Legion;

public class UI_StationConfirmPanel : GComponent
{
	public GGraph transparentMask;

	public UI_StationConfirmDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://lrhs6zw7r46h44f";

	public static string Name = "UI_StationConfirmPanel";

	public static string GetURL()
	{
		return "ui://lrhs6zw7r46h44f";
	}

	public static UI_StationConfirmPanel CreateInstance()
	{
		return (UI_StationConfirmPanel)(object)UIPackage.CreateObject("Legion", "StationConfirmPanel");
	}

	public static UI_StationConfirmPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StationConfirmPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrhs6zw7r46h44f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		transparentMask = (GGraph)((GComponent)this).GetChild("transparentMask");
		Dialog = (UI_StationConfirmDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}
}
