using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float speed = 1f;
    public AudioClip pop;

    void Update()
    {
        // Movement
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > 6f)
            Destroy(gameObject);

        // PC click
        if (Input.GetMouseButtonDown(0))
            CheckHit(Input.mousePosition);

        // Android touch
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            CheckHit(Input.touches[0].position);
    }

    void CheckHit(Vector3 screenPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Is this balloon the one we hit?
            if (hit.collider.gameObject == gameObject)
            {
                AudioSource.PlayClipAtPoint(pop, Camera.main.transform.position);
                Destroy(gameObject);
            }
        }
    }
}
