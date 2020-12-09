//!
using System;
using UnityEngine;

[Serializable]
public class HealthBonus
{

	[HideInInspector] public GameObject m_Instance;
	[HideInInspector] public int timeout;
	[HideInInspector] public float timestamp;
	[HideInInspector] public bool isTrap = false;
	[HideInInspector] public bool isStun = false;
	private HealthBonusMono mono;

	public void Setup() {
		mono = m_Instance.GetComponent<HealthBonusMono> () as HealthBonusMono;
		if (isTrap)
		{
			m_Instance.name = "Trap";
		}
		else if (isStun)
		{
			m_Instance.name = "Stun";
		}
		else
		{
			m_Instance.name = "Health";
		}
	} //ctor

} //HealthBonus
//^