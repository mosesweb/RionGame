using UnityEngine;

public class SpawnBallOnClick : MonoBehaviour
{
    public GameObject ballPrefab;     // Assign a sphere prefab in the Inspector
    public Vector3 spawnArea = new Vector3(10f, 5f, 10f); // Defines random range around origin

    void Update()
    {
        // Left click (0) or Right click (1)
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.anyKeyDown || Input.touchCount > 0)
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        if (ballPrefab == null)
        {
            Debug.LogWarning("No ball prefab assigned!");
            return;
        }

        // Pick a random position within the defined area
        Vector3 randomPos = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            Random.Range(0f, spawnArea.y),
            Random.Range(-spawnArea.z, spawnArea.z)
        ); // Instantiate the ball


        GameObject newBall = Instantiate(ballPrefab, randomPos, Quaternion.identity);

        // Give it a random color
        Renderer rend = newBall.GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = new Color(
                Random.value,  // red
                Random.value,  // green
                Random.value   // blue
            );
        }
    }

    // Optional: Draws a wire cube in the editor to visualize the spawn area
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, spawnArea * 2);
    }
}
