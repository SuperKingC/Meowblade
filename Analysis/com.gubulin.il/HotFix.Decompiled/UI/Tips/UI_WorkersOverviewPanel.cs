using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UnityEngine;

namespace UI.Tips;

public class UI_WorkersOverviewPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_DropDownDialog Dialog;

	public GGraph Shielding;

	public Transition ShowDialog;

	public const string URL = "ui://47lbpgx9yzxz3t";

	public static string Name = "UI_WorkersOverviewPanel";

	private List<string> textureList = new List<string>();

	private Dungeon myDungeon;

	private List<KeyValuePair<Building, Dictionary<string, Dictionary<string, ProductionConfig>>>> workerData = new List<KeyValuePair<Building, Dictionary<string, Dictionary<string, ProductionConfig>>>>();

	private Dictionary<string, GButton> ComboBoxButtonList = new Dictionary<string, GButton>();

	private Dictionary<string, Dictionary<string, GButton>> ComboBoxItemButtonList = new Dictionary<string, Dictionary<string, GButton>>();

	private KeyValuePair<string, int> operationalInfo = default(KeyValuePair<string, int>);

	public static string GetURL()
	{
		return "ui://47lbpgx9yzxz3t";
	}

	public static UI_WorkersOverviewPanel CreateInstance()
	{
		return (UI_WorkersOverviewPanel)(object)UIPackage.CreateObject("Tips", "WorkersOverviewPanel");
	}

	public static UI_WorkersOverviewPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WorkersOverviewPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9yzxz3t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_DropDownDialog)(object)((GComponent)this).GetChild("Dialog");
		Shielding = (GGraph)((GComponent)this).GetChild("Shielding");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = (parameters.TryGetValue("Order", out var value) ? ((int)value) : 100);
		myDungeon = GameController.Contexts.game.dungeon.value;
		GetWorkerData();
		ComboBoxListInit();
	}

	public void OnShow()
	{
		ShowDialog.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		SharedMessenger.AddListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateComboBoxItem);
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		SharedMessenger.RemoveListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateComboBoxItem);
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	private void ComboBoxClickEvent(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		UI_ComboBox2 uI_ComboBox = (UI_ComboBox2)(object)((GObject)context.sender).parent;
		if (uI_ComboBox.Status.selectedIndex == 0)
		{
			uI_ComboBox.Status.selectedIndex = 1;
			((GObject)uI_ComboBox).TweenResize(new Vector2(((GObject)uI_ComboBox).width, 76f + ((GObject)uI_ComboBox.ComboList).height), 0.33f);
		}
		else if (uI_ComboBox.Status.selectedIndex == 1)
		{
			uI_ComboBox.Status.selectedIndex = 0;
			((GObject)uI_ComboBox).TweenResize(new Vector2(((GObject)uI_ComboBox).width, 75f), 0.33f);
		}
	}

	private void ComboBoxItemMinusClickEvent(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		tKeyValue<string, Dictionary<string, ProductionConfig>> tKeyValue = (tKeyValue<string, Dictionary<string, ProductionConfig>>)data;
		int num = int.Parse(tKeyValue.Value.First().Key);
		ProductionConfig value = tKeyValue.Value.First().Value;
		myDungeon.AssignManPower(tKeyValue.Key, num, value.ProductList, -1);
		operationalInfo = new KeyValuePair<string, int>(tKeyValue.Key, num);
	}

	private void ComboBoxMinusClickEvent(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string text = ((GObject)context.sender).data.ToString();
		foreach (KeyValuePair<Building, Dictionary<string, Dictionary<string, ProductionConfig>>> workerDatum in workerData)
		{
			if (!(workerDatum.Key.BuildingType == text))
			{
				continue;
			}
			using Dictionary<string, Dictionary<string, ProductionConfig>>.Enumerator enumerator2 = workerDatum.Value.GetEnumerator();
			if (!enumerator2.MoveNext())
			{
				break;
			}
			using Dictionary<string, ProductionConfig>.Enumerator enumerator3 = enumerator2.Current.Value.GetEnumerator();
			if (enumerator3.MoveNext())
			{
				KeyValuePair<string, ProductionConfig> current2 = enumerator3.Current;
				myDungeon.AssignManPower(text, int.Parse(current2.Key), current2.Value.ProductList, -1);
				operationalInfo = new KeyValuePair<string, int>(text, int.Parse(current2.Key));
			}
			break;
		}
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (((GObject)Shielding).touchable)
		{
			return;
		}
		foreach (KeyValuePair<string, Dictionary<string, GButton>> comboBoxItemButton in ComboBoxItemButtonList)
		{
			foreach (KeyValuePair<string, GButton> item in comboBoxItemButton.Value)
			{
				string itemId2 = GDMgr.Get<GDEProductData>(item.Key).ItemId;
				if (itemId == itemId2)
				{
					((GComponent)item.Value).GetChild("name").text = GameManagers.Instance.StockController.GetStock(itemId2).ShortNumberFormat() ?? "";
					return;
				}
			}
		}
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	private void ComboBoxItemButtonDisappear(GButton comboBoxItemBtn, string buildingType, string proId)
	{
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected O, but got Unknown
		List<GButton> list = ComboBoxItemButtonList[buildingType].Values.ToList();
		int index = list.IndexOf(comboBoxItemBtn);
		if (index < 0 || index > list.Count - 1)
		{
			return;
		}
		((GObject)Shielding).touchable = true;
		((GObject)comboBoxItemBtn).relations.ClearAll();
		bool isLast = true;
		GButton nextBtn = null;
		if (index != list.Count - 1)
		{
			((GObject)list[index + 1]).RemoveRelation((GObject)(object)comboBoxItemBtn, (RelationType)9);
			isLast = false;
			nextBtn = list[index + 1];
		}
		UI_ComboBox2 _comboBox = (UI_ComboBox2)(object)ComboBoxButtonList[buildingType];
		ComboBoxItemButtonList[buildingType].Remove(proId);
		((GComponent)comboBoxItemBtn).GetTransition("disappear").Play((PlayCompleteCallback)delegate
		{
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Expected O, but got Unknown
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Expected O, but got Unknown
			//IL_010d: Expected O, but got Unknown
			((GComponent)_comboBox.ComboList).RemoveChild((GObject)(object)comboBoxItemBtn, true);
			List<GButton> _comboBoxItemButtonList = ComboBoxItemButtonList[buildingType].Values.ToList();
			if (!isLast && nextBtn != null)
			{
				int num = _comboBoxItemButtonList.IndexOf(nextBtn);
				if (index >= 0 && index <= _comboBoxItemButtonList.Count - 1)
				{
					if (num == 0)
					{
						GTweener obj = ((GObject)nextBtn).TweenMoveY(0f, 0.3f);
						GTweenCallback val = default(GTweenCallback);
						GTweenCallback obj2 = val;
						if (obj2 == null)
						{
							GTweenCallback val2 = delegate
							{
								((GObject)Shielding).touchable = false;
							};
							GTweenCallback val3 = val2;
							val = val2;
							obj2 = val3;
						}
						obj.OnComplete(obj2);
					}
					else
					{
						((GObject)nextBtn).TweenMoveY((float)(96 * num), 0.3f).OnComplete((GTweenCallback)delegate
						{
							((GObject)nextBtn).AddRelation((GObject)(object)_comboBoxItemButtonList[index - 1], (RelationType)9);
							((GObject)Shielding).touchable = false;
						});
					}
				}
			}
			else
			{
				((GObject)Shielding).touchable = false;
			}
			((GObject)_comboBox.ComboList).SetSize(591f, (float)(_comboBoxItemButtonList.Count * 75 + (_comboBoxItemButtonList.Count - 1) * 21));
			((GObject)_comboBox).TweenResize(new Vector2(591f, ((GObject)_comboBox.ComboList).height + 76f), 0.3f);
		});
	}

	private void ComboBoxButtonDisappear(GButton comboBoxBtn, string buildingType)
	{
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		List<GButton> list = ComboBoxButtonList.Values.ToList();
		int index = list.IndexOf(comboBoxBtn);
		if (index < 0 || index > list.Count - 1)
		{
			return;
		}
		((GObject)Shielding).touchable = true;
		((GObject)comboBoxBtn).relations.ClearAll();
		bool isLast = true;
		GButton nextBtn = null;
		if (index != list.Count - 1)
		{
			((GObject)list[index + 1]).RemoveRelation((GObject)(object)comboBoxBtn, (RelationType)9);
			isLast = false;
			nextBtn = list[index + 1];
		}
		ComboBoxButtonList.Remove(buildingType);
		((GComponent)comboBoxBtn).GetTransition("disappear").Play((PlayCompleteCallback)delegate
		{
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Expected O, but got Unknown
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Expected O, but got Unknown
			//IL_0107: Expected O, but got Unknown
			((GComponent)Dialog.ComboBoxList).RemoveChild((GObject)(object)comboBoxBtn, true);
			if (!isLast && nextBtn != null)
			{
				List<GButton> _comboBoxButtonList = ComboBoxButtonList.Values.ToList();
				int num = _comboBoxButtonList.IndexOf(nextBtn);
				if (index >= 0 && index <= _comboBoxButtonList.Count - 1)
				{
					if (num == 0)
					{
						GTweener obj = ((GObject)nextBtn).TweenMoveY(0f, 0.3f);
						GTweenCallback val = default(GTweenCallback);
						GTweenCallback obj2 = val;
						if (obj2 == null)
						{
							GTweenCallback val2 = delegate
							{
								((GObject)Shielding).touchable = false;
							};
							GTweenCallback val3 = val2;
							val = val2;
							obj2 = val3;
						}
						obj.OnComplete(obj2);
					}
					else
					{
						((GObject)nextBtn).TweenMoveY(((GObject)_comboBoxButtonList[index - 1]).y + ((GObject)_comboBoxButtonList[index - 1]).height + 21f, 0.3f).OnComplete((GTweenCallback)delegate
						{
							((GObject)nextBtn).AddRelation((GObject)(object)_comboBoxButtonList[index - 1], (RelationType)9);
							((GObject)Shielding).touchable = false;
						});
					}
				}
			}
			else
			{
				((GObject)Shielding).touchable = false;
			}
		});
	}

	private void UpdateComboBoxItem(Building building)
	{
		if (!(operationalInfo.Key == building.BuildingType))
		{
			return;
		}
		GetWorkerData();
		Dictionary<string, Dictionary<string, ProductionConfig>> dictionary = new Dictionary<string, Dictionary<string, ProductionConfig>>();
		foreach (KeyValuePair<Building, Dictionary<string, Dictionary<string, ProductionConfig>>> workerDatum in workerData)
		{
			if (workerDatum.Key.BuildingType == operationalInfo.Key)
			{
				dictionary = workerDatum.Value;
				break;
			}
		}
		if (building.Feature == "Mine" || building.Feature == "MoltenCore")
		{
			UI_ComboBox3 uI_ComboBox = (UI_ComboBox3)(object)ComboBoxButtonList[operationalInfo.Key];
			int num = (int)((GObject)uI_ComboBox.num.title).data - 1;
			((GObject)uI_ComboBox.num.title).text = num.ToString();
			((GObject)uI_ComboBox.num.title).data = num;
			if (num <= 0)
			{
				((GObject)uI_ComboBox.MinusBtn).enabled = false;
				ComboBoxButtonDisappear(ComboBoxButtonList[operationalInfo.Key], operationalInfo.Key);
			}
		}
		else
		{
			if (!(building.Feature == "WorkShop"))
			{
				return;
			}
			UI_ComboBox2 uI_ComboBox2 = (UI_ComboBox2)(object)ComboBoxButtonList[operationalInfo.Key];
			int num2 = (int)((GObject)uI_ComboBox2.num.title).data - 1;
			((GObject)uI_ComboBox2.num.title).text = num2.ToString();
			((GObject)uI_ComboBox2.num.title).data = num2;
			Dictionary<string, GButton> dictionary2 = ComboBoxItemButtonList[operationalInfo.Key];
			string[] array = dictionary2.Keys.ToArray();
			for (int num3 = array.Length - 1; num3 >= 0; num3--)
			{
				string key = array[num3];
				UI_ComboBoxItem uI_ComboBoxItem = (UI_ComboBoxItem)(object)dictionary2[array[num3]];
				if (!dictionary.ContainsKey(key))
				{
					((GObject)uI_ComboBoxItem.MinusBtn).enabled = false;
					((GObject)uI_ComboBoxItem.num.title).text = $"{0}";
					if (dictionary.Count <= 0)
					{
						ComboBoxButtonDisappear((GButton)(object)uI_ComboBox2, operationalInfo.Key);
					}
					else
					{
						ComboBoxItemButtonDisappear((GButton)(object)uI_ComboBoxItem, operationalInfo.Key, ((GObject)uI_ComboBoxItem).data.ToString());
					}
				}
				else
				{
					int count = dictionary[key].Count;
					((GObject)uI_ComboBoxItem.num.title).text = $"{count}";
					((GObject)uI_ComboBoxItem.num.title).data = count;
				}
				if (((GObject)uI_ComboBoxItem).data != null && dictionary.ContainsKey(((GObject)uI_ComboBoxItem).data.ToString()))
				{
					((GObject)uI_ComboBoxItem.MinusBtn).data = new tKeyValue<string, Dictionary<string, ProductionConfig>>(operationalInfo.Key, dictionary[((GObject)uI_ComboBoxItem).data.ToString()]);
				}
			}
		}
	}

	private void GetWorkerData()
	{
		Dictionary<Building, Dictionary<string, Dictionary<string, ProductionConfig>>> manPowerAllocation = myDungeon.GetManPowerAllocation();
		workerData.Clear();
		IEnumerable<KeyValuePair<Building, Dictionary<string, Dictionary<string, ProductionConfig>>>> collection = manPowerAllocation.Where((KeyValuePair<Building, Dictionary<string, Dictionary<string, ProductionConfig>>> p) => p.Key.Feature == "WorkShop");
		IEnumerable<KeyValuePair<Building, Dictionary<string, Dictionary<string, ProductionConfig>>>> collection2 = manPowerAllocation.Where((KeyValuePair<Building, Dictionary<string, Dictionary<string, ProductionConfig>>> p) => p.Key.Feature == "Mine");
		IEnumerable<KeyValuePair<Building, Dictionary<string, Dictionary<string, ProductionConfig>>>> collection3 = manPowerAllocation.Where((KeyValuePair<Building, Dictionary<string, Dictionary<string, ProductionConfig>>> p) => p.Key.Feature == "MoltenCore");
		workerData.AddRange(collection);
		workerData.AddRange(collection2);
		workerData.AddRange(collection3);
	}

	private void ComboBoxListInit()
	{
		for (int i = 0; i < workerData.Count; i++)
		{
			RenderComboBox(workerData[i]);
		}
		for (int j = 0; j < ComboBoxButtonList.Count; j++)
		{
			if (j != 0)
			{
				((GObject)ComboBoxButtonList.ToList()[j].Value).AddRelation((GObject)(object)ComboBoxButtonList.ToList()[j - 1].Value, (RelationType)9);
			}
			else
			{
				((GObject)ComboBoxButtonList.ToList()[j].Value).relations.ClearAll();
			}
		}
	}

	private void RenderComboBox(KeyValuePair<Building, Dictionary<string, Dictionary<string, ProductionConfig>>> dicValuePair)
	{
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Expected O, but got Unknown
		if (dicValuePair.Key.Feature == "WorkShop")
		{
			UI_ComboBox2 uI_ComboBox = UI_ComboBox2.CreateInstance();
			((GComponent)Dialog.ComboBoxList).AddChild((GObject)(object)uI_ComboBox);
			((GObject)uI_ComboBox).SetXY(0f, (float)(ComboBoxButtonList.Count * 96));
			ComboBoxButtonList.Add(dicValuePair.Key.BuildingType, (GButton)(object)uI_ComboBox);
			switch (dicValuePair.Key.BuildingType)
			{
			case "4":
				uI_ComboBox.Type.selectedIndex = 0;
				break;
			case "5":
				uI_ComboBox.Type.selectedIndex = 1;
				break;
			case "6":
				uI_ComboBox.Type.selectedIndex = 2;
				break;
			case "8":
				uI_ComboBox.Type.selectedIndex = 4;
				break;
			case "13":
				uI_ComboBox.Type.selectedIndex = 3;
				break;
			default:
				uI_ComboBox.Type.selectedIndex = 0;
				break;
			}
			((GObject)uI_ComboBox.name).text = dicValuePair.Key.Name ?? "";
			int num = 0;
			foreach (KeyValuePair<string, Dictionary<string, ProductionConfig>> item in dicValuePair.Value)
			{
				num += item.Value.Count;
			}
			ComboListInit(dicValuePair.Value, dicValuePair.Key.BuildingType);
			((GObject)uI_ComboBox.num.title).text = $"{num}";
			((GObject)uI_ComboBox.num.title).data = num;
			uI_ComboBox.num.title.strokeColor = Color32.op_Implicit(new Color32(byte.MaxValue, (byte)240, (byte)169, (byte)229));
			((GObject)uI_ComboBox.back).onClick.Set(new EventCallback1(ComboBoxClickEvent));
		}
		else
		{
			if (!(dicValuePair.Key.Feature == "Mine") && !(dicValuePair.Key.Feature == "MoltenCore"))
			{
				return;
			}
			UI_ComboBox3 uI_ComboBox2 = UI_ComboBox3.CreateInstance();
			((GComponent)Dialog.ComboBoxList).AddChild((GObject)(object)uI_ComboBox2);
			((GObject)uI_ComboBox2).SetXY(0f, (float)(ComboBoxButtonList.Count * 96));
			ComboBoxButtonList.Add(dicValuePair.Key.BuildingType, (GButton)(object)uI_ComboBox2);
			switch (dicValuePair.Key.BuildingType)
			{
			case "1":
				uI_ComboBox2.Type.selectedIndex = 0;
				break;
			case "2":
				uI_ComboBox2.Type.selectedIndex = 1;
				break;
			case "3":
				uI_ComboBox2.Type.selectedIndex = 2;
				break;
			case "12":
				uI_ComboBox2.Type.selectedIndex = 3;
				break;
			case "17":
				uI_ComboBox2.Type.selectedIndex = 4;
				break;
			default:
				uI_ComboBox2.Type.selectedIndex = 0;
				break;
			}
			((GObject)uI_ComboBox2.name).text = dicValuePair.Key.Name ?? "";
			int num2 = 0;
			foreach (KeyValuePair<string, Dictionary<string, ProductionConfig>> item2 in dicValuePair.Value)
			{
				num2 += item2.Value.Count;
			}
			((GObject)uI_ComboBox2.num.title).text = $"{num2}";
			((GObject)uI_ComboBox2.num.title).data = num2;
			uI_ComboBox2.num.title.strokeColor = Color32.op_Implicit(new Color32(byte.MaxValue, (byte)240, (byte)169, (byte)229));
			((GObject)uI_ComboBox2.MinusBtn).data = dicValuePair.Key.BuildingType;
			((GObject)uI_ComboBox2.MinusBtn).onClick.Set(new EventCallback1(ComboBoxMinusClickEvent));
		}
	}

	private void ComboListInit(Dictionary<string, Dictionary<string, ProductionConfig>> dicValuePair, string buildingType)
	{
		int num = 0;
		Dictionary<string, GButton> prOButtons = new Dictionary<string, GButton>();
		foreach (string key in dicValuePair.Keys)
		{
			tKeyValue<string, Dictionary<string, ProductionConfig>> tKeyValue = new tKeyValue<string, Dictionary<string, ProductionConfig>>();
			tKeyValue.Key = key;
			tKeyValue.Value = dicValuePair[key];
			RenderComboBoxItem(tKeyValue, buildingType, num, ref prOButtons);
			num++;
		}
		ComboBoxItemButtonList.Add(buildingType, prOButtons);
		((GObject)((GComponent)ComboBoxButtonList[buildingType]).GetChild("ComboList").asCom).SetSize(591f, (float)(ComboBoxItemButtonList[buildingType].Count * 75 + (ComboBoxItemButtonList[buildingType].Count - 1) * 21));
		int num2 = 0;
		foreach (KeyValuePair<string, GButton> item in ComboBoxItemButtonList[buildingType])
		{
			if (num2 != 0)
			{
				((GObject)item.Value).AddRelation((GObject)(object)ComboBoxItemButtonList[buildingType].ToList()[num2 - 1].Value, (RelationType)9);
			}
			else
			{
				((GObject)item.Value).relations.ClearAll();
			}
			num2++;
		}
	}

	private void RenderComboBoxItem(tKeyValue<string, Dictionary<string, ProductionConfig>> dicValuePair, string buildingType, int index, ref Dictionary<string, GButton> prOButtons)
	{
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		UI_ComboBoxItem uI_ComboBoxItem = UI_ComboBoxItem.CreateInstance();
		((GComponent)ComboBoxButtonList[buildingType]).GetChild("ComboList").asCom.AddChild((GObject)(object)uI_ComboBoxItem);
		prOButtons.Add(dicValuePair.Key, (GButton)(object)uI_ComboBoxItem);
		((GObject)uI_ComboBoxItem).SetXY(0f, (float)(index * 96));
		string itemId = GDMgr.Get<GDEProductData>(dicValuePair.Key).ItemId;
		((GObject)uI_ComboBoxItem.name).text = GameManagers.Instance.StockController.GetStock(itemId).ShortNumberFormat() ?? "";
		FGUIManager.Instance.SetItemIconAndFrame(uI_ComboBoxItem.icon, itemId, textureList);
		((GObject)uI_ComboBoxItem.num.title).text = $"{dicValuePair.Value.Count}";
		((GObject)uI_ComboBoxItem.num.title).data = dicValuePair.Value.Count;
		uI_ComboBoxItem.num.title.strokeColor = Color32.op_Implicit(new Color32(byte.MaxValue, (byte)240, (byte)169, (byte)229));
		((GObject)uI_ComboBoxItem).data = dicValuePair.Key;
		((GObject)uI_ComboBoxItem.MinusBtn).data = new tKeyValue<string, Dictionary<string, ProductionConfig>>(buildingType, dicValuePair.Value);
		((GObject)uI_ComboBoxItem.MinusBtn).onClick.Set(new EventCallback1(ComboBoxItemMinusClickEvent));
	}
}
