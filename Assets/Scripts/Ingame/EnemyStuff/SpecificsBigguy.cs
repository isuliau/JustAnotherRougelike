using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class SpecificsBigGuy : MonoBehaviour
{
    

public GameObject minions;
    public WaveScript waveSpawner;
    public GeneralEnemy GeneralEnemy;
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private Renderer myRenderer;
    void Start()
    {
        myRenderer.material.color =Color.magenta;
    }

    public void SpawnMinionsIfPossible()
    {
      SpawnMinions();
      SpawnMinions();
    }

    void SpawnMinions()
{
        GameObject newMinion = Instantiate(minions, transform.position, Quaternion.identity);
        newMinion.SetActive(true);
        waveSpawner.waves[waveSpawner.currentWave].enemiesLeft++;
        Text.text = "Enemies left: " + waveSpawner.waves[waveSpawner.currentWave].enemiesLeft;
}
      
       
}
