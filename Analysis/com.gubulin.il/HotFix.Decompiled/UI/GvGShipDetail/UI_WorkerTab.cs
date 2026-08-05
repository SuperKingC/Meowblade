using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_WorkerTab : GButton
{
	public Controller button;

	public Controller HasNotice;

	public GImage n2;

	public GImage n0;

	public GTextField n3;

	public GButton n5;

	public const string URL = "ui://u6x0b1gnw9n033";

	public static string Name = "UI_WorkerTab";

	public static string GetURL()
	{
		return "ui://u6x0b1gnw9n033";
	}

	public static UI_WorkerTab CreateInstance()
	{
		return (UI_WorkerTab)(object)UIPackage.CreateObject("GvGShipDetail", "WorkerTab");
	}

	public static UI_WorkerTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WorkerTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnw9n033", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		HasNotice = ((GComponent)this).GetController("HasNotice");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://u6x0b1gnw9n033".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n5 = (GButton)((GComponent)this).GetChild("n5");
	}
}
