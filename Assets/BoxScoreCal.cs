using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScoreCal : MonoBehaviour
{
     LogicScript logic; // Gán Logic là LogicScript để tham chiếu
    // Start is called before the first frame update
    void Start()
    {
        //biến logic thuộc (Class LogicScript) =
        //GameObject có Tag là "Logic".Tham chiếu tới Component là LogicScript
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        // Lưu ý : Chỉ tìm được TAG với điều kiện GameObj đã được tạo & thêm TAG 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Gọi hàm này khi Game Object va chạm với Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        logic.CalScore();
    }
}
