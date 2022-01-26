using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField] private GameObject _ThrustGO;

	public void ThrustON()
	{
		_ThrustGO.SetActive(true);
	}

	public void ThrustOFF()
	{
		_ThrustGO.SetActive(false);
	}
}
