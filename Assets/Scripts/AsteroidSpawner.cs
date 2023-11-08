using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private float SpawnRate;
    [SerializeField] private float LastSpawn;
    [SerializeField] private float MinRotation = -90, MaxRotation = -90;
    [SerializeField] private Vector2 MinSpeed, MaxSpeed;
    [SerializeField] private Transform MinSpawnPoint, MaxSpawnPoint;
    public Vector2 MinSpawnVector => MinSpawnPoint.position;
    public Vector2 MaxSpawnVector => MaxSpawnPoint.position;
    public AsteroidMovement Template;

    void Start()
    {
        LastSpawn = Time.time;
    }

    void Update()
    {
        if (ShouldSpawn())
        {
            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid()
    {

        AsteroidMovement newAsteroid = Instantiate(Template);
        if (newAsteroid != null)
        {
            Vector2 SpawnPoint = new(Random.Range(MinSpawnVector.x, MaxSpawnVector.x), MinSpawnVector.y);
            newAsteroid.transform.position = SpawnPoint;
            newAsteroid.RotationSpeed = Random.Range(MinRotation, MaxRotation);
            newAsteroid.Speed = new(Random.Range(MinSpeed.x, MaxSpeed.x), Random.Range(MinSpeed.y, MaxSpeed.y));
            LastSpawn = Time.time;
        }
        else
        {
            Debug.LogError("AsteroidMovement prefab is missing or destroyed.");
        }
    }

    private bool ShouldSpawn()
    {
        return Time.time > (LastSpawn + SpawnRate);
    }
}
