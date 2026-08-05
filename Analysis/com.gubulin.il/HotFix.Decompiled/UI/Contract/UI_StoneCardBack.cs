using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_StoneCardBack : GComponent
{
	public Controller Type;

	public GImage n0;

	public GImage n1;

	public const string URL = "ui://avplaivdldght5t";

	public static string Name = "UI_StoneCardBack";

	public static string GetURL()
	{
		return "ui://avplaivdldght5t";
	}

	public static UI_StoneCardBack CreateInstance()
	{
		return (UI_StoneCardBack)(object)UIPackage.CreateObject("Contract", "StoneCardBack");
	}

	public static UI_StoneCardBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StoneCardBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdldght5t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
	}
}
