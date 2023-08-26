using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public float SpeedTree; // Khai báo Tốc độ của Tree kiểu Float và public để chỉnh sửa bên ngoài
    // Start is called before the first frame update
    public float DeadZone = -35;
    LogicScript logic;
    TreeSpawner tree;
  
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        tree = GameObject.FindGameObjectWithTag("tree").GetComponent<TreeSpawner>();
       
    }
    
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < DeadZone)
        {
           Destroy(gameObject);
        }    
        // Tao mới vị trí của Tree mỗi giây ( sang trái Vector3.left):
        // Vị trí hiện tại ( của GameObj) = Vị trí hiện tại + (Vector3.(Đi sang trái) * Tốc độ )* Thời giân thực
        transform.position += (Vector3.left * SpeedTree )* Time.deltaTime;
        UpSpeedTree();
     
        
    }
    
    private void UpSpeedTree()
    {
        for (int i = 0; i < logic.PlayerScore; i++)
        {
            if (logic.PlayerScore % 2 == 0)
            {
                SpeedTree += 0.02f * Time.deltaTime;
                tree.transform.localScale = tree.transform.localScale - new Vector3(0.1f, 0, 0);
                if (tree.transform.localScale.x < 0.5f)
                {
                    tree.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }          
            }
        }
    }
}
