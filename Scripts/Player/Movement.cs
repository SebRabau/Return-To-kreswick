using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject wand;
    public GameObject ball;
    public Transform bulletSpawn;
    public AudioClip fireball;
    public AudioClip firehold;
    public Text holdLonger;
    public Text LPT;
    public Text DPT;

    public float speed = 15.0f;
    public static int dps = 10;

    private AudioSource audiosource;
    private bool timing;
    private bool shootable;
    private IEnumerator timer;
    private float x = Screen.width / 2f;
    private float y = Screen.height / 2f;

    public static int LP=1;
    public static int maxLP=7;

    public static int maxDP=7;
    public static int DP=1;

    void Start()
    {
        //Set Camera to follow
        Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);

        audiosource = GetComponent<AudioSource>();

        ball.SetActive(false);
        holdLonger.gameObject.SetActive(false);
    }

    void Update()
    {
        //Confine cursor to window
        Cursor.lockState = CursorLockMode.Locked;

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            shootable = false;

            audiosource.PlayOneShot(firehold, 0.3f);

            ball.SetActive(true);      
            
            if(!timing)
            {
                timer = HoldTime(0.8f);
                StartCoroutine(timer);
                timing = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            timing = false;

            if(shootable)
            {
                Fire();
            } else
            {
                holdLonger.gameObject.SetActive(true);
                timer = HoldTimeText(holdLonger);
                StartCoroutine(timer);
            }
            ball.SetActive(false);
            audiosource.Stop();            
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        var mx = Input.GetAxis("Mouse X") * Time.deltaTime * 175.0f;
        var my = Input.GetAxis("Mouse Y") * Time.deltaTime * 80.0f;  

        transform.Rotate(0, mx, 0);
        transform.Translate(x, 0, z);

        //Rotate Wand
        //wand.transform.Rotate(-my, 0, 0);
        wand.transform.LookAt(Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 15)));

        //Rotate Camera
        Camera.main.transform.Rotate(-my, mx, 0);

        //Prevent Rotation in z axis
        Quaternion c = Camera.main.transform.rotation;
        c.eulerAngles = new Vector3(c.eulerAngles.x, c.eulerAngles.y, 0);
        Camera.main.transform.rotation = c;      
    }

    void Fire()
    {
        audiosource.PlayOneShot(fireball, 0.3f);

        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        var dir = Camera.main.ScreenPointToRay(new Vector3(x, y, 0));

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = dir.direction * 100;
        
        Destroy(bullet, 5.0f);
    }

    void OnTriggerEnter(Collider barrier)
    {
        if(barrier.CompareTag("LP"))
        {
            UpdateLP();
            LPT.gameObject.SetActive(true);
            IEnumerator add = HoldTimeText(LPT);
            StartCoroutine(add);
            Destroy(barrier.gameObject);

        } else if(barrier.CompareTag("DP"))
        {
            UpdateDP();
            DPT.gameObject.SetActive(true);
            IEnumerator add = HoldTimeText(DPT);
            StartCoroutine(add);
            Destroy(barrier.gameObject);

            dps++;
        }
    }


    public void UpdateDP()
    {
        DP++;
        SimpleHealthBar.UpdateBar("Dark", DP, maxDP);
    }

    public void UpdateLP()
    {
        LP++;
        SimpleHealthBar.UpdateBar("Light", LP, maxLP);
    }
    private IEnumerator HoldTime(float a)
    {
        yield return new WaitForSeconds(a);
        shootable = true;
    }

    public static IEnumerator HoldTimeText(Text a)
    {
        yield return new WaitForSeconds(2);
        a.gameObject.SetActive(false);
    }
}