using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_SpecialRecource : GComponent
{
	public Controller InfoType;

	public GGraph n12;

	public GImage n13;

	public GTextField CountDown;

	public GTextField n10;

	public GTextField n11;

	public GLoader Icon;

	public const string URL = "ui://4eq8fgd2ucwa6r";

	public static string Name = "UI_com_SpecialRecource";

	public static string GetURL()
	{
		return "ui://4eq8fgd2ucwa6r";
	}

	public static UI_com_SpecialRecource CreateInstance()
	{
		return (UI_com_SpecialRecource)(object)UIPackage.CreateObject("GvGWorldMap3", "com_SpecialRecource");
	}

	public static UI_com_SpecialRecource CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpecialRecource).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2ucwa6r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		InfoType = ((GComponent)this).GetController("InfoType");
		n12 = (GGraph)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		CountDown = (GTextField)((GComponent)this).GetChild("CountDown");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id = "ui://4eq8fgd2ucwa6r".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id2 = "ui://4eq8fgd2ucwa6r".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id2);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
	}
}
