using ProtoBuf;

namespace GameDataEditor;

[ProtoContract]
public class GDEAbilityData
{
	[ProtoMember(1)]
	public string Key;

	[ProtoMember(2)]
	public string Name;

	[ProtoMember(3)]
	public string Icon;

	[ProtoMember(4)]
	public string Description;

	[ProtoMember(5)]
	public string AbilityCategory;

	[ProtoMember(6)]
	public string CoolingTime;

	[ProtoMember(7)]
	public string ScriptName;

	[ProtoMember(8)]
	public bool Visible;

	[ProtoMember(9)]
	public int Priority;

	[ProtoMember(10)]
	public int AbilityType;

	[ProtoMember(11)]
	public int TargetType;

	[ProtoMember(12)]
	public bool Proactive;

	[ProtoMember(13)]
	public int Level;

	[ProtoMember(14)]
	public int MinRange;

	[ProtoMember(15)]
	public int MaxRange;

	[ProtoMember(16)]
	public bool RangeFromUnit;

	[ProtoMember(17)]
	public float Cooldown;

	[ProtoMember(18)]
	public float CooldownReductionMultiplier;

	[ProtoMember(19)]
	public bool Movable;

	[ProtoMember(20)]
	public int Animation;

	[ProtoMember(21)]
	public string AnimationAudioFx;

	[ProtoMember(22)]
	public int AnimationAudioFxVolume;

	[ProtoMember(23)]
	public float AnimationDuration;

	[ProtoMember(24)]
	public bool AnimationBindAttackSpeed;

	[ProtoMember(25)]
	public float AnimationAttackPoint;

	[ProtoMember(26)]
	public int CastAnimation;

	[ProtoMember(27)]
	public bool ShowCastBar;

	[ProtoMember(28)]
	public float CastTime;

	[ProtoMember(29)]
	public bool CastTimeBindAttackSpeed;

	[ProtoMember(30)]
	public bool CanCast;

	[ProtoMember(31)]
	public bool OnStartCasting;

	[ProtoMember(32)]
	public bool OnFinishCasting;

	[ProtoMember(33)]
	public bool OnProjectileHit;

	[ProtoMember(34)]
	public bool OnProjectileHit_SourceEntityDoSomething;

	[ProtoMember(35)]
	public bool OnActivate;

	[ProtoMember(36)]
	public bool OnDeactivate;

	[ProtoMember(37)]
	public bool OnUpdate;

	[ProtoMember(38)]
	public bool OnTick;

	[ProtoMember(39)]
	public bool OnWillHit;

	[ProtoMember(40)]
	public bool OnHit;

	[ProtoMember(41)]
	public bool OnWillBeHit;

	[ProtoMember(42)]
	public bool OnBeHit;

	[ProtoMember(43)]
	public bool OnKill;

	[ProtoMember(44)]
	public bool OnBeKilled;

	[ProtoMember(45)]
	public bool OnDoDamage;

	[ProtoMember(46)]
	public bool OnTakeDamage;

	[ProtoMember(47)]
	public bool OnHealthPointsChanged;

	[ProtoMember(48)]
	public bool OnTakeBuff;

	[ProtoMember(49)]
	public bool OnStacksChanged;

	[ProtoMember(50)]
	public bool OnCreateProjectile;

	[ProtoMember(51)]
	public bool OnCrowdControlChanged;

	[ProtoMember(52)]
	public bool OnAnyUnitTakeBuff;

	[ProtoMember(53)]
	public string OnAnyUnitTakeBuffFilters;

	[ProtoMember(54)]
	public bool OnAnyAbilityStartCasting;

	[ProtoMember(55)]
	public string OnAnyAbilityStartCastingFilters;

	[ProtoMember(56)]
	public bool OnAnyAbilityFinishCasting;

	[ProtoMember(57)]
	public string OnAnyAbilityFinishCastingFilters;

	[ProtoMember(58)]
	public bool OnAnyUnitCreated;

	[ProtoMember(59)]
	public string OnAnyUnitCreatedFilters;

	[ProtoMember(60)]
	public bool OnAnyUnitDead;

	[ProtoMember(61)]
	public string OnAnyUnitDeadFilters;

	[ProtoMember(62)]
	public float P_DamageMultiplier;

	[ProtoMember(63)]
	public float P_ExtraDamageMultiplier;

	[ProtoMember(64)]
	public bool P_IgnoreArmor;

	[ProtoMember(65)]
	public string P_ProjectileId;

	[ProtoMember(66)]
	public string P_ProjectileLaunchBone;

	[ProtoMember(67)]
	public string P_ProjectileLandingBone;

	[ProtoMember(68)]
	public float P_ProjectileRatio;

	[ProtoMember(69)]
	public string P_ProjectileId1;

	[ProtoMember(70)]
	public string P_ProjectileLaunchBone1;

