using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrippleShotANDPowerUp : MonoBehaviour
{
    [SerializeField]
    private float trippleshotPowerUp=3.0f;
    [SerializeField]
    private int powerUpId;//0=trippleshot  1=speedboost 2=Shields


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
                if (powerUpId == 0)
                {
                    player.TrippleShotPowerUp();
                    
                }
                else if (powerUpId == 1)
                {
                    player.SpeedPowerUpOn();
                }
                else if (powerUpId == 2)
                {
                    player.EnableShieldPowerUp();
                }


            }
            Destroy(this.gameObject);

        }
            
    }
}
