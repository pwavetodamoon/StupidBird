using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedJump; // Khai báo Tốc độ bay lên của GameObj

    //Khai báo biến tên rb thuộc ( kiêu dữ liệu là Rigidbody2D)

    public Rigidbody2D rb; // dùng từ khóa public để công khai ra ngoài( thay đổi kéo thả ngoài Unity Editor).
    public Animator anim;
    public AudioSource flapSound;
    public AudioSource hitSound;
    private LogicScript logic;
    private bool BirdStillAlive = true; // Sử dụng kiểu bool mặc định Bird alive
    int touch = 1;
    int coutTouch = 0;
    void Start()
    {

        Jump();//gọi hàm jump để khi bắt đầu game nv bay lên
        // rb= GetComponent<Rigidbody2D>();
        // ( ngoài việc dùng từ khóa public ta có thể dùng từ khóa private và gắn như trên * Ở hàm Start *)

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); 
        //Bắt đầu game tham chiếu đến GameObj có tag Logic và connect với Script trong Component
    }

 
    void Update()
    {    // Nếu Input ( đầu vào ) Space là (==) đúng 
        if (Input.GetMouseButtonDown(0) && BirdStillAlive) // 
        {
            Jump(); // gọi hàm Jump
            flapSound.Play();

            //Đoạn code này gọi một trigger "jump" trong một đối tượng có component Animation.
            //Trigger sẽ kích hoạt một sự kiện animation liên quan đến nhãn "jump".
            anim.SetTrigger("jump");

            // LƯU Ý :
            // Game Obj phải có Animation trong Animator trước , sau đó gắn vào anim thông qua code:  public Animator anim;
            //đối tượng là (Game Obj) đã được kết nối với gắn với biến "anim".
            //jump là tên của parameter Trigger ( tên do người dùng tạo)  
        }
        TouchMidAnDown(); // Gọi hàm kiểm tra va chạm cạnh trên và dưới của Bird   

    }
    void Jump()
    {   
        //Thêm lực vào cho rb (Rigibody2D hoặc có thể nói là GameObj đang được gắn Script này )
        //velocity ( thêm lực)
        rb.velocity = Vector2.up * speedJump;
    }
    void TouchMidAnDown() // Tạo hàm kiểm tra va chạm cạnh trên và dưới
    {
        if (transform.position.y > 15) // nếu Trục Y của Bird > 8.4 thì:
        {
            logic.GameOver();
            if (coutTouch < touch) // Khai báo 2 biến để đếm tính số lần va chạm
                                   // touch = 1 , countTouch = 0
            {
                hitSound.Play();
                coutTouch++;

            }
            BirdStillAlive = false;
        }

        if (transform.position.y < -15) //nếu Trục Y của Bird < -8.4 thì:
        {
            logic.GameOver();
            if (coutTouch < touch) // Khai báo 2 biến để đếm tính số lần va chạm
                                   // touch = 1 , countTouch = 0
            {
                hitSound.Play();
                coutTouch++;
            }
            BirdStillAlive = false;
        }
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver(); // Gọi Function GameOver trong script LogicScript

        if(coutTouch < touch) // Khai báo 2 biến để đếm tính số lần va chạm
                              // touch = 1 , countTouch = 0
        {                     
            hitSound.Play();
            coutTouch++;
        }
        BirdStillAlive = false; // Set Bird Dead
    }
}
