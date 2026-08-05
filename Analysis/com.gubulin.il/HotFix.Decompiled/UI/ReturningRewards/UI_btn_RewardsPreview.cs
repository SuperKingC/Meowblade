using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_btn_RewardsPreview : GButton
{
	public Controller button;

	public GImage n6;

	public GTextField n7;

	public const string URL = "ui://rx5ntv98win2i";

	public static string Name = "UI_btn_RewardsPreview";

	public static string GetURL()
	{
		return "ui://rx5ntv98win2i";
	}

	public static UI_btn_RewardsPreview CreateInstance()
	{
		return (UI_btn_RewardsPreview)(object)UIPackage.CreateObject("ReturningRewards", "btn_RewardsPreview");
	}

	public static UI_btn_RewardsPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RewardsPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win2i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://rx5ntv98win2i".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
	}
}
