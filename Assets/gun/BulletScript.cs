using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private int _damage = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mob"))
        {
            collision.gameObject.GetComponent<HealthMob>().TakeDamage(_damage);
        }
    }
}
