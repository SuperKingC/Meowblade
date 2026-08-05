using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Souvenir;

public class UI_com_LineText : GComponent
{
	public Controller State;

	public GTextField Desc;

	public GTextField n2;

	public const string URL = "ui://8kibkcqi8zhy2";

	public static string Name = "UI_com_LineText";

	public static string GetURL()
	{
		return "ui://8kibkcqi8zhy2";
	}

	public static UI_com_LineText CreateInstance()
	{
		return (UI_com_LineText)(object)UIPackage.CreateObject("Souvenir", "com_LineText");
	}

	public static UI_com_LineText CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LineText).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8kibkcqi8zhy2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://8kibkcqi8zhy2".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
	}
}
