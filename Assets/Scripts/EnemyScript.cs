using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform A;
    [SerializeField] private Transform B;
    private bool MovingToPointB = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveBetweenPoints());
    }
    IEnumerator MoveBetweenPoints()
    {
        while (true)
        {
            Transform targetpoint = MovingToPointB ? B : A;

            while (Vector2.Distance(new Vector2(targetpoint.position.x, transform.position.y), transform.position) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position , new Vector2(targetpoint.position.x, transform.position.y), speed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(0.5f);
            
            MovingToPointB = !MovingToPointB;

            Flip();
        }
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
   
}
