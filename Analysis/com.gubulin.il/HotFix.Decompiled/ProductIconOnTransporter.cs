using System.Collections.Generic;
using Assets.Scripts.UI;
using DG.Tweening;
using FairyGUI;
using UI;
using UI.PublicResources;
using UnityEngine;
using UnityEngine.Rendering;

public class ProductIconOnTransporter : MonoBehaviour
{
	public float TronsportSpeed = 2f;

	public Vector3 PathPoint = new Vector3(0f, 0f, -0.001f);

	public Vector3 direction = new Vector3(3.5f, 0f, 0f);

	public bool isTurn = false;

	public float limitY;

	public float limitZ;

	private string _iconName;

	public UIPanel iconUiPanel;

	private void Awake()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		TronsportSpeed = 2f;
		PathPoint = new Vector3(0f, 0f, -0.001f);
		direction = new Vector3(3.5f, 0f, 0f);
		isTurn = false;
		HotFix_DestroySelf hotFix_DestroySelf = ((Component)this).gameObject.AddComponent<HotFix_DestroySelf>();
		hotFix_DestroySelf.destroyTime = 20f;
		HitArea hitArea = ((Component)this).gameObject.AddComponent<HitArea>();
		hitArea.hitData = new HitArea.HitData();
		hitArea.hitData.name = "Product";
	}

	private void Start()
	{
		limitZ = 0f;
		MoveToBack();
	}

	public void SetSprite(KeyValuePair<string, int> content, Transform popupPoint = null, string buildingType = "3")
	{
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		switch (buildingType)
		{
		default:
			if (!(buildingType == "8"))
			{
				if (buildingType == "4" || buildingType == "5" || buildingType == "6")
				{
					SortingGroup val = ((Component)this).gameObject.AddComponent<SortingGroup>();
					val.sortingLayerName = "Default";
					val.sortingOrder = 1;
				}
				break;
			}
			goto case "1";
		case "1":
		case "2":
		case "13":
		{
			SortingGroup val2 = ((Component)this).gameObject.AddComponent<SortingGroup>();
			val2.sortingLayerName = "Default";
			val2.sortingOrder = 0;
			break;
		}
		}
		iconUiPanel = UiHelper.GetProductLoader(((Component)this).gameObject, content.Key);
		if (popupPoint != null)
		{
			UIPanel uiPanel = ((Component)((Component)popupPoint).transform.Find("ProductionNumShow")).GetComponent<UIPanel>();
			UI_ProductionNumFloating textFloating = UI_ProductionNumFloating.CreateInstance_ILRuntime();
			GTextField asTextField = ((GComponent)textFloating).GetChild("Title").asTextField;
			TextFormat textFormat = asTextField.textFormat;
			textFormat.size = 38;
			textFormat.color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, (byte)0, byte.MaxValue));
			asTextField.textFormat = textFormat;
			((GComponent)textFloating).GetChild("Title").text = $"+{content.Value}";
			uiPanel.ui.AddChild((GObject)(object)textFloating);
			GObject child = uiPanel.ui.GetChild("line1");
			((GObject)textFloating).SetXY(child.x, child.y);
			textFloating.DisAppear.Play((PlayCompleteCallback)delegate
			{
				uiPanel.ui.RemoveChild((GObject)(object)textFloating, true);
			});
		}
	}

	public void DestroyMyself()
	{
		Object.Destroy((Object)(object)((Component)this).gameObject);
	}

	public void MoveToBack()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		if (!isTurn)
		{
			PathPoint += direction;
			TweenSettingsExtensions.OnComplete<Tweener>(TweenSettingsExtensions.SetEase<Tweener>(TweenSettingsExtensions.SetSpeedBased<Tweener>(ShortcutExtensions.DOLocalMove(((Component)this).gameObject.transform, PathPoint, TronsportSpeed, false), true), (Ease)1), new TweenCallback(MoveToUP));
		}
	}

	public void MoveToUP()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		if (!isTurn)
		{
			PathPoint += direction;
			TweenSettingsExtensions.OnComplete<Tweener>(TweenSettingsExtensions.SetEase<Tweener>(TweenSettingsExtensions.SetSpeedBased<Tweener>(ShortcutExtensions.DOLocalMove(((Component)this).gameObject.transform, PathPoint, TronsportSpeed, false), true), (Ease)1), new TweenCallback(MoveToBack));
		}
	}

	private void Update()
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		if (isTurn)
		{
			((Component)this).gameObject.transform.Translate(((Component)this).transform.right * Time.deltaTime * TronsportSpeed);
			((Component)this).gameObject.transform.position = new Vector3(((Component)this).gameObject.transform.position.x, limitY, ((Component)this).gameObject.transform.position.z);
		}
		if (((Component)this).gameObject.transform.position.x > -0.2f)
		{
			if ((Object)(object)iconUiPanel != (Object)null)
			{
			}
			Object.Destroy((Object)(object)((Component)this).gameObject);
		}
	}

	private void OnTriggerEnter(Collider collider)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		if (((Object)((Component)collider).gameObject).name == "TurnWall")
		{
			limitY = ((Component)collider).gameObject.transform.position.y;
			PathPoint = default(Vector3);
			if (limitZ != 0f)
			{
				((Component)this).gameObject.transform.localPosition = new Vector3(((Component)this).gameObject.transform.localPosition.x, ((Component)this).gameObject.transform.localPosition.y, limitZ);
			}
			isTurn = true;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		if (((Object)((Component)other).gameObject).name == "TurnWall")
		{
			limitY = ((Component)other).gameObject.transform.position.y;
			PathPoint = default(Vector3);
			if (limitZ != 0f)
			{
				((Component)this).gameObject.transform.localPosition = new Vector3(((Component)this).gameObject.transform.localPosition.x, ((Component)this).gameObject.transform.localPosition.y, limitZ);
			}
			isTurn = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (!(((Object)((Component)other).gameObject).name == "TurnWall"))
		{
		}
	}

	private void ReplaceSprite()
	{
		int num = Random.Range(0, 100);
		if (num > 50)
		{
			((Component)this).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Item/sack3");
		}
	}
}
