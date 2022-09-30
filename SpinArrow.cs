using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinArrow : MonoBehaviour
{
    public static SpinArrow instance;
    GameObject reward;

    private void Start()
    {
        instance = this;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        reward = collision.gameObject;
    }

    public GameObject getReward()
    {
        return reward;
    }

   
}
