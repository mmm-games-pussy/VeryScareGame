using UnityEngine;
using UnityEngine.UI;

public class HealthMob : MonoBehaviour
{
    [SerializeField] private Image _healthImage;

    [SerializeField] private float _health = 1000;

    [SerializeField] private VictoryScript _victory;

    private float _healthFull;

    private void Start()
    {
        _healthFull = _health;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        _healthImage.fillAmount = _health / _healthFull;

        Debug.Log(_health / _healthFull);

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _victory.StartVictory();
        Destroy(gameObject);
    }
}