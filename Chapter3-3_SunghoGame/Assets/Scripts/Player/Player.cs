using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	[field: Header("References")]
	[field: SerializeField] public PlayerSO Data { get; private set; }

	[field: Header("Animations")]
    [field: SerializeField] public PlayerAnimation AnimationData { get; private set; }

	public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerInput Input { get; set; } // 내가 만든 인풋액션 값을 가져옴
    public CharacterController Controller { get; private set; } // 추가한 캐릭터 컨트롤러 컴포넌트
	public ForceReceiver ForceReceiver { get; private set; }
	private PlayerStateMachine stateMachine;
	private void Awake()
	{
        AnimationData.Initialize(); 

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        Input = GetComponent<PlayerInput>();  
        Controller = GetComponent<CharacterController>();
		stateMachine = new PlayerStateMachine(this);
		ForceReceiver = GetComponent<ForceReceiver>();
	}
	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		stateMachine.ChangeState(stateMachine.idleState);
	}

	private void Update()
	{
		stateMachine.HandleInput();
		stateMachine.Update();	
	}

	private void FixedUpdate()
	{	
		stateMachine.PhysicsUpdate();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "mushroom")
		{
			Resource resource = other.gameObject.GetComponent<Resource>();		
			GameManager.Instance.inventory.AddItem(resource.itemToGive);
			other.gameObject.SetActive(false);
		}
	}

}
