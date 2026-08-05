using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;

namespace UI.GvGTalent;

public class UI_com_Line : GComponent
{
	public Controller Status;

	public GImage n2;

	public GImage n3;

	public GImage n5;

	public GLoader Icon;

	public Transition t0;

	public const string URL = "ui://4r1llhd8xohkm";

	public static string Name = "UI_com_Line";

	private GvGTalentLine _lineData;

	public static string GetURL()
	{
		return "ui://4r1llhd8xohkm";
	}

	public static UI_com_Line CreateInstance()
	{
		return (UI_com_Line)(object)UIPackage.CreateObject("GvGTalent", "com_Line");
	}

	public static UI_com_Line CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Line).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8xohkm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void LineInit(GvGTalentLine lineData)
	{
		_lineData = lineData;
		((GObject)this).height = lineData.Length;
		((GObject)this).rotation = lineData.Rotation;
		Status.selectedIndex = 1;
		((GObject)this).x = lineData.X;
		((GObject)this).y = lineData.Y;
		((GObject)this).visible = _lineData.SmallerIdx != 0;
		if (_lineData.SmallerIdx != 0)
		{
			GvGTalentUiModel gvGTalentUiModel = Singleton<GvGTalentsManager>.Instance.GeTalentUiModel(_lineData.SmallerIdx);
			GvGTalentUiModel gvGTalentUiModel2 = Singleton<GvGTalentsManager>.Instance.GeTalentUiModel(_lineData.LargerIdx);
			int num = gvGTalentUiModel.Type & gvGTalentUiModel2.Type;
			Icon.url = $"ui://GvGTalent/GvGLine_{num}";
		}
	}

	public void UpdateLineStatus()
	{
		if (_lineData == null)
		{
			return;
		}
		Status.selectedIndex = (int)_lineData.GetState();
		if (Status.selectedIndex == 2)
		{
			GvGTalentUiModel gvGTalentUiModel = Singleton<GvGTalentsManager>.Instance.GeTalentUiModel(_lineData.SmallerIdx);
			GvGTalentUiModel gvGTalentUiModel2 = Singleton<GvGTalentsManager>.Instance.GeTalentUiModel(_lineData.LargerIdx);
			((GComponent)this).GetTransition("t0").Play(-1, 0f, 0f, -1f, (PlayCompleteCallback)null);
			if (!gvGTalentUiModel.Effective || gvGTalentUiModel2.Effective)
			{
				((GObject)this).rotation = ((GObject)this).rotation + 180f;
			}
		}
	}
}
