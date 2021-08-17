using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrippleShot : MonoBehaviour
{
    [SerializeField]
    private float trippleshotPowerUp=3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * trippleshotPowerUp);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag == "Player")
        {
           PlayerMovement.instance.canTrippleShot = true;
            Destroy(this.gameObject);
        }*/
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.TrippleShotPowerUp();
                //StartCoroutine(player.TripleShotPowerDown());

            }
            Destroy(this.gameObject);

        }
            
    }
}
