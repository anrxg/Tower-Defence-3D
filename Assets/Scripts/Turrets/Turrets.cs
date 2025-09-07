using UnityEngine;
using UnityEditor;

public class Turrets : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] LayerMask enemyMask;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firingPoint;

    [Header("Attributes")]
    [SerializeField] float firingRange = 5f;
    [SerializeField] float fireRate = 1f; //Bullets per second
    Transform target;
    float timeUntilNextFire;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, firingRange);
    }

    void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilNextFire += Time.deltaTime;
            if (timeUntilNextFire >= (1f / fireRate))
            {
                Shoot();
                timeUntilNextFire = 0f;
            }
        }

    }

    void FindTarget()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, firingRange, (Vector3)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform; // if it its a enemy or enemies the first enemy hit will be the
        }
    }

    bool CheckTargetIsInRange()
    {
        return Vector3.Distance(target.position, transform.position) <= firingRange;
    }

    void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>(); // getting bullet component info from bullet prefab
        bulletScript.SetTarget(target);
    } 

}
