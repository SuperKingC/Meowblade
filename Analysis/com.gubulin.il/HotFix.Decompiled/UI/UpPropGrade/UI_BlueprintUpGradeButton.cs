using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpPropGrade;

public class UI_BlueprintUpGradeButton : GButton
{
	public Controller button;

	public GImage background;

	public GTextField Title;

	public const string URL = "ui://blindbbgio2yt";

	public static string Name = "UI_BlueprintUpGradeButton";

	public static string GetURL()
	{
		return "ui://blindbbgio2yt";
	}

	public static UI_BlueprintUpGradeButton CreateInstance()
	{
		return (UI_BlueprintUpGradeButton)(object)UIPackage.CreateObject("UpPropGrade", "BlueprintUpGradeButton");
	}

	public static UI_BlueprintUpGradeButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BlueprintUpGradeButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgio2yt", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://blindbbgio2yt".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
	}
}
