
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public float damageAdd = 0f;
    public float leechAmmount = 0.05f;
    public bool speedDmg = false;
    public float slowspeed = 1f;
    public float Xpmult = 1f;
    public float CannonMult = 1f;
    public int MineSpawnrate = 10;
    public bool StatueDamage = false; public bool StatueDamagee = false; public int statues = 0;
    public bool bloodlustTrue = false; public float bloodlust = 1f;    public float bloodlustTimes = 0f;
    void Update()
    {
        if(bloodlust > 1) bloodlust -= (0.01f - bloodlustTimes);
    }
}