using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isSpeedPowerupActive = false;
    public bool canTrippleShot = false;
    public bool isShieldActive = false;
    [SerializeField]
    private float playermoveSpeed;
    private float horizontal, vertical;
    [SerializeField]
    private GameObject laserPrefab,TriplelaserPrefab;
    public float fireRate = 0.25f;
    public float canfire = 0;
    public static PlayerMovement instance;
    public int playerLives = 3;
    public GameObject explosion;
    public GameObject shield;
    private UIManager uiManager;
    private GameManager gameManager;
    private Spawning spawn;
    AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioClip;
    [SerializeField]
    private GameObject[] engines;
    public float hitcount = 0;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawn = GameObject.Find("SpawnManager").GetComponent<Spawning>();
        audioSource = GetComponent<AudioSource>();
        if (uiManager != null)
        {
            uiManager.UpdateLives(playerLives);
        }
        if (spawn != null)
        {
            spawn.StartCoroutineFunctions();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        //player bounds
    }

    private void Shoot()
    {
        if (Time.time > fireRate)
        {
            //if triple shot is true shoot three lasers, if not one laser
            if (canTrippleShot == true)
            {
                Instantiate(TriplelaserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                audioSource.clip = audioClip[1];
                audioSource.Play();

            }
            else
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                audioSource.clip = audioClip[2];
                audioSource.Play();
            }
           
            canfire = Time.deltaTime + fireRate;
        }
    }

    private void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isSpeedPowerupActive == true)
        {
            //print(playermoveSpeed * 2.0f);
            transform.Translate(Vector3.right * Time.deltaTime * horizontal*playermoveSpeed*2.0f);
            transform.Translate(Vector3.up * Time.deltaTime * vertical* playermoveSpeed * 2.0f);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontal*playermoveSpeed);
            transform.Translate(Vector3.up * Time.deltaTime * vertical*playermoveSpeed);
        }

        


        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
    }
    public void TrippleShotPowerUp()
    {
        canTrippleShot = true;
        StartCoroutine(TripleShotPowerDown());
    }
    //method to enable speed power up and power down
    public void SpeedPowerUpOn()
    {
        isSpeedPowerupActive = true;
        StartCoroutine(SpeedPowerUpDown());
    }
    public IEnumerator SpeedPowerUpDown()
    {
        yield return new WaitForSeconds(5.0f);
        canTrippleShot = false;
    }

    public IEnumerator TripleShotPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        canTrippleShot = false;
    }
    public void Damage()
    {
        
        hitcount++;
        if (hitcount == 1)
        {
            engines[0].SetActive(true);
        }
        else if (hitcount == 2)
        {
            engines[1].SetActive(true);
        }

        if (isShieldActive == true)
        {
            isShieldActive = false;
            shield.SetActive(false);
            //return;
        }
        else
        {
            playerLives--;
            uiManager.UpdateLives(playerLives);
            if (playerLives < 1)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                //audioSource.clip = explosionAudioClip;
                audioSource.Play();
                gameManager.gameOver = true;
                uiManager.ShowGameOverScreen();
                gameObject.SetActive(false);

            }
        }
    }
    public void EnableShieldPowerUp()
    {
        isShieldActive = true;
        shield.SetActive(true);
    }
}
