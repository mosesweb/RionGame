using UnityEngine;

public class spawnballoon : MonoBehaviour
{
    public GameObject balloonPrefab;
    public float spawnInterval = 5f;   // seconds

    void Start()
    {
        InvokeRepeating(nameof(SpawnBalloon), 0f, spawnInterval);
    }

    void SpawnBalloon()
    {
        Vector3 pos = new Vector3(
            Random.Range(-3f, 3f),
            -3f,
            0f
        );

        Instantiate(balloonPrefab, pos, Quaternion.identity);
    }
}
