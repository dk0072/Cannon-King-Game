using UnityEngine;
using UnityEngine.UI;

public class CannonBullet : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] GameObject Effect;


    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        //GameObject effect = Instantiate(Effect, transform.position, Quaternion.identity);
        //Destroy(effect, 1);
    }
}
