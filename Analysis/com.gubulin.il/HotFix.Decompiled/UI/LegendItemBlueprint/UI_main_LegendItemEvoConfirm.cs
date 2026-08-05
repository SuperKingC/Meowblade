using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.LegendItemBlueprint;

public class UI_main_LegendItemEvoConfirm : GComponent, IUiController
{
	public GGraph back;

	public UI_com_LegendItemEvoConfirm Dialog;

	public Transition t0;

	public const string URL = "ui://h09dvkcgpqzh30";

	public static string Name = "UI_main_LegendItemEvoConfirm";

	private LegendItemUi Instance;

	public static string GetURL()
	{
		return "ui://h09dvkcgpqzh30";
	}

	public static UI_main_LegendItemEvoConfirm CreateInstance()
	{
		return (UI_main_LegendItemEvoConfirm)(object)UIPackage.CreateObject("LegendItemBlueprint", "main_LegendItemEvoConfirm");
	}

	public static UI_main_LegendItemEvoConfirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_LegendItemEvoConfirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgpqzh30", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_LegendItemEvoConfirm)(object)((GComponent)this).GetChild("Dialog");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		object value;
		long num = (parameters.TryGetValue("MainLegendItemId", out value) ? ((long)value) : (-1));
		if (num > -1)
		{
			Instance = LegendItemsHelper.GetLegendItemUi(num);
			RenderIcon();
		}
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)back).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Add(new EventCallback0(ConfirmEvent));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)back).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Remove(new EventCallback0(ConfirmEvent));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderIcon()
	{
		Dialog.EvoLegendItem.AvailableState.selectedIndex = 0;
		Dialog.EvoLegendItem.Type.selectedIndex = 1;
		Dialog.EvoLegendItem.Level.selectedIndex = Instance.LegendItemData.Data.Rarity - 1;
		((GObject)Dialog.EvoLegendItem.SoldierIcon).visible = false;
		Dialog.EvoLegendItem.Icon.LoadArmsIcon(Instance.LegendItemData.Data.Icon);
		((GObject)Dialog.EvoLegendItem.LevelValue).text = Instance.LegendItemData.EnhanceLevel.ToString();
		((GObject)Dialog.EvoLegendItem.name).text = Instance.LegendItemData.Data.Name;
	}

	private void ConfirmEvent()
	{
		SharedMessenger.Broadcast("UPDATE_FORGE_LEGENDITEM", new ForgeSelectLegendItem
		{
			InstanceId = Instance.InstanceId,
			Slot = -1,
			ItemType = 0
		});
		End();
	}
}
