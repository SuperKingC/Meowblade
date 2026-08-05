using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_SourceMark : GComponent
{
	public Controller State;

	public GImage n1;

	public GImage n2;

	public GImage n3;

	public const string URL = "ui://4eq8fgd2o8el2z";

	public static string Name = "UI_com_SourceMark";

	public static string GetURL()
	{
		return "ui://4eq8fgd2o8el2z";
	}

	public static UI_com_SourceMark CreateInstance()
	{
		return (UI_com_SourceMark)(object)UIPackage.CreateObject("GvGWorldMap3", "com_SourceMark");
	}

	public static UI_com_SourceMark CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SourceMark).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2o8el2z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
