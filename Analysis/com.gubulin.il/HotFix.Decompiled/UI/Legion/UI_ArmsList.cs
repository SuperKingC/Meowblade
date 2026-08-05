using FairyGUI;
using FairyGUI.Utils;

namespace UI.Legion;

public class UI_ArmsList : GComponent
{
	public Controller Status;

	public GList armsList_a;

	public GGraph separatedLine;

	public GList armsList_b;

	public GGraph separatedLine1;

	public GList armsList_c;

	public const string URL = "ui://lrhs6zw7vaxb451";

	public static string Name = "UI_ArmsList";

	public static string GetURL()
	{
		return "ui://lrhs6zw7vaxb451";
	}

	public static UI_ArmsList CreateInstance()
	{
		return (UI_ArmsList)(object)UIPackage.CreateObject("Legion", "ArmsList");
	}

	public static UI_ArmsList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ArmsList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrhs6zw7vaxb451", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		armsList_a = (GList)((GComponent)this).GetChild("armsList_a");
		separatedLine = (GGraph)((GComponent)this).GetChild("separatedLine");
		armsList_b = (GList)((GComponent)this).GetChild("armsList_b");
		separatedLine1 = (GGraph)((GComponent)this).GetChild("separatedLine1");
		armsList_c = (GList)((GComponent)this).GetChild("armsList_c");
	}
}
