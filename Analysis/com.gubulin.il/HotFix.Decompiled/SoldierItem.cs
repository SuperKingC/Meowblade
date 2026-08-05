using System.Collections.Generic;
using Shift.Legion.Common.Models;
using UnityEngine;
using UnityEngine.UI;

public class SoldierItem : MonoBehaviour
{
	[SerializeField]
	public Image Icon;

	[SerializeField]
	public Text Name;

	[SerializeField]
	public Text Level;

	[SerializeField]
	public Text Remain;

	[SerializeField]
	public Button Button;

	public Dictionary<string, int> RemainDic;

	public Soldier Soldier { get; set; }
}
