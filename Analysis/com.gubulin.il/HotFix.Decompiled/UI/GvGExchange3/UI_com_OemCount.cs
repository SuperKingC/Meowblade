using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using UnityEngine;

namespace UI.GvGExchange3;

public class UI_com_OemCount : GComponent
{
	public GTextField n35;

	public GImage n30;

	public UI_btn_GetMoreAmplifierFormula AddBtn;

	public UI_btn_ReduceBtn ReduceBtn;

	public UI_btn_MaxBtn MaxBtn;

	public GTextField Count;

	public GTextField MaxCount;

	public const string URL = "ui://tt2iq07odip34x";

	public static string Name = "UI_com_OemCount";

	private const int _MIN_USE_COUNT_INT = 1;

	private const string _MIN_USE_COUNT_STRING = "1";

	private int _realMaxUseCount;

	private int _configMaxUseCount;

	private int MaxUseCount => Mathf.Min(_realMaxUseCount, _configMaxUseCount);

	public int UseCount { get; private set; }

	public static string GetURL()
	{
		return "ui://tt2iq07odip34x";
	}

	public static UI_com_OemCount CreateInstance()
	{
		return (UI_com_OemCount)(object)UIPackage.CreateObject("GvGExchange3", "com_OemCount");
	}

	public static UI_com_OemCount CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OemCount).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odip34x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n35 = (GTextField)((GComponent)this).GetChild("n35");
		string id = "ui://tt2iq07odip34x".Replace("ui://", "") + "-" + ((GObject)n35).id;
		((GObject)n35).text = LanguagesManager.GetDesc(id);
		n30 = (GImage)((GComponent)this).GetChild("n30");
		AddBtn = (UI_btn_GetMoreAmplifierFormula)(object)((GComponent)this).GetChild("AddBtn");
		ReduceBtn = (UI_btn_ReduceBtn)(object)((GComponent)this).GetChild("ReduceBtn");
		MaxBtn = (UI_btn_MaxBtn)(object)((GComponent)this).GetChild("MaxBtn");
		Count = (GTextField)((GComponent)this).GetChild("Count");
		MaxCount = (GTextField)((GComponent)this).GetChild("MaxCount");
	}

	public void Init()
	{
		_configMaxUseCount = OemMissionAmplifierConfigHelper.FormulaOemTaskMax;
		_realMaxUseCount = 1;
		((GObject)MaxCount).text = $"/{_configMaxUseCount}";
		UseCount = 1;
		((GObject)Count).text = "1";
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)AddBtn).onClick.Set(new EventCallback0(OnPlusClick));
		((GObject)ReduceBtn).onClick.Set(new EventCallback0(OnMinusClick));
		((GObject)MaxBtn).onClick.Set(new EventCallback0(OnMaxClick));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)AddBtn).onClick.Clear();
		((GObject)ReduceBtn).onClick.Clear();
		((GObject)MaxBtn).onClick.Clear();
	}

	public void Update(string formulaId)
	{
		UpdateCount(formulaId);
		UpdateBtnEnable();
	}

	private void UpdateCount(string formulaId)
	{
		_realMaxUseCount = GetFormulaCount(formulaId);
		UseCount = MaxUseCount;
		((GObject)Count).text = UseCount.ToString();
	}

	private static int GetFormulaCount(string formulaId)
	{
		GvGAmplifierForgeModel gvGAmplifierData = Singleton<GvGAmplifierManager>.Instance.GvGAmplifierData;
		FormulaCountModel value;
		return (!gvGAmplifierData.FormulaCount_Dict.TryGetValue(formulaId, out value)) ? 1 : value.ScrollCount40;
	}

	private void UpdateBtnEnable()
	{
		((GObject)ReduceBtn).enabled = UseCount > 1;
		((GObject)AddBtn).enabled = UseCount < MaxUseCount;
		((GObject)MaxBtn).enabled = UseCount < MaxUseCount;
	}

	private void OnPlusClick()
	{
		UseCount = Mathf.Min(UseCount + 1, MaxUseCount);
		((GObject)Count).text = UseCount.ToString();
		UpdateBtnEnable();
	}

	private void OnMinusClick()
	{
		UseCount = Mathf.Max(UseCount - 1, 1);
		((GObject)Count).text = UseCount.ToString();
		UpdateBtnEnable();
	}

	private void OnMaxClick()
	{
		UseCount = MaxUseCount;
		((GObject)Count).text = UseCount.ToString();
		UpdateBtnEnable();
	}
}
