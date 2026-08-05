using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class TopUiCanvas : MonoBehaviour
{
	public static TopUiCanvas Instance;

	private GameObject TipsContainer;

	private Text TipsContent;

	private GameObject _clickEffect;

	private Material _clickMaterial;

	private void Awake()
	{
		Instance = this;
		if ((Object)(object)TipsContainer == (Object)null)
		{
			TipsContainer = ((Component)((Component)this).transform.Find("TipsContainer")).gameObject;
			TipsContent = TipsContainer.GetComponentInChildren<Text>();
			SharedMessenger.AddListener<Exception>("NETWORK_ERROR", OnNetworkError);
		}
		_clickEffect = null;
		LoadClickEffect();
	}

	private async void LoadClickEffect()
	{
		AsyncOperationHandle<GameObject> handler = Addressables.LoadAssetAsync<GameObject>((object)"UIClick/ClickEff");
		await handler.Task;
		_clickEffect = Object.Instantiate<GameObject>(handler.Result, ((Component)this).transform);
		_clickEffect.SetActive(false);
		_clickMaterial = ((Graphic)_clickEffect.GetComponentInChildren<Image>()).material;
	}

	public void AddInputTest()
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		if (GameController.UserAgent == "preview")
		{
			InputTest val = ((Component)this).gameObject.AddComponent<InputTest>();
			GameObject val2 = Object.Instantiate<GameObject>(((Component)TipsContent).gameObject);
			val2.SetActive(true);
			Text component = val2.GetComponent<Text>();
			((Component)component).transform.SetParent(((Component)this).transform);
			((Component)component).transform.localPosition = Vector3.zero;
			val.text = component;
		}
	}

	private void OnDestroy()
	{
		TipsContainer = null;
		SharedMessenger.RemoveListener<Exception>("NETWORK_ERROR", OnNetworkError);
	}

	public void ShowTipsPanel(string tipsContent = null)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		if (!string.IsNullOrEmpty(tipsContent) && !TipsContainer.activeSelf)
		{
			TipsContainer.SetActive(true);
			((Component)TipsContent).gameObject.SetActive(true);
			TipsContent.text = tipsContent;
			TipsContainer.transform.position = new Vector3(0f, 0f, 0f);
			((MonoBehaviour)this).StartCoroutine(HideTipsContainer());
		}
	}

	private IEnumerator HideTipsContainer()
	{
		yield return (object)new WaitForSeconds(3f);
		TipsContainer.SetActive(false);
	}

	public void OnNetworkError(Exception exception)
	{
		if (!((Object)(object)TipsContainer == (Object)null))
		{
			ShowTipsPanel(exception.Message);
		}
	}

	public void ClickEffect(Vector2 pos)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)_clickEffect == (Object)null))
		{
			_clickEffect.SetActive(true);
			pos.y = (float)Screen.height - pos.y;
			_clickEffect.transform.position = Vector2.op_Implicit(pos);
			_clickMaterial.SetFloat("_CustomTime", Time.timeSinceLevelLoad);
		}
	}
}
