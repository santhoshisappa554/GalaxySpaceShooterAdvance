using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourAI : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyExplosion;
    [SerializeField]
    private float enemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);
        if (transform.position.y <= -5.3f)
        {
            transform.position = new Vector3(Random.Range(-2.1f,2.0f), 5.3f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "laser")
        {
            if (collision.transform.parent != null)
            {
                Destroy(collision.transform.gameObject);
            }
            Destroy(collision.gameObject);
            Instantiate(EnemyExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
    }
}
