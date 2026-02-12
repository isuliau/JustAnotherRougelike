using UnityEngine;
using System.Collections;
public class mineSpawner : MonoBehaviour
{
    public GameObject mines;
   public PopUpChooser popUpChooser;
    public GameObject player;
    public GameObject mineHitbox;
    public EnemyData enemyData;
    private bool idkhowthisworks = false;
    public bool spawnminess = false;
    void Update()
    {           
        transform.position = player.transform.position;
    }
    void Start()
    {
         StartCoroutine(CallFunctionRoutine());
 InvokeRepeating("spawnmines", 0 , 10);
    }
    private IEnumerator spawnmines()
    { 
        if(Time.timeScale != 0)
        if(spawnminess)
    {

        GameObject newMine = Instantiate(mines, player.transform.position, Quaternion.identity);
        newMine.SetActive(true); mineHitbox.SetActive(false);
            if (!idkhowthisworks)
            {
                Destroy(newMine);
            }
            idkhowthisworks = true;
          yield return 0;}
    }
     
     private IEnumerator CallFunctionRoutine()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(enemyData.MineSpawnrate);
            yield return StartCoroutine(spawnmines());
        }
    }

    }
    

