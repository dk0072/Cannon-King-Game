using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CannonShoot : MonoBehaviour,IPointerDownHandler , IPointerUpHandler
{
    public static CannonShoot instance;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform Position;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip[] clips;
    [SerializeField] GameObject onStartGame;
    [SerializeField] Animator anim;
    [SerializeField] ParticleSystem cannon1Shell;


    private void Start()
    {
        Time.timeScale = 1;
        instance = this;
    }

    public void PlayExplosionSound()
    {
        if (!source.isPlaying)
        {
            source.clip = clips[1];
            source.Play();
        }
    }

    void _ShootBullet()
    {
        Time.timeScale = 1;
        if(source != null)
        {
            if (!UIManager.instance.IsGameOver && !UIManager.instance.isGameWon)
            {
                source.clip = clips[0];
                source.Play();
            }

            if(!UIManager.instance.IsGameOver &&!UIManager.instance.isGameWon)
            {
                if (Position != null)
                {
                    cannon1Shell.Play();

                    Instantiate(Bullet, Position.position, Quaternion.identity);
                }
            }
            else
            {
                cannon1Shell.Stop();
                anim.SetBool("canShake", false);
            }
        }
    
      
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UIManager.instance.StartGame();
        anim.SetBool("canShake", true);
        InvokeRepeating("_ShootBullet", 0, 0.12f);
        onStartGame.SetActive(true);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        cannon1Shell.Stop();
        anim.SetBool("canShake", false);
        CancelInvoke("_ShootBullet");
    }
}
