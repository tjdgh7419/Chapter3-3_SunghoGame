using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimation AnimationData { get; private set; }

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerInput Input { get; private set; } // 내가 만든 인풋액션 값을 가져옴
    public CharacterController Controller { get; private set; } // 추가한 캐릭터 컨트롤러 컴포넌트
}
