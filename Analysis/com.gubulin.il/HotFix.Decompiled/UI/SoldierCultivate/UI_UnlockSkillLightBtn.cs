using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_UnlockSkillLightBtn : GButton
{
	public Controller button;

	public GImage n20;

	public GImage n21;

	public GImage n22;

	public GImage n23;

	public GGroup highLight;

	public const string URL = "ui://7dantnbibunlt7t";

	public static string Name = "UI_UnlockSkillLightBtn";

	public static string GetURL()
	{
		return "ui://7dantnbibunlt7t";
	}

	public static UI_UnlockSkillLightBtn CreateInstance()
	{
		return (UI_UnlockSkillLightBtn)(object)UIPackage.CreateObject("SoldierCultivate", "UnlockSkillLightBtn");
	}

	public static UI_UnlockSkillLightBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UnlockSkillLightBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbibunlt7t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		button = ((GComponent)this).GetController("button");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		highLight = (GGroup)((GComponent)this).GetChild("highLight");
	}
}
