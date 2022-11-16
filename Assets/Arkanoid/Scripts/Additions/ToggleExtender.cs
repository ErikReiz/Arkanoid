using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.Addons
{
	[RequireComponent(typeof(Toggle))]
	public class ToggleExtender : MonoBehaviour
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private GameObject whenTurnedOn;
		[SerializeField] private GameObject whenTurnedOff;
		#endregion

		#region FIELDS
		private Toggle toggle;
		#endregion

		private void Awake()
		{
			toggle = GetComponent<Toggle>();
			ChangeState(toggle.enabled);
		}

		private void OnEnable()
		{
			toggle.onValueChanged.AddListener(ChangeState);
		}

		private void ChangeState(bool isOn)
		{
			if(isOn)
			{
				whenTurnedOn.SetActive(true);
				whenTurnedOff.SetActive(false);
			}
			else
			{
				whenTurnedOn.SetActive(false);
				whenTurnedOff.SetActive(true);
			}
		}
	}
}