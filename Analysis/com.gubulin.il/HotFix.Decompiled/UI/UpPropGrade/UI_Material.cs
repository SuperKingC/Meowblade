using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpPropGrade;

public class UI_Material : GComponent
{
	public GLoader Frame;

	public GLoader Icon;

	public GComponent Requirement;

	public GGraph SfxBack;

	public const string URL = "ui://blindbbgx4m28";

	public static string Name = "UI_Material";

	public static string GetURL()
	{
		return "ui://blindbbgx4m28";
	}

	public static UI_Material CreateInstance()
	{
		return (UI_Material)(object)UIPackage.CreateObject("UpPropGrade", "Material");
	}

	public static UI_Material CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Material).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgx4m28", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Frame = (GLoader)((GComponent)this).GetChild("Frame");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Requirement = (GComponent)((GComponent)this).GetChild("Requirement");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}
}
