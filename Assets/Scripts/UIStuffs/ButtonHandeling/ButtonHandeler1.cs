using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;
public class ButtonHandeler : MonoBehaviour
{
        public GameObject choices;
        public Weapon weapon;
        public Player player;   
        public mineSpawner mineSpawner;
        public EnemyData enemyData;
        public Xp xp;
            public int luck = 0;
    private int bloodlustammount = 0;
    private int mineAmmount = 0;
    public void OnClick(PopUpChooser clickedCard) 
{
    Time.timeScale = 1;
    choices.SetActive(false);

    int index = clickedCard.CardIndex1;

    // Common
    if(index <= 5) weapon.rangeDivide += 0.1f;
    if(index >= 6 && index <= 10) player.InvincibiltyLength += 0.5f;
    if(index >= 11 && index <= 20) player.SpeedMult += 0.25f;
    if(index >= 21 && index <= 30) enemyData.damageAdd += 0.1f;
    
    // Rare
    if(index >= 31 && index <= 50) {enemyData.StatueDamage = true; enemyData.statues++;}
    if(index >= 51 && index <= 60) luck += 10;
    if(index >= 61 && index <= 70){ if(bloodlustammount < 9){enemyData.bloodlustTrue = true; enemyData.bloodlustTimes += 0.001f; bloodlustammount++;}}
    // Epic
    if(index >= 71 && index <= 77) enemyData.slowspeed += 0.2f;
    if(index >= 78 && index <= 84){ enemyData.damageAdd += 0.3f; enemyData.CannonMult += 5;}
    if(index >= 85 && index <= 90){ enemyData.leechAmmount += 0.5f;}
    // Legendary
    if(index > 90 && index <= 95) enemyData.Xpmult += 0.5f;
    if(index > 95 && index <= 99) enemyData.speedDmg = true;
    if(index > 99){ if(mineAmmount < 9){mineSpawner.spawnminess = true; enemyData.MineSpawnrate -= 1; mineAmmount++;}}

    xp.levelup = false;
}}