	[ProtoMember(71)]
	public string P_ProjectileLandingBone1;

	[ProtoMember(72)]
	public float P_ProjectileRatio1;

	[ProtoMember(73)]
	public string P_ProjectileId2;

	[ProtoMember(74)]
	public string P_ProjectileLaunchBone2;

	[ProtoMember(75)]
	public string P_ProjectileLandingBone2;

	[ProtoMember(76)]
	public float P_ProjectileRatio2;

	[ProtoMember(77)]
	public string P_ParticleId;

	[ProtoMember(78)]
	public string P_ParticleBone;

	[ProtoMember(79)]
	public int P_ParticleDuration;

	[ProtoMember(80)]
	public int P_ParticleSize;

	[ProtoMember(81)]
	public bool P_ParticleSizeAuto;

	[ProtoMember(82)]
	public string P_ParticleAudioFx;

	[ProtoMember(83)]
	public int P_ParticleAudioFxVolume;

	[ProtoMember(84)]
	public bool P_ParticleAudioFxLoop;

	[ProtoMember(85)]
	public float P_ParticleScale;

	[ProtoMember(86)]
	public string P_ParticleId1;

	[ProtoMember(87)]
	public string P_ParticleBone1;

	[ProtoMember(88)]
	public int P_ParticleDuration1;

	[ProtoMember(89)]
	public int P_ParticleSize1;

	[ProtoMember(90)]
	public bool P_ParticleSizeAuto1;

	[ProtoMember(91)]
	public string P_ParticleAudioFx1;

	[ProtoMember(92)]
	public int P_ParticleAudioFxVolume1;

	[ProtoMember(93)]
	public bool P_ParticleAudioFxLoop1;

	[ProtoMember(94)]
	public float P_ParticleScale1;

	[ProtoMember(95)]
	public string P_ParticleId2;

	[ProtoMember(96)]
	public string P_ParticleBone2;

	[ProtoMember(97)]
	public int P_ParticleDuration2;

	[ProtoMember(98)]
	public int P_ParticleSize2;

	[ProtoMember(99)]
	public bool P_ParticleSizeAuto2;

	[ProtoMember(100)]
	public string P_ParticleAudioFx2;

	[ProtoMember(101)]
	public int P_ParticleAudioFxVolume2;

	[ProtoMember(102)]
	public bool P_ParticleAudioFxLoop2;

	[ProtoMember(103)]
	public float P_ParticleScale2;

	[ProtoMember(104)]
	public string P_ParticleId3;

	[ProtoMember(105)]
	public string P_ParticleBone3;

	[ProtoMember(106)]
	public int P_ParticleDuration3;

	[ProtoMember(107)]
	public int P_ParticleSize3;

	[ProtoMember(108)]
	public bool P_ParticleSizeAuto3;

	[ProtoMember(109)]
	public string P_ParticleAudioFx3;

	[ProtoMember(110)]
	public int P_ParticleAudioFxVolume3;

	[ProtoMember(111)]
	public bool P_ParticleAudioFxLoop3;

	[ProtoMember(112)]
	public float P_ParticleScale3;

	[ProtoMember(113)]
	public string P_BuffId;

	[ProtoMember(114)]
	public string P_BuffId1;

	[ProtoMember(115)]
	public string P_BuffId2;

	[ProtoMember(116)]
	public string P_BuffId3;

	[ProtoMember(117)]
	public string P_BuffId4;

	[ProtoMember(118)]
	public string P_BuffId5;

	[ProtoMember(119)]
	public string P_BuffId6;

	[ProtoMember(120)]
	public string P_BuffId7;

	[ProtoMember(121)]
	public string P_BuffId8;

	[ProtoMember(122)]
	public string P_BuffId9;

	[ProtoMember(123)]
	public string P_AbilityId;

	[ProtoMember(124)]
	public string P_AbilityId1;

	[ProtoMember(125)]
	public string P_AbilityId2;

	[ProtoMember(126)]
	public string P_AbilityId3;

	[ProtoMember(127)]
	public string P_AbilityId4;

	[ProtoMember(128)]
	public string P_AnimationName;

	[ProtoMember(129)]
	public int P_AnimationTrackIndex;

	[ProtoMember(130)]
	public string P_AnimationName1;

	[ProtoMember(131)]
	public int P_AnimationTrackIndex1;

	[ProtoMember(132)]
	public string P_AnimationName2;

	[ProtoMember(133)]
	public int P_AnimationTrackIndex2;

	[ProtoMember(134)]
	public int P_Probability;

	[ProtoMember(135)]
	public int P_Probability1;

	[ProtoMember(136)]
	public int P_Probability2;

	[ProtoMember(137)]
	public int P_Range;

	[ProtoMember(138)]
	public int P_Range1;

	[ProtoMember(139)]
	public float P_DashSpeed;

