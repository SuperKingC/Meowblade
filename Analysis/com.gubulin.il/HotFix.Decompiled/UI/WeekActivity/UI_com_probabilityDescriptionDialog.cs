using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivity;

public class UI_com_probabilityDescriptionDialog : GComponent
{
	public Controller Type;

	public GImage n0;

	public GImage n1;

	public GTextField n2;

	public GLoader n3;

	public const string URL = "ui://jl0c82y5oqg02e";

	public static string Name = "UI_com_probabilityDescriptionDialog";

	public static string GetURL()
	{
		return "ui://jl0c82y5oqg02e";
	}

	public static UI_com_probabilityDescriptionDialog CreateInstance()
	{
		return (UI_com_probabilityDescriptionDialog)(object)UIPackage.CreateObject("WeekActivity", "com_probabilityDescriptionDialog");
	}

	public static UI_com_probabilityDescriptionDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_probabilityDescriptionDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5oqg02e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://jl0c82y5oqg02e".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		n3 = (GLoader)((GComponent)this).GetChild("n3");
	}
}
