using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UnityEngine;

namespace UI.DebrisCompound;

public class UI_DebrisCompoundPanel : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Action<GameObject> _003C_003E9__20_0;

		public static GTweenCallback _003C_003E9__25_2;

		internal void _003CShowMainCrad_003Eb__20_0(GameObject explosion)
		{
			explosion.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
		}

		internal void _003CPlayCardOverturn_003Eb__25_2()
		{
		}
	}

	public Controller PageController;

	public GGraph blackMask;

	public UI_cardLoaderBtn mainCard;

	public GGraph slideFloor;

	public UI_ResultDialog ResultDialog;

	public GGraph whiteMask;

	public Transition excessive;

	public const string URL = "ui://6n2woz97o4kt8";

	public static string Name = "UI_DebrisCompoundPanel";

	private List<string> textureList = new List<string>();

	private SwipeGesture _swipeGesture;

	private KeyValuePair<Vector2, Vector2> aimPosPair = default(KeyValuePair<Vector2, Vector2>);

	private Bonus mainBonus;

	private List<Tuple<string, Dictionary<string, object>, bool>> cardOverturnParams = new List<Tuple<string, Dictionary<string, object>, bool>>();

	private List<KeyValuePair<string, float>> resultBonuses = new List<KeyValuePair<string, float>>();

	public static string GetURL()
	{
		return "ui://6n2woz97o4kt8";
	}

	public static UI_DebrisCompoundPanel CreateInstance()
	{
		return (UI_DebrisCompoundPanel)(object)UIPackage.CreateObject("DebrisCompound", "DebrisCompoundPanel");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		blackMask = (GGraph)((GComponent)this).GetChild("blackMask");
		mainCard = (UI_cardLoaderBtn)(object)((GComponent)this).GetChild("mainCard");
		slideFloor = (GGraph)((GComponent)this).GetChild("slideFloor");
		ResultDialog = (UI_ResultDialog)(object)((GComponent)this).GetChild("ResultDialog");
		whiteMask = (GGraph)((GComponent)this).GetChild("whiteMask");
		excessive = ((GComponent)this).GetTransition("excessive");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		((GObject)this).SetXY(0f, 0f);
		((GObject)this).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		if (parameters.TryGetValue("MainCard", out var value))
		{
			mainBonus = (Bonus)value;
		}
		else
		{
			Debug.LogWarning((object)"没有获取到bonus");
			End();
		}
		FGUIManager.Instance.DebrisCompoundPanel = this;
		PageController.selectedIndex = 0;
		RenderMainCard();
		RenderResultList();
		((GComponent)(object)this).SetTimeout(0.2f).OnComplete((GTweenCallback)delegate
		{
			PageController.selectedIndex = 1;
			ShowMainCrad();
		});
	}

	public void OnShow()
	{
		SetAimPos();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		_swipeGesture = new SwipeGesture((GObject)(object)slideFloor);
		_swipeGesture.onMove.Add(new EventCallback1(SlideCard));
		((GObject)slideFloor).onClick.Add(new EventCallback1(SlideCard));
		((GObject)ResultDialog.ConfirmBtn).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		_swipeGesture.onMove.Remove(new EventCallback1(SlideCard));
		((GObject)slideFloor).onClick.Remove(new EventCallback1(SlideCard));
		((GObject)ResultDialog.ConfirmBtn).onClick.Remove(new EventCallback0(End));
	}

	private void RenderResultItem(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		Controller controller = ((GComponent)asButton).GetController("PageController");
		string text = "";
		float num = 1f;
		float num2 = 1f;
		string text2 = null;
		if (resultBonuses[index].Key.Contains("Unlock"))
		{
			controller.selectedIndex = 0;
			string soldierId = resultBonuses[index].Key.Split('.')[1];
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
			text = soldier.Name;
			num = resultBonuses[index].Value;
			text2 = soldier.ItemId;
		}
		else if (resultBonuses[index].Key.Contains("PotentialLevel"))
		{
			controller.selectedIndex = 2;
			string soldierId2 = resultBonuses[index].Key.Split('.')[1];
			Soldier soldier2 = GameManagers.Instance.SoldierManager.Get(soldierId2);
			text = soldier2.Name;
			num = resultBonuses[index].Value;
			text2 = soldier2.ItemId;
		}
		else
		{
			controller.selectedIndex = 1;
			text2 = resultBonuses[index].Key;
			text = SchemaIndexHelper.GetNameById(GameManagers.Instance, text2);
			num2 = resultBonuses[index].Value;
		}
		((GComponent)asButton).GetChild("name").text = text;
		((GComponent)asButton).GetChild("num").text = num2.ToString();
		FGUIManager.Instance.SetItemIconAndFrame(((GComponent)asButton).GetChild("icon").asLoader, text2, textureList);
	}

	private void RenderResultList()
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		for (int num = resultBonuses.Count - 1; num >= 0; num--)
		{
			if (resultBonuses[num].Key[0] == 'S' && resultBonuses[num].Key.Length == 4)
			{
				resultBonuses.RemoveAt(num);
			}
		}
		ResultDialog.resultList.itemRenderer = new ListItemRenderer(RenderResultItem);
		ResultDialog.resultList.numItems = resultBonuses.Count;
	}

	private void ShowMainCrad()
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		string sFXName = "card_explosion";
		if (mainBonus.IsShining == 2)
		{
			sFXName = "card_explosion_gold";
		}
		else if (mainBonus.IsShining == 1)
		{
			sFXName = "card_explosion_silver";
		}
		FGUIManager.Instance.AddTextSpecialEffects(((GComponent)mainCard).GetChild("specialEffectsBack").asGraph, sFXName, new Vector3(150f, 150f, 150f), "Default", 0.5f, delegate(GameObject explosion)
		{
			explosion.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
		});
		((GObject)mainCard).alpha = 1f;
		((GObject)mainCard).TweenScale(Vector2.one, 0.33f).SetEase((EaseType)1).OnComplete((GTweenCallback)delegate
		{
			((GObject)mainCard).touchable = true;
		});
	}

	private void RenderMainCard()
	{
		((GObject)mainCard).touchable = true;
		((GObject)mainCard).alpha = 0f;
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		FGUIManager.Instance.DebrisCompoundPanel = null;
	}

	private void SlideCard(EventContext context)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		JudgeTouchCard(context.inputEvent.position);
	}

	private void JudgeTouchCard(Vector2 pos)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = ((GObject)GRoot.inst).GlobalToLocal(new Vector2(pos.x, pos.y));
		if (aimPosPair.Key.x < val.x && aimPosPair.Value.x > val.x && aimPosPair.Key.y < val.y && aimPosPair.Value.y > val.y)
		{
			PlayCardOverturn(cardOverturnParams.First().Item1, cardOverturnParams.First().Item2, cardOverturnParams.First().Item3);
		}
	}

	private void PlayCardOverturn(string cardFront, Dictionary<string, object> dic, bool isNew = true)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		if (!((GObject)mainCard).touchable)
		{
			return;
		}
		((GObject)mainCard).touchable = false;
		GoWrapper val2 = default(GoWrapper);
		((GComponent)mainCard).GetTransition("overturn").Play((PlayCompleteCallback)delegate
		{
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Expected O, but got Unknown
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Expected O, but got Unknown
			//IL_00b6: Expected O, but got Unknown
			float num = 0.5f;
			if (isNew)
			{
				((GObject)((GComponent)mainCard).GetChild("newIcon").asImage).visible = true;
				((GComponent)mainCard).GetTransition("bounce").Play();
				num = 1f;
			}
			GTweener obj = ((GComponent)(object)this).SetTimeout(num);
			object obj2 = _003C_003Ec._003C_003E9__25_2;
			if (obj2 == null)
			{
				GTweenCallback val = delegate
				{
				};
				_003C_003Ec._003C_003E9__25_2 = val;
				obj2 = (object)val;
			}
			obj.OnComplete((GTweenCallback)obj2);
			GTweener obj3 = ((GComponent)(object)this).SetTimeout(num + 0.5f);
			GTweenCallback obj4 = val2;
			if (obj4 == null)
			{
				GTweenCallback val3 = delegate
				{
					PageController.selectedIndex = 2;
				};
				GTweenCallback val4 = val3;
				val2 = val3;
				obj4 = val4;
			}
			obj3.OnComplete(obj4);
		});
		((GComponent)mainCard).GetTransition("overturn").SetHook("middle", (TransitionHook)delegate
		{
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_0241: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_028d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Unknown result type (might be due to invalid IL or missing references)
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a5: Expected O, but got Unknown
			//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
			((GObject)((GComponent)mainCard).GetChild("icon").asLoader).SetScale(-1f, 1f);
			mainCard.icon.url = cardFront;
			GComponent component = ((GComponent)mainCard).GetChild("icon").asLoader.component;
			component.GetChild("soldierGroup").visible = true;
			Soldier soldier = GameManagers.Instance.SoldierManager.Get("S" + ((string)dic["ItemId"]).Substring(3));
			component.GetChild("soldierName").text = soldier.Name;
			component.GetChild("soldierName").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
			Object obj = Object.Instantiate(Resources.Load("SpineTest"));
			GameObject val = (GameObject)(object)((obj is GameObject) ? obj : null);
			SkeletonAnimation animation = val.GetComponent<SkeletonAnimation>();
			int num = (int)dic["PotentialLevel"];
			int potentialLevel = (num + 2) / 2;
			SpawnManager.Instance.LoadSoldierSpine(val, $"{soldier.Id}_skin{potentialLevel}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
			{
				float num2 = asset.GetSkeletonData(true).Height * 0.6f / 100f;
				((SkeletonRenderer)animation).initialSkinName = $"skin{potentialLevel}";
				((SkeletonRenderer)animation).skeletonDataAsset = asset;
				((SkeletonRenderer)animation).Initialize(true);
				animation.AnimationState.AddAnimation(1, "idle", true, 0f);
			});
			component.GetChild("curLevel").asCom.GetController("Level").selectedIndex = num;
			Vector3 zero = Vector3.zero;
			if (soldier.Id == "S001" || soldier.Id == "S002" || soldier.Id == "S003" || soldier.Id == "S004" || soldier.Id == "S035" || soldier.Id == "S038")
			{
				((Vector3)(ref zero))._002Ector(55f, 55f, 55f);
			}
			else
			{
				((Vector3)(ref zero))._002Ector(40f, 40f, 40f);
			}
			val.transform.localScale = zero * 0.58f;
			val.transform.localPosition = -new Vector3(0f, 0f, 0f);
			val.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			val2 = new GoWrapper(val);
			((DisplayObject)val2).SetXY(0f, 0f);
			((DisplayObject)val2).pivot = new Vector2(0.5f, 0.5f);
			component.GetChild("soldier").asGraph.SetNativeObject((DisplayObject)(object)val2);
			((GObject)component.GetChild("soldier").asGraph).SetXY(102f, 244f);
		});
	}

	private void SetAimPos()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		((GObject)mainCard).SetPivot(0f, 0f);
		Vector2 val = ((GObject)mainCard).LocalToRoot(new Vector2(0f, 0f), GRoot.inst);
		aimPosPair = new KeyValuePair<Vector2, Vector2>(val, val + new Vector2(((GObject)mainCard).width, ((GObject)mainCard).height));
		((GObject)mainCard).SetPivot(0.5f, 0.5f);
	}
}
