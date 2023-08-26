using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Tree;
    public float TimeSpawn; // Khởi tạo thời gian Spawn Cột
    private float BeginTime = 0; // Biến đếm để đếm thời gian
    public float heightpoint = 10;
    void Start()
    {
       SpawnTree(); // Gọi Hàm Spawn Cột
    }

    // Update is called once per frame
    void Update()
    {
        if (BeginTime < TimeSpawn) // So sánh Biến đếm với Thời gian Spawn Cột
        {
            BeginTime = BeginTime + Time.deltaTime; // Nếu bé thì Biến đếm + Time.DeltaTime
        }
        else
        {
            SpawnTree();
            BeginTime = 0; // Nếu ngược đặt biến đếm thành 0 để bắt đầu vòng lặp
        }
    }
    void SpawnTree()
    {
        //1.Tìm độ cao thấp nhất = Gọi position.y ( của Game Object) - Độ cao trong khoảng của GameObj (heightpoint)
        //2.Tìm độ cao cao nhât = 1
        float LowPoint = transform.position.y - heightpoint;
        float HighPoint = transform.position.y + heightpoint;
        // Sử dụng hàm Instantiate để Nhân bản ( Game Object)
        Instantiate(Tree, new Vector3(transform.position.x , Random.Range(LowPoint, HighPoint),0), transform.rotation);
    }    
}
