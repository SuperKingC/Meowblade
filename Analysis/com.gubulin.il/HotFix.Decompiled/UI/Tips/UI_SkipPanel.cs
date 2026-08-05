using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;
using UI.Guide;
using UI.Plot;

namespace UI.Tips;

public class UI_SkipPanel : GComponent, IUiController
{
	public GImage skipWindowBack;

	public GImage n16;

	public GTextField skipTipText1;

	public GTextField skipTipText2;

	public GButton yesBtn;

	public GButton noBtn;

	public GGroup RightGroup;

	public GGraph n18;

	public GTextField guideName;

	public GImage n17;

	public GGroup LeftGroup;

	public GGroup mainGroup;

	public Transition t0;

	public const string URL = "ui://47lbpgx9ot91x";

	public static string Name = "UI_SkipPanel";

	private IUiController parentPanel;

	public static string GetURL()
	{
		return "ui://47lbpgx9ot91x";
	}

	public static UI_SkipPanel CreateInstance()
	{
		return (UI_SkipPanel)(object)UIPackage.CreateObject("Tips", "SkipPanel");
	}

	public static UI_SkipPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SkipPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9ot91x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		skipWindowBack = (GImage)((GComponent)this).GetChild("skipWindowBack");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		skipTipText1 = (GTextField)((GComponent)this).GetChild("skipTipText1");
		string id = "ui://47lbpgx9ot91x".Replace("ui://", "") + "-" + ((GObject)skipTipText1).id;
		((GObject)skipTipText1).text = LanguagesManager.GetDesc(id);
		skipTipText2 = (GTextField)((GComponent)this).GetChild("skipTipText2");
		string id2 = "ui://47lbpgx9ot91x".Replace("ui://", "") + "-" + ((GObject)skipTipText2).id;
		((GObject)skipTipText2).text = LanguagesManager.GetDesc(id2);
		yesBtn = (GButton)((GComponent)this).GetChild("yesBtn");
		noBtn = (GButton)((GComponent)this).GetChild("noBtn");
		RightGroup = (GGroup)((GComponent)this).GetChild("RightGroup");
		n18 = (GGraph)((GComponent)this).GetChild("n18");
		guideName = (GTextField)((GComponent)this).GetChild("guideName");
		string id3 = "ui://47lbpgx9ot91x".Replace("ui://", "") + "-" + ((GObject)guideName).id;
		((GObject)guideName).text = LanguagesManager.GetDesc(id3);
		n17 = (GImage)((GComponent)this).GetChild("n17");
		LeftGroup = (GGroup)((GComponent)this).GetChild("LeftGroup");
		mainGroup = (GGroup)((GComponent)this).GetChild("mainGroup");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 109;
		parentPanel = (IUiController)parameters["Parent"];
		if (parentPanel is UI_Guide)
		{
			((GObject)skipTipText1).text = LanguagesManager.GetDesc("CsharpCodeZhTcText602") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText603") + "？";
			((GObject)skipTipText2).visible = true;
		}
		else if (parentPanel is UI_PlotDialog)
		{
			((GObject)skipTipText1).text = LanguagesManager.GetDesc("CsharpCodeZhTcText602") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText604") + "？";
			((GObject)skipTipText2).visible = false;
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)yesBtn).onClick.Add(new EventCallback0(YesBtnClick));
		((GObject)noBtn).onClick.Add(new EventCallback0(NoBtnClick));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)yesBtn).onClick.Remove(new EventCallback0(YesBtnClick));
		((GObject)noBtn).onClick.Remove(new EventCallback0(NoBtnClick));
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void YesBtnClick()
	{
		if (parentPanel is UI_Guide uI_Guide)
		{
			uI_Guide.YesSkip();
			uI_Guide.End();
		}
		else if (parentPanel is UI_PlotDialog uI_PlotDialog)
		{
			uI_PlotDialog.End();
		}
		End();
	}

	private void NoBtnClick()
	{
		if (parentPanel is UI_Guide)
		{
			((UI_Guide)parentPanel).NoSkip();
		}
		End();
	}
}
