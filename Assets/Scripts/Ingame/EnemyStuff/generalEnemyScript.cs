using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;
public class GeneralEnemy : MonoBehaviour
{
    public GameObject EHealthbar;
    [SerializeField] private Color EnemyColor;
     [SerializeField] private TextMeshProUGUI HealthText;
    public Xp xp;
    private WaveScript waveSpawner;
        public GameObject choiceHandler;
    public Healthbar Healthbar;
    public GameObject Enemy;
    public float Ehealth;
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private TextMeshProUGUI TextXp;
    [SerializeField] private GameObject player; 
    [SerializeField] private ParticleSystem damageParticles;
   private ParticleSystem damageParticlesInstance;

private float biggerspeed = 0;


 public EnemyData enemyData;
    private SpriteRenderer mySpriteRenderer;
    void Start()
    {
        waveSpawner = FindFirstObjectByType<WaveScript>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.color =  EnemyColor;
        Ehealth += (waveSpawner.dificulty + waveSpawner.currentWave)/30;
         if (mySpriteRenderer == null) mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private IEnumerator FlashColor() {
    mySpriteRenderer.color = new Color(0.549f, 0f, 0f, 1f);
    yield return new WaitForSeconds(0.3f);
    mySpriteRenderer.color = EnemyColor;
}
void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Weapon"))
    {
             if (enemyData.GetComponent<EnemyData>().speedDmg)
            {
                if(Math.Abs(player.GetComponent<Player>()._rb2d.linearVelocity.x) >= Math.Abs(player.GetComponent<Player>()._rb2d.linearVelocity.y))
                {biggerspeed = Math.Abs(player.GetComponent<Player>()._rb2d.linearVelocity.x);}
                else{biggerspeed = Math.Abs(player.GetComponent<Player>()._rb2d.linearVelocity.y);}
            }
            if(enemyData.StatueDamagee == true)biggerspeed += 1 + enemyData.statues;
            StartCoroutine(FlashColor());
            spawnDamageParticles();
       Ehealth -= 0.1f + enemyData.GetComponent<EnemyData>().damageAdd + (biggerspeed/15); 
    }
    if (other.CompareTag("MineHitbox"))
    {
StartCoroutine(FlashColor());
       Ehealth -= 0.6f; 
    }
    if (other.CompareTag("HeathHitbox"))
    {
       Ehealth += 0.5f; 
    }
}

private void spawnDamageParticles()
    {
    damageParticlesInstance = Instantiate(damageParticles, transform.position, Quaternion.identity);
    damageParticlesInstance.Play();damageParticlesInstance.Play();
    }

      void Update()
    {
        SpecificsBigGuy bigGuyScript = GetComponent<SpecificsBigGuy>();
        if(Ehealth <= 0){
        if (bigGuyScript != null)
        {
            bigGuyScript.SpawnMinionsIfPossible();
        }
      if(enemyData.bloodlustTrue) enemyData.bloodlust = 3f;
        waveSpawner.waves[waveSpawner.currentWave].enemiesLeft--;
        Text.text = "Enemies left: " + waveSpawner.waves[waveSpawner.currentWave].enemiesLeft; 
        Healthbar.GetComponent<Healthbar>().slider.value += enemyData.GetComponent<EnemyData>().leechAmmount;
        Healthbar.GetComponent<Healthbar>().SetHealth(Healthbar.GetComponent<Healthbar>().slider.value);
        HealthText.text = "HP: " + Healthbar.GetComponent<Healthbar>().slider.value + "/100";
        if(this.gameObject.GetComponent<NotXpGain>() == null)xp.GetComponent<Xp>().slider.value += 1.5f * enemyData.Xpmult;
        TextXp.text = "Xp: " + xp.GetComponent<Xp>().slider.value + "/" + xp.GetComponent<Xp>().slider.maxValue;
        xp.SetXp(xp.GetComponent<Xp>().slider.value);
        Destroy(EHealthbar);
        Destroy(Enemy);}
        if (bigGuyScript != null)
        {
                EHealthbar.transform.localScale = new Vector3(Ehealth/3, 0.1125f, 1f);            
        }
                else
        {
                EHealthbar.transform.localScale = new Vector3(Ehealth, 0.1125f, 1f);            
        }
        if(Healthbar.GetComponent<Healthbar>().slider.value <= 0){SceneManager.LoadScene("Lost");}
}}
