using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpPropGrade;

public class UI_ProductUpGradeButton : GButton
{
	public Controller button;

	public GImage background;

	public GImage Title;

	public const string URL = "ui://blindbbgx4m26";

	public static string Name = "UI_ProductUpGradeButton";

	public static string GetURL()
	{
		return "ui://blindbbgx4m26";
	}

	public static UI_ProductUpGradeButton CreateInstance()
	{
		return (UI_ProductUpGradeButton)(object)UIPackage.CreateObject("UpPropGrade", "ProductUpGradeButton");
	}

	public static UI_ProductUpGradeButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProductUpGradeButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgx4m26", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
		Title = (GImage)((GComponent)this).GetChild("Title");
	}
}