	[ProtoMember(140)]
	public int P_DashDistance;

	[ProtoMember(141)]
	public float P_KnockupSpeed;

	[ProtoMember(142)]
	public float P_KnockbackSpeed;

	[ProtoMember(143)]
	public int P_KnockbackDistance;

	[ProtoMember(144)]
	public float P_JumpSpeed;

	[ProtoMember(145)]
	public int P_JumpDistance;

	[ProtoMember(146)]
	public float P_JumpHeightRatio;

	[ProtoMember(147)]
	public int P_Num;

	[ProtoMember(148)]
	public int P_MaxTimes;

	[ProtoMember(149)]
	public int P_Duration;

	[ProtoMember(150)]
	public int P_TickInterval;

	[ProtoMember(151)]
	public string P_CrowdControl;

	[ProtoMember(152)]
	public int P_CrowdControlDuration;

	[ProtoMember(153)]
	public string P_AbilityDurationMultiplier;

	[ProtoMember(154)]
	public string P_AbilityEffectMultiplier;

	[ProtoMember(155)]
	public int P_ShieldType;

	[ProtoMember(156)]
	public float P_ShieldValue;

	[ProtoMember(157)]
	public string P_CreateUnitId;

	[ProtoMember(158)]
	public float P_CreateUnitInheritPercentage;

	[ProtoMember(159)]
	public string P_DamageType;

	[ProtoMember(160)]
	public string P_AttackFlags;

	[ProtoMember(161)]
	public string B_Flags;

	[ProtoMember(162)]
	public int B_Duration;

	[ProtoMember(163)]
	public int B_MaxNum;

	[ProtoMember(164)]
	public int B_Stacks;

	[ProtoMember(165)]
	public int B_MaxStacks;

	[ProtoMember(166)]
	public int B_MergeStrategy;

	[ProtoMember(167)]
	public int B_MergeType;

	[ProtoMember(168)]
	public bool B_MergeStacksRefreshDuration;

	[ProtoMember(169)]
	public bool B_MergeStacksRefreshParticle;

	[ProtoMember(170)]
	public int B_ObsoleteType;

	[ProtoMember(171)]
	public float B_StackEffectMultiplier;

	[ProtoMember(172)]
	public string B_AttackPower;

	[ProtoMember(173)]
	public string B_AttackSpeed;

	[ProtoMember(174)]
	public string B_MoveSpeed;

	[ProtoMember(175)]
	public string B_DefensePower;

	[ProtoMember(176)]
	public string B_HealthPoints;

	[ProtoMember(177)]
	public string B_CriticalChance;

	[ProtoMember(178)]
	public string B_CriticalDamage;

	[ProtoMember(179)]
	public string B_EvasionRate;

	[ProtoMember(180)]
	public string B_AccuracyRate;

	[ProtoMember(181)]
	public string B_Size;

	[ProtoMember(182)]
	public string B_CooldownReduction;

	[ProtoMember(183)]
	public string B_LifeSteal;

	[ProtoMember(184)]
	public string B_MagicVamp;

	[ProtoMember(185)]
	public string B_AttackRange;

	[ProtoMember(186)]
	public string B_DamageReflect;

	[ProtoMember(187)]
	public string B_HurtSettlement;

	[ProtoMember(188)]
	public string B_FireHurt;

	[ProtoMember(189)]
	public string B_IceHurt;

	[ProtoMember(190)]
	public string B_NatureHurt;

	[ProtoMember(191)]
	public string B_ShadowHurt;

	[ProtoMember(192)]
	public string B_HolyHurt;

	[ProtoMember(193)]
	public string B_SpiritHurt;

	[ProtoMember(194)]
	public string B_DamageSettlement;

	[ProtoMember(195)]
	public string B_FireDamage;

	[ProtoMember(196)]
	public string B_IceDamage;

	[ProtoMember(197)]
	public string B_NatureDamage;

	[ProtoMember(198)]
	public string B_ShadowDamage;

	[ProtoMember(199)]
	public string B_HolyDamage;

	[ProtoMember(200)]
	public string B_SpiritDamage;

	[ProtoMember(201)]
	public string B_CureSettlement;

	[ProtoMember(202)]
	public string B_RecoverSettlement;

	[ProtoMember(203)]
	public string DR_Normal;

	[ProtoMember(204)]
	public string DR_FireHurt;

	[ProtoMember(205)]
	public string DR_IceHurt;

	[ProtoMember(206)]
	public string DR_NatureHurt;

	[ProtoMember(207)]
	public string DR_ShadowHurt;

	[ProtoMember(208)]
	public string DR_HolyHurt;

	[ProtoMember(209)]
	public string DR_SpiritHurt;

	[ProtoMember(210)]
	public float P_IgnoreDefensePower;

	[ProtoMember(211)]
	public float PredictiveVisioin;
}
