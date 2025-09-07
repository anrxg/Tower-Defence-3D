using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] Rigidbody rb;


    [Header("Refrences")]
    [SerializeField] float bulletSpeed = 50f;
    [SerializeField] int bulletDamage = 1;

    Transform target;

    void FixedUpdate()
    {
        if (!target) return;

        Vector3 direction = (target.position - transform.position).normalized; // get the direction of bullets towards the target
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
            other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
