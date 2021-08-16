using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float playermoveSpeed;
    [SerializeField]
    private float horizontal;
    [SerializeField]
    private float vertical;
    [SerializeField]
    private GameObject laserPrefab;
    public float fireRate = 0.25f;
    public float canfire = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (Time.time > fireRate)
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                canfire = Time.deltaTime + fireRate;
            }
        }
            
        horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*Time.deltaTime* horizontal);
        vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * vertical);

        //player bounds

      /*  if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }*/
       if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f,transform.position.y, 0);
        }

    }
}
