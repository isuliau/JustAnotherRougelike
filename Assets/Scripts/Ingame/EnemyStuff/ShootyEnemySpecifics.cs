using UnityEngine;
using System.Collections;
using TMPro;
public class SpecificsShootyEnemy : MonoBehaviour
{

[SerializeField] private GameObject bullet;
 public WaveScript waveSpawner;
[SerializeField] private TextMeshProUGUI Text;
    void Start()
    {
         StartCoroutine(CallFunctionRoutine());
        
    }
    private IEnumerator shoot(){
    
        transform.localScale += new Vector3(0.5f, 0.5f, 0);
       GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.SetActive(true); 
        waveSpawner.waves[waveSpawner.currentWave].enemiesLeft++;
        Text.text = "Enemies left: " + waveSpawner.waves[waveSpawner.currentWave].enemiesLeft;
        yield return new WaitForSeconds(0.2f);
        transform.localScale -= new Vector3(0.5f, 0.5f, 0);
 } 
private IEnumerator CallFunctionRoutine()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(3); 
            yield return StartCoroutine(shoot());
        }
    }
}
