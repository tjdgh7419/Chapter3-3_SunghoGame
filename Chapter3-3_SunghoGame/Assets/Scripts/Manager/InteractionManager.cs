using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInteractable
{
	void OnInteract();
	string GetInteractPrompt();
}
public class InteractionManager : MonoBehaviour
{
	public float checkRate = 0.05f;
	private float lastCheckTime;
	public float maxCheckDistance;
	public LayerMask layerMask;

	private GameObject curInteractGameObject;
	private IInteractable curInteractable;

	public TextMeshProUGUI promptText;
	public Camera camera;
	private void Awake()
	{
		
	}
	private void Start()
	{
		GameManager.Instance.input.PlayerActions.Interact.started += OnInteractInput;
		// Awake에 넣을 시 게임매니저의 실행 순서보다 낮을 수 있어서 되도록이면 Start에 넣어야한다.
	}

	void Update()
	{
		if (Time.time - lastCheckTime > checkRate)
		{
			lastCheckTime = Time.time;

			Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
			{
				if (hit.collider.gameObject != curInteractGameObject)
				{
					curInteractGameObject = hit.collider.gameObject;
					curInteractable = hit.collider.GetComponent<IInteractable>();
					SetPromptText();
				}
			}
			else
			{
				curInteractGameObject = null;
				curInteractable = null;
				promptText.gameObject.SetActive(false);
			}
		}
	}

	private void SetPromptText()
	{
		promptText.gameObject.SetActive(true);
		promptText.text = string.Format("<b>[E]</b> {0}", curInteractable.GetInteractPrompt());
	}

	public void OnInteractInput(InputAction.CallbackContext callbackContext)
	{
		if (callbackContext.phase == InputActionPhase.Started && curInteractable != null)
		{
			promptText.gameObject.SetActive(false);
			curInteractable.OnInteract();
			curInteractGameObject = null;
			curInteractable = null;			
		}
	}
}
