using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_DrawPnael : GComponent
{
	public GImage n24;

	public UI_CompoundBtn GoToDraw;

	public GTextField n21;

	public const string URL = "ui://kozswd8hndjav";

	public static string Name = "UI_DrawPnael";

	public static string GetURL()
	{
		return "ui://kozswd8hndjav";
	}

	public static UI_DrawPnael CreateInstance()
	{
		return (UI_DrawPnael)(object)UIPackage.CreateObject("SpecialActivity", "DrawPnael");
	}

	public static UI_DrawPnael CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DrawPnael).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hndjav", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n24 = (GImage)((GComponent)this).GetChild("n24");
		GoToDraw = (UI_CompoundBtn)(object)((GComponent)this).GetChild("GoToDraw");
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id = "ui://kozswd8hndjav".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id);
	}
}
