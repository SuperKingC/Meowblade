using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_RankingBonusBtn : GButton
{
	public Controller button;

	public GImage n4;

	public const string URL = "ui://0i520nzmvrjgocc";

	public static string Name = "UI_RankingBonusBtn";

	public static string GetURL()
	{
		return "ui://0i520nzmvrjgocc";
	}

	public static UI_RankingBonusBtn CreateInstance()
	{
		return (UI_RankingBonusBtn)(object)UIPackage.CreateObject("LordOfDreams", "RankingBonusBtn");
	}

	public static UI_RankingBonusBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RankingBonusBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmvrjgocc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
