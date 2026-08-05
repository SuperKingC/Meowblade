using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;

namespace UI.GvGTalent;

public class UI_btn_Talent : GButton
{
	public Controller Status;

	public Controller Type;

	public Controller button;

	public GLoader Border0;

	public GLoader Border2;

	public GLoader Icon;

	public GImage n4;

	public UI_dec_PointSelectEffect n2;

	public Transition t0;

	public const string URL = "ui://4r1llhd8ran35";

	public static string Name = "UI_btn_Talent";

	private int _idx;

	public GvGTalentUiModel Data => Singleton<GvGTalentsManager>.Instance.GeTalentUiModel(Idx);

	public int Idx => GetIdx();

	public static string GetURL()
	{
		return "ui://4r1llhd8ran35";
	}

	public static UI_btn_Talent CreateInstance()
	{
		return (UI_btn_Talent)(object)UIPackage.CreateObject("GvGTalent", "btn_Talent");
	}

	public static UI_btn_Talent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Talent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8ran35", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Type = ((GComponent)this).GetController("Type");
		button = ((GComponent)this).GetController("button");
		Border0 = (GLoader)((GComponent)this).GetChild("Border0");
		Border2 = (GLoader)((GComponent)this).GetChild("Border2");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n2 = (UI_dec_PointSelectEffect)(object)((GComponent)this).GetChild("n2");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	private int GetIdx()
	{
		if (_idx <= 0)
		{
			_idx = int.Parse(((GObject)this).name.Replace("Talent", string.Empty));
		}
		return _idx;
	}

	public void Init()
	{
		string text = Data?.Icon?.ToPublicResourcesRgbIcon();
		if (!string.IsNullOrEmpty(text))
		{
			Icon.url = text;
		}
		Border0.url = "ui://GvGTalent/" + Data?.Border + "_0";
		Border2.url = "ui://GvGTalent/" + Data?.Border + "_2";
	}
}
