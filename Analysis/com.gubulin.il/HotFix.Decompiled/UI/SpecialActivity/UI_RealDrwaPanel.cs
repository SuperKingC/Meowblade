using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_RealDrwaPanel : GComponent
{
	public Controller Type;

	public UI_RealDrawBack Back;

	public GImage n8;

	public UI_GoToDrawSoldier GoToDraw;

	public GTextField n23;

	public GTextField Desc;

	public GTextField n21;

	public UI_EnterGVG OpenGvGExpeditionHall;

	public const string URL = "ui://kozswd8hruzr1l";

	public static string Name = "UI_RealDrwaPanel";

	public static string GetURL()
	{
		return "ui://kozswd8hruzr1l";
	}

	public static UI_RealDrwaPanel CreateInstance()
	{
		return (UI_RealDrwaPanel)(object)UIPackage.CreateObject("SpecialActivity", "RealDrwaPanel");
	}

	public static UI_RealDrwaPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RealDrwaPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hruzr1l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Back = (UI_RealDrawBack)(object)((GComponent)this).GetChild("Back");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		GoToDraw = (UI_GoToDrawSoldier)(object)((GComponent)this).GetChild("GoToDraw");
		n23 = (GTextField)((GComponent)this).GetChild("n23");
		string id = "ui://kozswd8hruzr1l".Replace("ui://", "") + "-" + ((GObject)n23).id;
		((GObject)n23).text = LanguagesManager.GetDesc(id);
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id2 = "ui://kozswd8hruzr1l".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id2);
		OpenGvGExpeditionHall = (UI_EnterGVG)(object)((GComponent)this).GetChild("OpenGvGExpeditionHall");
	}
}
