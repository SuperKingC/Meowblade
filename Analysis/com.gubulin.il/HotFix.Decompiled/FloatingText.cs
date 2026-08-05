using HotFix;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour, IPooled
{
	[SerializeField]
	private Text _text;

	private Color DamageColor = new Color(255f, 50f, 0f);

	private Color GoldColor = new Color(255f, 200f, 0f);

	private Color SideEffectColor = new Color(0f, 50f, 200f);

	private Color HealEffectColor = new Color(0f, 0f, 0f);

	private float _time;

	public int opUniqueId { get; set; }

	public bool Active
	{
		get
		{
			return ((Component)this).gameObject.activeSelf;
		}
		set
		{
			((Component)this).gameObject.SetActive(value);
		}
	}

	public void ShowFloatingText(FloatingTextType type, string text)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		switch (type)
		{
		case FloatingTextType.GenericFloatingText:
			((Graphic)_text).color = Color.white;
			break;
		case FloatingTextType.DamageFloatingText:
			((Graphic)_text).color = DamageColor;
			break;
		case FloatingTextType.GoldFloatingText:
			((Graphic)_text).color = GoldColor;
			break;
		case FloatingTextType.SideEffectFloatingText:
			((Graphic)_text).color = SideEffectColor;
			break;
		case FloatingTextType.HealFloatingText:
			((Graphic)_text).color = HealEffectColor;
			break;
		}
	}

	private void Update()
	{
		if (Time.time > _time)
		{
			SpawnManager.Instance.DestroyPool(((Component)this).gameObject);
		}
	}

	public void UnSpawn()
	{
	}

	public void OnInstantiate()
	{
		_time = Time.time + 1.5f;
	}

	public void OnUnSpawn()
	{
	}
}
