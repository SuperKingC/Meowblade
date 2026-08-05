using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_UpdateProgressBar : GProgressBar
{
	public GGraph n0;

	public GGraph bar;

	public GTextField progress;

	public GTextField info;

	public const string URL = "ui://yb3s7uv7r05k1i";

	public static string Name = "UI_UpdateProgressBar";

	public static string GetURL()
	{
		return "ui://yb3s7uv7r05k1i";
	}

	public static UI_UpdateProgressBar CreateInstance()
	{
		return (UI_UpdateProgressBar)(object)UIPackage.CreateObject("LoginAndName", "UpdateProgressBar");
	}

	public static UI_UpdateProgressBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UpdateProgressBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7r05k1i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		bar = (GGraph)((GComponent)this).GetChild("bar");
		progress = (GTextField)((GComponent)this).GetChild("progress");
		info = (GTextField)((GComponent)this).GetChild("info");
		string id = "ui://yb3s7uv7r05k1i".Replace("ui://", "") + "-" + ((GObject)info).id;
		((GObject)info).text = LanguagesManager.GetDesc(id);
	}
}
