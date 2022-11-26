using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace Arkanoid.UI
{
    public class ChoseSceneButton : MonoBehaviour
    {
		#region SERIALIZABLE FIELDS
		[SerializeField] private Button button;
		[SerializeField] private TMP_Text text;
		#endregion

		public void Initialize(int sceneNumber, UnityAction<int> onSceneChosen)
		{
			text.SetText(sceneNumber.ToString());
			button.onClick.AddListener(() => onSceneChosen.Invoke(sceneNumber - 1));
		}
	}
}