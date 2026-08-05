using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Collection;

public class UI_Dialog : GComponent
{
	public GGraph interceptBack;

	public GImage windowBack;

	public GLoader frame;

	public GLoader icon;

	public GTextField title;

	public GTextField introduction;

	public GTextField propertyB;

	public GTextField propertyA;

	public GTextField propertyAText;

	public GTextField propertyBText;

	public GGroup showWindow;

	public const string URL = "ui://ehe4tm5zgp9d35";

	public static string Name = "UI_Dialog";

	public static string GetURL()
	{
		return "ui://ehe4tm5zgp9d35";
	}

	public static UI_Dialog CreateInstance()
	{
		return (UI_Dialog)(object)UIPackage.CreateObject("Collection", "Dialog");
	}

	public static UI_Dialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Dialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ehe4tm5zgp9d35", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		interceptBack = (GGraph)((GComponent)this).GetChild("interceptBack");
		windowBack = (GImage)((GComponent)this).GetChild("windowBack");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://ehe4tm5zgp9d35".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		introduction = (GTextField)((GComponent)this).GetChild("introduction");
		string id2 = "ui://ehe4tm5zgp9d35".Replace("ui://", "") + "-" + ((GObject)introduction).id;
		((GObject)introduction).text = LanguagesManager.GetDesc(id2);
		propertyB = (GTextField)((GComponent)this).GetChild("propertyB");
		string id3 = "ui://ehe4tm5zgp9d35".Replace("ui://", "") + "-" + ((GObject)propertyB).id;
		((GObject)propertyB).text = LanguagesManager.GetDesc(id3);
		propertyA = (GTextField)((GComponent)this).GetChild("propertyA");
		string id4 = "ui://ehe4tm5zgp9d35".Replace("ui://", "") + "-" + ((GObject)propertyA).id;
		((GObject)propertyA).text = LanguagesManager.GetDesc(id4);
		propertyAText = (GTextField)((GComponent)this).GetChild("propertyAText");
		string id5 = "ui://ehe4tm5zgp9d35".Replace("ui://", "") + "-" + ((GObject)propertyAText).id;
		((GObject)propertyAText).text = LanguagesManager.GetDesc(id5);
		propertyBText = (GTextField)((GComponent)this).GetChild("propertyBText");
		string id6 = "ui://ehe4tm5zgp9d35".Replace("ui://", "") + "-" + ((GObject)propertyBText).id;
		((GObject)propertyBText).text = LanguagesManager.GetDesc(id6);
		showWindow = (GGroup)((GComponent)this).GetChild("showWindow");
	}
}
