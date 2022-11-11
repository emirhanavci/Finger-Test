using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Drag : MonoBehaviour
{
    public static Drag instance;
    public bool isDrag = false;


    public GameObject playerObj;

    public Vector3 playerPos;
    private void Start()
    {

    }

    public void Update()
    {
        if (Input.touchCount > 0 && Coin.instance.finish == false)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);

                if (hit.collider != null && hit.collider.tag == "Player")
                {
                    isDrag = true;
                    playerObj = hit.collider.gameObject;
                    playerPos = playerObj.transform.position;
                }
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (isDrag)
                {
                    playerPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    playerPos.z = 0;
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                isDrag=false;
            }
        }
        if (isDrag)
        {
            playerObj.transform.position = playerPos;
        }


    }   
}