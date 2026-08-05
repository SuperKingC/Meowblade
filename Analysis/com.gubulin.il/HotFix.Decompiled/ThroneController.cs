using System;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UnityEngine;
using UnityEngine.Playables;

public class ThroneController : MonoBehaviour
{
	public GameObject DoomArtifact;

	public GameObject SlaveryArtifact;

	public GameObject DominionArtifact;

	public GameObject Crystal;

	public GameObject FlashingArtifact;

	public PlayableDirector Director;

	public float CrystalAlpah = 1f;

	private void Awake()
	{
		GameController.Contexts.Service<BaseSceneService>().AddMonoBehaviour((MonoBehaviour)(object)this);
	}

	private void Start()
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		Director = ((Component)this).gameObject.GetComponent<PlayableDirector>();
		SharedMessenger.AddListener<string, int>("TECH_UPGRADED", UpdateArtifact);
		InitArtifact();
		CrystalAlpah = ((Renderer)Crystal.GetComponent<SpriteRenderer>()).material.color.a;
		((Behaviour)Director).enabled = false;
		AssetsManager.Instance.LoadAsset<Sprite>("crystal").Then((Action<Sprite>)delegate(Sprite asset)
		{
			Crystal.GetComponent<SpriteRenderer>().sprite = asset;
		});
	}

	private void OnDestroy()
	{
		SharedMessenger.RemoveListener<string, int>("TECH_UPGRADED", UpdateArtifact);
	}

	private void Update()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		if (Mathf.Abs(CrystalAlpah - ((Renderer)Crystal.GetComponent<SpriteRenderer>()).material.color.a) > float.Epsilon)
		{
			((Renderer)Crystal.GetComponent<SpriteRenderer>()).material.color = new Color(((Renderer)Crystal.GetComponent<SpriteRenderer>()).material.color.r, ((Renderer)Crystal.GetComponent<SpriteRenderer>()).material.color.g, ((Renderer)Crystal.GetComponent<SpriteRenderer>()).material.color.b, CrystalAlpah);
		}
	}

	public void SetDirectorStatus(bool _enabled)
	{
		if (_enabled)
		{
			Director.initialTime = 10.0;
			((Behaviour)Director).enabled = true;
		}
		else
		{
			Director.initialTime = 0.0;
			((Behaviour)Director).enabled = false;
		}
	}

	private void InitArtifact()
	{
		AssetsManager.Instance.LoadAsset<Sprite>("sword").Then((Action<Sprite>)delegate(Sprite asset)
		{
			DoomArtifact.GetComponent<SpriteRenderer>().sprite = asset;
		});
		AssetsManager.Instance.LoadAsset<Sprite>("crown").Then((Action<Sprite>)delegate(Sprite asset)
		{
			DominionArtifact.GetComponent<SpriteRenderer>().sprite = asset;
		});
		AssetsManager.Instance.LoadAsset<Sprite>("eye").Then((Action<Sprite>)delegate(Sprite asset)
		{
			SlaveryArtifact.GetComponent<SpriteRenderer>().sprite = asset;
		});
		if (GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.DoomTechnologies[0]) > 0)
		{
			DoomArtifact.SetActive(true);
		}
		if (GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.DominionTechnologies[0]) > 0)
		{
			DominionArtifact.SetActive(true);
		}
		if (GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.SlaveryTechnologies[0]) > 0)
		{
			SlaveryArtifact.SetActive(true);
		}
	}

	private void UpdateArtifact(string artifactKey, int artifactLevelAfterCheck)
	{
		if (artifactKey == TechnologyManager.DoomArtifactKey)
		{
			if (artifactLevelAfterCheck > 0)
			{
				DoomArtifact.SetActive(true);
			}
		}
		else if (artifactKey == TechnologyManager.SlaveryArtifactKey)
		{
			if (artifactLevelAfterCheck > 0)
			{
				SlaveryArtifact.SetActive(true);
			}
		}
		else if (artifactKey == TechnologyManager.DominionArtifactKey && artifactLevelAfterCheck > 0)
		{
			DominionArtifact.SetActive(true);
		}
	}
}
