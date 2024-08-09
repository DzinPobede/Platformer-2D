using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private RespawnManager respawnManager;
    [SerializeField] private float distance = 3f;
    private Vector2 A;
    private Vector2 B;
    public GameObject objectToRespawn;
    public Transform spawnPoint;
    private float timer = 0f;
    private bool isDestroyed = false;
    public int health = 1;
    private bool MovingToPointB = true;
    

    void Start()
    {
        A = new Vector2(transform.position.x, transform.position.y);
        B = new Vector2(transform.position.x + distance, transform.position.y);
        StartCoroutine(MoveBetweenPoints());
        respawnManager = FindObjectOfType<RespawnManager>();
    }

    IEnumerator MoveBetweenPoints()
    {
        while (true)
        {
            Vector2 targetpoint = MovingToPointB ? B : A;

            while (Vector2.Distance(targetpoint, transform.position) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetpoint, speed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(0.5f);

            MovingToPointB = !MovingToPointB;
            Flip();
        }
    }

    private void Update()
    {
        HealthStats();
    }

    void HealthStats()
    {
        if (health <= 0)
        {
            isDestroyed = true;
            respawnManager.StartRespawn();  // Assuming this handles any pre-respawn logic
            Destroy(gameObject);
        }
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Respawn()
    {
        Instantiate(objectToRespawn, spawnPoint.position, spawnPoint.rotation);
        isDestroyed = false;
    }
}
