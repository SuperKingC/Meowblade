using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

namespace UI.GvGPurification3;

public class UI_btn_Pollutant : GButton
{
	public Controller Select;

	public Controller Permit;

	public GImage n8;

	public GImage n12;

	public GLoader frame;

	public GLoader ItemIcon;

	public GTextField CurrentStock;

	public GImage n5;

	public GImage n7;

	public GTextField CanPurifyStock;

	public GImage n9;

	public GGroup n10;

	public const string URL = "ui://v7vqvgvm1146l7";

	public static string Name = "UI_btn_Pollutant";

	private bool _selected;

	public PollutantModel Model { get; set; }

	public bool Selected
	{
		get
		{
			return _selected;
		}
		set
		{
			_selected = value;
			Select.selectedIndex = (_selected ? 1 : 0);
		}
	}

	public static string GetURL()
	{
		return "ui://v7vqvgvm1146l7";
	}

	public static UI_btn_Pollutant CreateInstance()
	{
		return (UI_btn_Pollutant)(object)UIPackage.CreateObject("GvGPurification3", "btn_Pollutant");
	}

	public static UI_btn_Pollutant CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Pollutant).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvm1146l7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Select = ((GComponent)this).GetController("Select");
		Permit = ((GComponent)this).GetController("Permit");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		ItemIcon = (GLoader)((GComponent)this).GetChild("ItemIcon");
		CurrentStock = (GTextField)((GComponent)this).GetChild("CurrentStock");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		CanPurifyStock = (GTextField)((GComponent)this).GetChild("CanPurifyStock");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GGroup)((GComponent)this).GetChild("n10");
	}

	public void Update()
	{
		if (Model != null)
		{
			Selected = true;
			Model.UpdatePurifyNumber();
			Permit.selectedIndex = ((!Model.CanAllPurify) ? 1 : 0);
			((GObject)CurrentStock).text = Model.PollutantItem.cnt.ToString();
			((GObject)CanPurifyStock).text = Model.PermitPurifyNumber.ToString();
		}
	}

	public void Init()
	{
		if (Model != null)
		{
			FGUIManager.Instance.SetItemIconAndFrame(ItemIcon, Model.PollutantItem.ItemId, null, "", frameVisible: false);
		}
	}
}
