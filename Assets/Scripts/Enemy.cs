using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] AudioClip laserSound;
    [SerializeField] float projectileSpeed = 10f;


    GameSession gameStatus;
    float shotCounter;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }

    }

    private void Fire()
    {
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, gameStatus.GameVolume);
        GameObject laser = Instantiate(laserPrefab, transform.position,
                  Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }
}
