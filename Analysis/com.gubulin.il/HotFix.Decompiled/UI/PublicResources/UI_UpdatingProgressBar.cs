using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_UpdatingProgressBar : GProgressBar
{
	public GImage back;

	public GImage bar;

	public GTextField status;

	public GImage icon;

	public GTextField time;

	public const string URL = "ui://kt6rg65omol0in";

	public static string Name = "UI_UpdatingProgressBar";

	public static string GetURL()
	{
		return "ui://kt6rg65omol0in";
	}

	public static UI_UpdatingProgressBar CreateInstance()
	{
		return (UI_UpdatingProgressBar)(object)UIPackage.CreateObject("PublicResources", "UpdatingProgressBar");
	}

	public static UI_UpdatingProgressBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UpdatingProgressBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65omol0in", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		bar = (GImage)((GComponent)this).GetChild("bar");
		status = (GTextField)((GComponent)this).GetChild("status");
		icon = (GImage)((GComponent)this).GetChild("icon");
		time = (GTextField)((GComponent)this).GetChild("time");
		string id = "ui://kt6rg65omol0in".Replace("ui://", "") + "-" + ((GObject)time).id;
		((GObject)time).text = LanguagesManager.GetDesc(id);
	}
}
