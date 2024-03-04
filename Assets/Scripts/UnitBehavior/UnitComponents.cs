using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class UnitComponents
{
    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    private SphereCollider _colliderRange;
    [SerializeField]
    private Animator _animator;
    [SerializeField] 
    private GameObject _bomb;
    [SerializeField]
    private LayerMask _enemyMask;
    public NavMeshAgent Agent { get => _agent; set => _agent = value; }
    public Rigidbody Rb { get => _rb; set => _rb = value; }
    public Transform Transform { get => _transform; set => _transform = value; }
    public SphereCollider ColliderRange { get => _colliderRange; set => _colliderRange = value; }
    public Animator Animator { get => _animator; set => _animator = value; }
    public LayerMask EnemyMask { get => _enemyMask; set => _enemyMask = value; }
    public GameObject Bomb { get => _bomb; set => _bomb = value; }
}
