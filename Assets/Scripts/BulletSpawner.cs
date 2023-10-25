using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float spawnRateMin;
    [SerializeField] float spawnRateMax;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    private void Start()
    {
        timeAfterSpawn = 0f;

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        target = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
