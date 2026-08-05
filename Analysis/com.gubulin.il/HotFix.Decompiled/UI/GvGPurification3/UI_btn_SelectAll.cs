using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPurification3;

public class UI_btn_SelectAll : GButton
{
	public Controller State;

	public GGraph n7;

	public GImage bg;

	public GImage n5;

	public GTextField n6;

	public GTextField n8;

	public const string URL = "ui://v7vqvgvmsmdjlb";

	public static string Name = "UI_btn_SelectAll";

	public static string GetURL()
	{
		return "ui://v7vqvgvmsmdjlb";
	}

	public static UI_btn_SelectAll CreateInstance()
	{
		return (UI_btn_SelectAll)(object)UIPackage.CreateObject("GvGPurification3", "btn_SelectAll");
	}

	public static UI_btn_SelectAll CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SelectAll).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvmsmdjlb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n7 = (GGraph)((GComponent)this).GetChild("n7");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://v7vqvgvmsmdjlb".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id2 = "ui://v7vqvgvmsmdjlb".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id2);
	}
}
