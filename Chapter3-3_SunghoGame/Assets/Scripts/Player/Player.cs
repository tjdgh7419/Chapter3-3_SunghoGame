using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimation AnimationData { get; private set; }

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerInput Input { get; private set; } // ���� ���� ��ǲ�׼� ���� ������
    public CharacterController Controller { get; private set; } // �߰��� ĳ���� ��Ʈ�ѷ� ������Ʈ
}
