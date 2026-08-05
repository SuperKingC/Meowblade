using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_OuterTechI67502Switch : GComponent
{
	public Controller State;

	public GImage n0;

	public GImage n1;

	public GTextField n2;

	public GTextField AvailableCount;

	public GTextField n12;

	public GLoader CostIcon;

	public GTextField CostValue;

	public GButton Buff;

	public GGroup n17;

	public UI_btn_UseOuterTechI67502 UseTech;

	public const string URL = "ui://4eq8fgd2mn6ws9b";

	public static string Name = "UI_com_OuterTechI67502Switch";

	public static string GetURL()
	{
		return "ui://4eq8fgd2mn6ws9b";
	}

	public static UI_com_OuterTechI67502Switch CreateInstance()
	{
		return (UI_com_OuterTechI67502Switch)(object)UIPackage.CreateObject("GvGWorldMap3", "com_OuterTechI67502Switch");
	}

	public static UI_com_OuterTechI67502Switch CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OuterTechI67502Switch).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mn6ws9b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://4eq8fgd2mn6ws9b".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		AvailableCount = (GTextField)((GComponent)this).GetChild("AvailableCount");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id2 = "ui://4eq8fgd2mn6ws9b".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id2);
		CostIcon = (GLoader)((GComponent)this).GetChild("CostIcon");
		CostValue = (GTextField)((GComponent)this).GetChild("CostValue");
		Buff = (GButton)((GComponent)this).GetChild("Buff");
		n17 = (GGroup)((GComponent)this).GetChild("n17");
		UseTech = (UI_btn_UseOuterTechI67502)(object)((GComponent)this).GetChild("UseTech");
	}
}
