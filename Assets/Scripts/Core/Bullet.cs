using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] Rigidbody rb;


    [Header("Refrences")]
    [SerializeField] float bulletSpeed = 50f;
    [SerializeField] float bulletDamage;

    Transform target;

    void FixedUpdate()
    {
        if (!target) return;

        Vector3 direction = (target.position - transform.position).normalized;
        rb.linearVelocity = direction * bulletSpeed;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
