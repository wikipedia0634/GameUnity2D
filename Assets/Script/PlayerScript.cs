using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour {
	public GameObject GameOver;
    //move force tốc độ di chuyển, jumForce độ nhảy
    public float moveForce = 40f;
    public float jumForce = 50f;
    //tốc độ tối thiểu
    public float maxVelocity = 4f;
    //animation 
    private Animator anim;
    //giridbody
    private Rigidbody2D myBody;
	public Rigidbody2D r2;

    bool grounded;
	public bool doublejump = false;
    //hàm này để khởi tạo 

	//***

	[SerializeField]
	private AudioSource _audioSource;

	[SerializeField]
	private AudioClip _coinPing, _jumpPing;

    private void Awake()
    {
		r2 = gameObject.GetComponent<Rigidbody2D>();	
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        //int mang= 3; istrigger tag destroy mang = mang -1
        // neu mang =0, destroy game object
        //cho 1 tranfrom.position hồi sinh

		_audioSource = GetComponent<AudioSource> ();

    }
    // Use this for initialization
    void Start()
    {
		
		GameOver = GameObject.Find ("GameOver");// tham chieu den gameover object 
		GameOver.SetActive (false);// hide gameover panel
		Time.timeScale = 1;// thoi gian chay cua game
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        RunPlayer();
		_ChangeState ();
    }

    void RunPlayer()
    {
        //bàn đầu cho force x= tốc độ di chuyển, for x độ nhảy
        float forceX = 0f;
        float forceY = 0f;
        //Mathf.Abs đưa về giá trị dương
        float vel = Mathf.Abs(myBody.velocity.x);//tinh van toc hien tai

        float h = Input.GetAxisRaw("Horizontal");//di chuyen theo chieu ngang
        //h > 0 la phim phai, h<0 phim trai, h =0 k bam
        if (h > 0)
        {
            //neu van toc hien tai nho hon van toc toi thiểu
            if (vel < maxVelocity)
            {
                //neu cham dat tag ground
                if (grounded)
                {
                    //set forcex
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce * 1.1f;
                }
            }

            Vector3 scale = transform.localScale;
            //1f là qua phải , -1f thì ngược lại
            scale.x = 1f;
            transform.localScale = scale;


        }
        else if (h < 0)
        {

            //neu van toc hien tai nho hon van toc toi da
            if (vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 1.1f;
                }
            }

            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;



        }

		/*else if (h ==0)
        {
            //neu van toc hien tai nho hon van toc toi da
			anim.SetTrigger ("Idle");


        }	*/	else{
			
		}
        //khi chúng ta nhấn space

		if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                //xet độ nhảy
				grounded = false;
				doublejump = true;
				r2.AddForce(Vector2.up*jumForce);
                                
				_audioSource.PlayOneShot (_jumpPing);
            }
			else {
				if (doublejump) {
					doublejump = false;
					r2.velocity = new Vector2 (r2.velocity.x, 0);
					r2.AddForce (Vector2.up * jumForce * 0.9f);
				}
			}
        }
        //temp positon vị trí player
        Vector3 temp = transform.position;
        //forceX, ForceY
        myBody.AddForce(new Vector2(forceX, forceY));
    }
    //OnCollision  nếu có trigger thì dùng cái này
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            //có va chạm với ground => true
            grounded = true;
            anim.SetBool("jump", false);

			Debug.Log ("Va chạm với " + collision.gameObject.name);
        }
        
    }

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "mid")
		{
			GameOver.SetActive (true); //show gamover panel khi nhan vat chet
			Time.timeScale = 0;// dong bang thoi gian-moi hoat dong cua game dong bang
			//Destroy(GameObject.Find("Player"));

		}

		if (col.gameObject.tag == "DeadZone")
		{
			GameOver.SetActive (true);
			Time.timeScale = 0;
			Debug.Log ("Va chạm với " + col.gameObject.name);
		}

		if(col.gameObject.tag == "coin"){
			_audioSource.PlayOneShot (_coinPing);
			Debug.Log ("Va chạm với " + col.gameObject.name);
		}

		if (col.gameObject.tag == "Arrow")
		{
			GameOver.SetActive (true);
			Time.timeScale = 0;
			Destroy (gameObject);
			Debug.Log ("Va chạm với " + col.gameObject.name);
		}
			
	}

	void _ChangeState(){
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)){
			anim.SetTrigger ("Run");
		}
		else {
			anim.SetTrigger ("Idle");
		}
	}
		
}
