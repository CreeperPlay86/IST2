using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    
    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    Vector3 velocity;
    bool isGrounded;

    #region DATA
        #region TRANSFORM
            public Transform[] pvpPositionPlayer;
        #endregion

        #region BOOL
            public bool pvpActive;

            public bool inTerritoryTree;
        #endregion

        #region CONNECT
            public gameManager GM;

            public animationManager AM;
        #endregion
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("gameManager").GetComponent<gameManager>();
        AM = GameObject.Find("animationManager").GetComponent<animationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inTerritoryTree)
        {
            if(Input.GetMouseButtonDown(0))
            {
                GM.revenueStrength();

                AM.isFarmStrength = true;

                StartCoroutine(checkTimer());
            }
        }

        #region MOVE
            if(pvpActive)
                return;

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            
            #region ANIMATION
                if(AM != null)
                {
                    if(vertical == 0 && horizontal == 0)
                    {
                        AM.moodPlayer = "idle";
                    }
                    else
                    {
                        AM.moodPlayer = "run";
                    }
                }
            #endregion

            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

            if (direction.magnitude > 0.1f)
            {
                float targeAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targeAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targeAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            if(Input.GetButtonDown("Jump"))
                AM.anim.SetTrigger("goChangeAnim");

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        #endregion
    }

    #region VOID and IE
        public void activePVP()
        {
            transform.position = pvpPositionPlayer[0].position;

            pvpActive = true;
        }

        public void disactivePVP()
        {
            pvpActive = false;
        }
    #endregion

    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "tree")
        {
            inTerritoryTree = true;
        }
    }
    void OnTriggerExit(Collider obj)
    {
        if(obj.gameObject.tag == "tree")
        {
            inTerritoryTree = false;
        }
    }

    IEnumerator checkTimer()
    {
        yield return new WaitForSeconds(0.35f);

        AM.isFarmStrength = false;
    }
}
