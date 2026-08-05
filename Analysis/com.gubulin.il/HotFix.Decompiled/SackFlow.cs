using System.Collections.Generic;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UnityEngine;

public class SackFlow : MonoBehaviour
{
	public string bearing;

	public bool isOpend;

	private float timeNow;

	public float timingStart;

	public Transform startPoint;

	public float timingEnd;

	public float timeUpLimit;

	public float timeDownLimit;

	private void Awake()
	{
		GameController.Contexts.Service<BaseSceneService>().AddMonoBehaviour((MonoBehaviour)(object)this);
	}

	private void Start()
	{
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", OpenOrClose);
		if (bearing == "Up")
		{
			if (GameManagers.Instance.UserArchiveManager.GetBuildingLevel("1") > 0 || GameManagers.Instance.UserArchiveManager.GetBuildingLevel("2") > 0)
			{
				isOpend = true;
			}
			else
			{
				isOpend = false;
			}
		}
		else if (bearing == "Down")
		{
			if (GameManagers.Instance.UserArchiveManager.GetBuildingLevel("3") > 0 || GameManagers.Instance.UserArchiveManager.GetBuildingLevel("12") > 0)
			{
				isOpend = true;
			}
			else
			{
				isOpend = false;
			}
		}
		timingStart = timeDownLimit + 1f;
		timeNow = timingStart;
	}

	private void OnDestroy()
	{
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", OpenOrClose);
	}

	private void Update()
	{
		timeNow -= Time.deltaTime;
		GenerateSack();
	}

	public void OpenOrClose(string buildingType, int level)
	{
		if (bearing == "Up")
		{
			if ((buildingType == "1" || buildingType == "2") && level == 1)
			{
				ScriptApi.CreateTimer(5f, delegate
				{
					isOpend = true;
				});
			}
		}
		else if (bearing == "Down" && (buildingType == "3" || buildingType == "12") && level == 1)
		{
			ScriptApi.CreateTimer(5f, delegate
			{
				isOpend = true;
			});
		}
	}

	private void GenerateSack()
	{
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		if (!(timeNow <= timingEnd))
		{
			return;
		}
		if (isOpend)
		{
			Object obj = Resources.Load("ProductIcon");
			GameObject val = Object.Instantiate<GameObject>((GameObject)(object)((obj is GameObject) ? obj : null), startPoint);
			ProductIconOnTransporter _ProductIconOnTransporter = val.GetComponent<ProductIconOnTransporter>();
			if ((Object)(object)_ProductIconOnTransporter == (Object)null)
			{
				_ProductIconOnTransporter = val.AddComponent<ProductIconOnTransporter>();
			}
			((Behaviour)_ProductIconOnTransporter).enabled = false;
			val.transform.localScale = new Vector3(0.85f, 0.85f, 1f);
			Translate val2 = val.AddComponent<Translate>();
			val2.speed = 2f;
			val2.direction = Vector3.right;
			int num = Random.Range(1, 4);
			string buildingType = ((bearing == "Up") ? "1" : "3");
			_ProductIconOnTransporter.SetSprite(new KeyValuePair<string, int>("sack3", 0), null, buildingType);
			if (bearing == "Down")
			{
				((Renderer)val.gameObject.GetComponent<SpriteRenderer>()).sortingOrder = 2;
			}
			else
			{
				((Renderer)val.gameObject.GetComponent<SpriteRenderer>()).sortingOrder = 0;
			}
			_ProductIconOnTransporter.TronsportSpeed = 0f;
			_ProductIconOnTransporter.iconUiPanel.container.renderMode = (RenderMode)0;
			MeshRenderer component = ((Component)_ProductIconOnTransporter.iconUiPanel.ui.GetChild("icon").displayObject.gameObject.transform.Find("Image")).GetComponent<MeshRenderer>();
			if ((Object)(object)component != (Object)null)
			{
				((Renderer)component).material.renderQueue = 2999;
			}
			ScriptApi.CreateTimer(0.5f, delegate
			{
				((Behaviour)_ProductIconOnTransporter).enabled = true;
			});
		}
		timingStart = Random.Range(timeDownLimit, timeUpLimit);
		timeNow = timingStart;
	}
}
