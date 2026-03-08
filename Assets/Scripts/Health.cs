using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int defaultHealthPoint;
    public System.Action onDead;

    private int healthPoint;

    private void Start()
    {
        healthPoint = defaultHealthPoint;
    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;

        healthPoint -= damage;

        if (healthPoint <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(
                explosionPrefab,
                transform.position,
                transform.rotation
            );

            Destroy(explosion, 1f);
        }
        onDead?.Invoke();
        Destroy(gameObject);
    }
}