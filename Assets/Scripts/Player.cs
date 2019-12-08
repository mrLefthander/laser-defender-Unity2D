using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] AudioClip laserSound;
    [SerializeField] GameObject laserFire;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFirePeriod = 0.2f;

    GameSession gameStatus;
    float xMin, xMax;
    float yMin, yMax;
    bool isFiring = false;

    void Start()
    {
        SetUpMoveBoundaries();
        gameStatus = FindObjectOfType<GameSession>();

    }

    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButton("Fire1") && !isFiring)
            StartCoroutine(FireCointinuously());
    }

    IEnumerator FireCointinuously()
    {
        while (Input.GetButton("Fire1"))
        {
            GameObject laser = Instantiate(laserPrefab, transform.position,
                   Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            GameObject laserFiringSplash = Instantiate(laserFire, new Vector3(transform.position.x, transform.position.y + 0.4f, 0),
              transform.rotation) as GameObject;
            Destroy(laserFiringSplash, projectileFirePeriod / 2f);

            isFiring = true;
            AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, gameStatus.GameVolume);
            yield return new WaitForSeconds(projectileFirePeriod);
            isFiring = false;
        }

    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
        transform.rotation = Quaternion.Euler(0, Math.Sign(deltaX) * 25, 0);
    }

    private void SetUpMoveBoundaries()
    {
        Sprite playerSprite = GetComponent<SpriteRenderer>().sprite;
        float xPadding = playerSprite.rect.size.x / playerSprite.pixelsPerUnit / 2f;
        float yPadding = playerSprite.rect.size.y / playerSprite.pixelsPerUnit / 2f;

        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xPadding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xPadding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yPadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - yPadding;
    }
}

   
