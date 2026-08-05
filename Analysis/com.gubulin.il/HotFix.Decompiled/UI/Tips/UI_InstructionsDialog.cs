using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_InstructionsDialog : GComponent
{
	public GImage background;

	public GTextField instructions;

	public const string URL = "ui://47lbpgx9neyg17";

	public static string Name = "UI_InstructionsDialog";

	public static string GetURL()
	{
		return "ui://47lbpgx9neyg17";
	}

	public static UI_InstructionsDialog CreateInstance()
	{
		return (UI_InstructionsDialog)(object)UIPackage.CreateObject("Tips", "InstructionsDialog");
	}

	public static UI_InstructionsDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InstructionsDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9neyg17", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GImage)((GComponent)this).GetChild("background");
		instructions = (GTextField)((GComponent)this).GetChild("instructions");
		string id = "ui://47lbpgx9neyg17".Replace("ui://", "") + "-" + ((GObject)instructions).id;
		((GObject)instructions).text = LanguagesManager.GetDesc(id);
	}
}
