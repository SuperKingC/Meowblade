using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_BigBossTopDmgBtn : GButton
{
	public Controller button;

	public GImage n5;

	public const string URL = "ui://0i520nzmvrjgocb";

	public static string Name = "UI_BigBossTopDmgBtn";

	public static string GetURL()
	{
		return "ui://0i520nzmvrjgocb";
	}

	public static UI_BigBossTopDmgBtn CreateInstance()
	{
		return (UI_BigBossTopDmgBtn)(object)UIPackage.CreateObject("LordOfDreams", "BigBossTopDmgBtn");
	}

	public static UI_BigBossTopDmgBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BigBossTopDmgBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmvrjgocb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
