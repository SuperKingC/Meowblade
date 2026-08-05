using System.Collections.Generic;
using ProtoBuf;

namespace GameDataEditor;

[ProtoContract]
public class GDESoldierData
{
	[ProtoMember(1)]
	public string Key;

	[ProtoMember(2)]
	public string Name;

	[ProtoMember(3)]
	public bool IsPlayer;

	[ProtoMember(4)]
	public int FxSize;

	[ProtoMember(5)]
	public string ParentSoldierId;

	[ProtoMember(6)]
	public string ModelName;

	[ProtoMember(7)]
	public string PrefabPath;

	[ProtoMember(8)]
	public string MiniMapIcon;

	[ProtoMember(9)]
	public string BaseImage;

	[ProtoMember(10)]
	public int Rarity;

	[ProtoMember(11)]
	public string Desc;

	[ProtoMember(12)]
	public string Skin;

	[ProtoMember(13)]
	public string Faction;

	[ProtoMember(14)]
	public string Tags;

	[ProtoMember(15)]
	public float Health;

	[ProtoMember(16)]
	public float HealthPerLevel;

	[ProtoMember(17)]
	public float HealthMultiplier;

	[ProtoMember(18)]
	public float Attack;

	[ProtoMember(19)]
	public float AttackPerLevel;

	[ProtoMember(20)]
	public float AttackMultiplier;

	[ProtoMember(21)]
	public float Defense;

	[ProtoMember(22)]
	public float DefensePerLevel;

	[ProtoMember(23)]
	public float DefenseMultiplier;

	[ProtoMember(24)]
	public int DamageType;

	[ProtoMember(25)]
	public int ArmorType;

	[ProtoMember(26)]
	public float AttackDistance;

	[ProtoMember(27)]
	public int AttackAngle;

	[ProtoMember(28)]
	public float AttackSpeed;

	[ProtoMember(29)]
	public float CriticalChance;

	[ProtoMember(30)]
	public float CriticalDamageModifier;

	[ProtoMember(31)]
	public float HitRate;

	[ProtoMember(32)]
	public float EvasionRate;

	[ProtoMember(33)]
	public float MoveSpeed;

	[ProtoMember(34)]
	public List<string> Abilities = new List<string>();

	[ProtoMember(35)]
	public List<int> AbilityLearning = new List<int>();

	[ProtoMember(36)]
	public string FeatureAbilityLevel;

	[ProtoMember(37)]
	public int PotentialLevel;

	[ProtoMember(38)]
	public float Radius;

	[ProtoMember(39)]
	public float ScaleRatio;

	[ProtoMember(40)]
	public float ShadowScaleRatio;

	[ProtoMember(41)]
	public string AiType;

	[ProtoMember(42)]
	public string ItemID;

	[ProtoMember(43)]
	public float VisionRadius;

	[ProtoMember(44)]
	public string DeadAudioFx;

	[ProtoMember(45)]
	public int DeadAudioFxVolume;
}
