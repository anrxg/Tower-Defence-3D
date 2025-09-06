using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] Rigidbody rb;

    [Header("Attributes")]
    [SerializeField] float moveSpeed;
    [SerializeField] float health = 100;
    [SerializeField] float damage;

    Transform targetPoint; // the point where the enemy will move next
    int pathIndex = 0;  // current point at which the enemy is present

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }
    void Start()
    {
        targetPoint = GameManager.instance.paths[pathIndex];
    }

    void Update()
    {
        if (Vector3.Distance(targetPoint.position, transform.position) <= 0.5f)
        {
            pathIndex++; // If enemy is away from target point then go to that 

            if (pathIndex == GameManager.instance.paths.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                targetPoint = GameManager.instance.paths[pathIndex];
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 direction = (targetPoint.position - transform.position).normalized; // calculating which way to go
        rb.linearVelocity = direction * moveSpeed;
    }
}
