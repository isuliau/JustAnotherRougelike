
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject Choicehandler;
    public EnemyData enemyData;
    public float followspeed = 1f;

void Update()
{
    if(Time.timeScale == 0) return;
    float speed = (followspeed / enemyData.slowspeed) * Time.deltaTime;
    
    Vector3 desiredPosition = player.transform.position;
    transform.position = Vector3.Lerp(transform.position, desiredPosition, speed);
    
    transform.eulerAngles = new Vector3(0f, 180f, 0f);
}
}