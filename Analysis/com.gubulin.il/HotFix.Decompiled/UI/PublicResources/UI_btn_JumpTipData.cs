using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_btn_JumpTipData : GButton
{
	public Controller GotoBtnDisplaying;

	public GImage n2;

	public GTextField Source;

	public GImage n7;

	public GTextField n5;

	public const string URL = "ui://kt6rg65oh8w9v4o8";

	public static string Name = "UI_btn_JumpTipData";

	public static string GetURL()
	{
		return "ui://kt6rg65oh8w9v4o8";
	}

	public static UI_btn_JumpTipData CreateInstance()
	{
		return (UI_btn_JumpTipData)(object)UIPackage.CreateObject("PublicResources", "btn_JumpTipData");
	}

	public static UI_btn_JumpTipData CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_JumpTipData).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oh8w9v4o8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		GotoBtnDisplaying = ((GComponent)this).GetController("GotoBtnDisplaying");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Source = (GTextField)((GComponent)this).GetChild("Source");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://kt6rg65oh8w9v4o8".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}
