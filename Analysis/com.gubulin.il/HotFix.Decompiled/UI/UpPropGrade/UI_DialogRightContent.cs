using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpPropGrade;

public class UI_DialogRightContent : GComponent
{
	public Controller Status;

	public GTextField Name_t;

	public GTextField CurrentLevel_t;

	public GTextField NextLevel_t;

	public GImage arrow1;

	public GGraph line;

	public GList PropertyList;

	public const string URL = "ui://blindbbgmol0o";

	public static string Name = "UI_DialogRightContent";

	public static string GetURL()
	{
		return "ui://blindbbgmol0o";
	}

	public static UI_DialogRightContent CreateInstance()
	{
		return (UI_DialogRightContent)(object)UIPackage.CreateObject("UpPropGrade", "DialogRightContent");
	}

	public static UI_DialogRightContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DialogRightContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgmol0o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Name_t = (GTextField)((GComponent)this).GetChild("Name_t");
		CurrentLevel_t = (GTextField)((GComponent)this).GetChild("CurrentLevel_t");
		NextLevel_t = (GTextField)((GComponent)this).GetChild("NextLevel_t");
		arrow1 = (GImage)((GComponent)this).GetChild("arrow1");
		line = (GGraph)((GComponent)this).GetChild("line");
		PropertyList = (GList)((GComponent)this).GetChild("PropertyList");
	}
}
