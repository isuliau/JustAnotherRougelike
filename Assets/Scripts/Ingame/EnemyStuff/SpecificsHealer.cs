using UnityEngine;
using System.Collections;
using TMPro;
public class SpecificsHealer : MonoBehaviour
{
        [SerializeField] private GameObject HitboxHeal;
            private SpriteRenderer mySpriteRenderer;
            public GeneralEnemy generalEnemy;
            public float HealSpeed;
    void Start()
    { 
         StartCoroutine(CallFunctionRoutine());
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HeathHitbox"))
         {
      generalEnemy.Ehealth -= 0.5f; 
    }
    }
    private IEnumerator CallFunctionRoutine()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(HealSpeed); 
            yield return StartCoroutine(Heal());
        }
    }
private IEnumerator Heal()
    {
        HitboxHeal.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        HitboxHeal.SetActive(false);
    }
}
