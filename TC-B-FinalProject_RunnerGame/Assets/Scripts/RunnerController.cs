using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RunnerController : MonoBehaviour
{
    public bool isRunning;
    public Rigidbody rigidbody;
    public float Speed;
    public float SideSpeed;
    public int cloudValue = 1;
    public GameObject loseMenu;
    public TextMeshProUGUI CountDown;



    private Vector3 swipeStartPosition, swipeEndPosition;
    private float swipeStartTime;
    private float swipeTime, swipeDistance;
    private float scaleUpCoef = 1.0f;
    private float flashTimer = 0;
    private float iceTimer = 0;
    private float thunderTimer = 0;
    private bool flashFlag = false;
    private bool iceFlag = false;
    public static bool thunderFlag = false;
    
    




    public float MaxSwipeTime, MinSwipeDistance;
    private Vector3 local;
    public Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {

        float moveX = 0f;

        if (Input.GetMouseButtonDown(0))
        {

            swipeStartPosition = Input.mousePosition;
            swipeStartTime = Time.time;
            
        }
       
        else if (Input.GetMouseButton(0))
        {
            swipeEndPosition = Input.mousePosition;
            swipeDistance = (swipeEndPosition - swipeStartPosition).magnitude;
            swipeTime = Time.time - swipeStartTime;

            if (swipeTime < MaxSwipeTime && swipeDistance > MinSwipeDistance)
            {
                Vector2 swipe = swipeEndPosition - swipeStartPosition;

                moveX = swipe.x;
            }
           
        }

        if(flashFlag)
        {
            flashTimer += Time.deltaTime;
            CountDown.text = (4 - flashTimer).ToString()[0].ToString();
        }
        
        if (flashTimer >= 3)
        {
            
            Speed = 700;
            SideSpeed = 10;
            flashTimer = 0;
            flashFlag = false;
            CountDown.text = "";
        }

        if (thunderFlag)
        {
            
            thunderTimer += Time.deltaTime;

        }

        if (thunderTimer >= 0.1)
        {
            thunderTimer = 0;
            thunderFlag = false;
        }


        moveX = Mathf.Clamp(moveX, -1f, 1f);

        transform.Translate(transform.right * moveX * SideSpeed * Time.deltaTime);

        



    }

   

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (isRunning)
        {
            rigidbody.velocity = transform.forward * Speed * Time.fixedDeltaTime;
        }
        

        if (iceFlag)
        {
            iceTimer += Time.fixedDeltaTime;
            CountDown.text = (4-iceTimer).ToString()[0].ToString();
        }

        if (iceTimer >= 3)
        {

            iceFlag = false;
            Speed = 700;
            SideSpeed = 10;
            iceTimer = 0;
            CountDown.text = "";


        }


    }
    
    

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.tag == "Cloud")
        {
            scaleUpCoef += 0.1f;
            local = transform.localScale;
            transform.localScale = new Vector3(scaleUpCoef, scaleUpCoef, scaleUpCoef);
            ScoreManager.cloud.ChangeScore(cloudValue);
        }
        if (other.transform.tag == "Sun")
        {
            scaleUpCoef -= 0.1f;
            local = transform.localScale;
            transform.localScale = new Vector3(scaleUpCoef, scaleUpCoef, scaleUpCoef);
            ScoreManager.cloud.ChangeScore(-1 *cloudValue);


            if (scaleUpCoef < 0.4f )
            {
                Debug.Log("You are dead!");
                isRunning = false;
                Scene scene = SceneManager.GetActiveScene();
                loseMenu.SetActive(true);
                //SceneManager.LoadScene(scene.name);

            }
        }
        if (other.transform.tag == "Flash")
        {
            
            Speed = 900;
            SideSpeed = 15;
            flashFlag = true;
            
         

        }
        if (other.transform.tag =="Ice")
        {
            iceFlag = true;
            Speed = 350;
            SideSpeed = 5;

        }
        if (other.transform.tag == "Thunder")
        {
            //thunder.ThunderMove();
            thunderFlag = true;


        }
        if (other.transform.tag == "Finish")
        {
            animator.SetBool("finishDancing", true);
            animator.Play("SwingDancing");
            isRunning = false;
        }



    }
    

    


}
