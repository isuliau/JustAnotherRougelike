using System;
using Unity.VisualScripting;
using UnityEngine;


public class MineExplodey : MonoBehaviour
{
    [SerializeField] private ParticleSystem ExplosionParticles;
    [SerializeField] private GameObject HitboxExplosion;
    private bool explosion = false;
    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Enemy"))
        {
            if(!explosion){
          ExplosionParticles.Play();
        HitboxExplosion.SetActive(true);
            explosion = true;
            }
        }
    }
    void Update()
    {
        if(ExplosionParticles == null)  
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
