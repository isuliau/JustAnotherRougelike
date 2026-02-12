using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class WaveScript : MonoBehaviour
{
[SerializeField] private float countdown;
[SerializeField] private GameObject spawnPoint;
[SerializeField] private TextMeshProUGUI Text;
[SerializeField] private TextMeshProUGUI WaveText;
[SerializeField] private GameObject dificultySelector;

public Wave[] waves;
public int dificulty = 10;
private bool readycountdown;
public int currentWave = 1;
    private void Start()
    {
        readycountdown = true;
        for(int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
    }
    private void Update()
    {
        if(currentWave >= dificulty)
        {
            if(!dificultySelector.activeInHierarchy){
            SceneManager.LoadScene("Winar");
            Debug.Log("winar");}
            return;
        }
         if(readycountdown == true){
        countdown -= Time.deltaTime;
         }
        if(countdown <= 0)
        {
            readycountdown = false;
            countdown = waves[currentWave].TimeToNextWave;
            StartCoroutine(SpawnWave());
            
        }

        if (waves[currentWave].enemiesLeft == 0)
        {
            readycountdown = true;
            currentWave++;
        }
        
    }
private IEnumerator SpawnWave()
{
    WaveText.text = "Wave: " + (currentWave + 1) + "/" + dificulty;
    if(currentWave < waves.Length)
    {
        for(int i = 0; i < waves[currentWave].enemies.Length; i++)
        {
            Enemy enemy = Instantiate(waves[currentWave].enemies[i], spawnPoint.transform.position, Quaternion.identity);
            enemy.gameObject.SetActive(true);
            Text.text = "Enemies left: " + waves[currentWave].enemiesLeft;
            yield return new WaitForSeconds(waves[currentWave].TimeToNextEnemy);
        }
    }
}
}
[System.Serializable]
public class Wave
{
    public Enemy[] enemies;
    public float TimeToNextEnemy;
    public float TimeToNextWave;

public int enemiesLeft;
}