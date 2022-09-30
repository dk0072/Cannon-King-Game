using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonMachanics : MonoBehaviour
{

    [SerializeField] Text scoreCount;
    [SerializeField] int _scoreCount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            UIManager.instance.GameOver();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Coin"))
        {

            Destroy(collision.gameObject);
            _scoreCount += 1;
            scoreCount.text = _scoreCount + "";
            
            
        }
    }
}
