using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_RemoveAccountDialog : GComponent
{
	public GImage back;

	public GTextField n2;

	public GGraph n3;

	public GImage n4;

	public GImage n5;

	public GTextField n6;

	public UI_CancelBtn cancel;

	public UI_GoToRemoveBtn goToRemove;

	public const string URL = "ui://b9yxt7u0p2md54";

	public static string Name = "UI_RemoveAccountDialog";

	public static string GetURL()
	{
		return "ui://b9yxt7u0p2md54";
	}

	public static UI_RemoveAccountDialog CreateInstance()
	{
		return (UI_RemoveAccountDialog)(object)UIPackage.CreateObject("AccountInfo", "RemoveAccountDialog");
	}

	public static UI_RemoveAccountDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RemoveAccountDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0p2md54", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://b9yxt7u0p2md54".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		n3 = (GGraph)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id2 = "ui://b9yxt7u0p2md54".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id2);
		cancel = (UI_CancelBtn)(object)((GComponent)this).GetChild("cancel");
		goToRemove = (UI_GoToRemoveBtn)(object)((GComponent)this).GetChild("goToRemove");
	}
}
