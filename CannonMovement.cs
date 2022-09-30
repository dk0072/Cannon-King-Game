using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{

    public static CannonMovement instance;

    private float moveSpeed = 0.3f;
    Touch touch;

    [SerializeField] Transform wheel1, wheel2;

    [HideInInspector]
    public bool canMove = true;

    [SerializeField] Rigidbody2D rb;
    private void Start()
    {
        instance = this;
    }
    void Update()
    {

    

        if (Input.touchCount > 0 && canMove && UIManager.instance.canStart)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
               

                transform.position = new Vector3(Mathf.Clamp(transform.position.x + touch.deltaPosition.x * moveSpeed * Time.deltaTime, -1.83f, 1.83f), transform.position.y, transform.position.z);            

                wheel1.Rotate(0, 0, -touch.deltaPosition.x * moveSpeed);
                wheel2.Rotate(0, 0, -touch.deltaPosition.x * moveSpeed);


            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }

    }
}
