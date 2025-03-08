using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreate : MonoBehaviour
{
    public GameObject block;
    //public Transform kamera;
    private Vector2 offset = new Vector2(2f,1f);
    // Start is called before the first frame update
    void Start()
    {
        CreateBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateBlock() {
        //Vector3 CameraCenter = kamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f,0.5f,kamera.position.z));
        for(int a = 0; a < 12; a++) {
            for(int b = 0; b < 5; b++) {
                GameObject newBlock = Instantiate(block, transform.position, Quaternion.identity);
                newBlock.transform.position = transform.position + new Vector3(a * offset.x, b * offset.y, 0);

            }
        }
    }
}
