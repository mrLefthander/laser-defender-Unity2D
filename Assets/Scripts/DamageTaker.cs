using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 100;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] GameObject explosionParticle;

    GameSession gameStatus;
    void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        
        if (health <= 0)
        {
            Die();
        }
        damageDealer.Hit();
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, gameStatus.GameVolume);

        // Player must be layer 8
        if (gameObject.layer == 8)
            FindObjectOfType<LevelLoader>().LoadGameOver();

        if (gameObject.layer != 8)
            gameStatus.AddToScore(scoreValue);

        gameObject.SetActive(false);
        Destroy(gameObject);

        GameObject explosion = Instantiate(explosionParticle, transform.position,
              transform.rotation) as GameObject;
        Destroy(explosion, 1f);
    }

    public float GetHealth()
    {
        return health;
    }
}
