using UnityEngine;

public class spawnballoon : MonoBehaviour
{
    public GameObject balloonPrefab;
    public float spawnInterval = 5f;   // seconds
    public Material[] balloonMaterials;

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

        GameObject balloon = Instantiate(balloonPrefab, pos, Quaternion.identity);

        Renderer r = balloon.GetComponentInChildren<Renderer>();

        if (r != null && balloonMaterials.Length > 0)
        {
            r.material = balloonMaterials[Random.Range(0, balloonMaterials.Length)];
        }
    }

}
