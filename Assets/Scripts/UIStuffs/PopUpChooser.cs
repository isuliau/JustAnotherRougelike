using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
public class PopUpChooser : MonoBehaviour
{
    public Xp Xp;
    [SerializeField] private TextMeshProUGUI Choice;
    [SerializeField] private TextMeshProUGUI Description;
        [SerializeField] private TextMeshProUGUI rarity1;


      public Image image1;
    public TextMeshProUGUI TextXp;
    public ButtonHandeler ButtonHandeler;

        public GameObject choices;
    public int CardIndex1;


  
    public void levelup()
    {
          Time.timeScale = 0;
           ChooseCard();
               Xp.GetComponent<Xp>().slider.value = 0f;
    TextXp.text = "Xp: " + Xp.GetComponent<Xp>().slider.value + "/" + Xp.GetComponent<Xp>().slider.maxValue;
    }

    private void ChooseCard()
    {
        //normal
         CardIndex1 = Random.Range(1, 101) + ButtonHandeler.GetComponent<ButtonHandeler>().luck;
if(CardIndex1 <= 5){
   Choice.text = "Range Down";
   Description.text = "Decrease the range of your weapon";
   image1.color = new Color(1f, 1f , 1f, 1f);
    } 
    if(CardIndex1 >= 6 && CardIndex1 <= 10){
   Choice.text = "Long Invincibility";
   Description.text = "Makes you gray longer";
   image1.color = new Color(1f, 1f , 1f, 1f);
    } 
if(CardIndex1 >= 11 && CardIndex1 <= 20){
      Choice.text = "Speed Up";
   Description.text = "Increase your movement speed";
   image1.color = new Color(1f, 1f , 1f, 1f);
    } 
if(CardIndex1 >= 21 && CardIndex1 <= 30){
      Choice.text = "Damage Up";
   Description.text = "Increase all damage";
   image1.color = new Color(1f, 1f , 1f, 1f);
    } 
    //rare
if(CardIndex1 >= 31 && CardIndex1 <= 50){
      Choice.text = "Statue";
   Description.text = "Standing still boosts your damage";
   image1.color = new Color(0f, 0.02f , 0.761f, 1f);
    } 
if(CardIndex1 >= 51 && CardIndex1 <= 60){
   Choice.text = "Luckier Cards";
   Description.text = "Increases the chance of better upgrades";
   image1.color = new Color(0f, 0.02f , 0.761f, 1f);
    } 
    if(CardIndex1 >= 61 && CardIndex1 <= 70){
   Choice.text = "Bloodlust";
   Description.text = "Gain a speed burst when killing an enemy";
   image1.color = new Color(0f, 0.02f , 0.761f, 1f);
    } 
    //epic
if(CardIndex1 >= 71 && CardIndex1 <= 77){
   Choice.text = "Slower Enemies";
   Description.text = "Slow down enemies";
   image1.color = new Color(0.506f, 0f, 0.859f, 1f);
    }
if(CardIndex1 >= 78 && CardIndex1 <= 84){
   Choice.text = "Glass Cannon";
   Description.text = "Less health, more damage";
   image1.color = new Color(0.506f, 0f, 0.859f, 1f);
}
   if(CardIndex1 >= 85 && CardIndex1 <= 90){
   Choice.text = "Leech Up";
   Description.text = "Heal more when enemies die";
    image1.color = new Color(0.506f, 0f, 0.859f, 1f);
   }
    //legendary    

if(CardIndex1 > 90 && CardIndex1 <= 95){
   Choice.text = "More XP ";
   Description.text = "Makes getting upgrades easier";
   image1.color = new Color(1f, 0.988f, 0.18f, 1f);
          }
if(CardIndex1 > 95 && CardIndex1 <= 99){
   Choice.text = "Speed is Damage";
   Description.text = "More speed More damage (doesn't Stack)";
   image1.color = new Color(1f, 0.988f, 0.18f, 1f);
      }
if(CardIndex1 > 99){
   Choice.text = "Minefield";
   Description.text = "Drop mines as you walk";
   image1.color = new Color(1f, 0.988f, 0.18f, 1f);
      }

if(CardIndex1 <= 30){ rarity1.text = "Common";} 
if(CardIndex1 > 30 && CardIndex1 <= 70) {rarity1.text = "Rare";} 
if(CardIndex1 > 70 && CardIndex1 <= 90) {rarity1.text = "Epic"; }
if(CardIndex1 > 90){ rarity1.text = "Legendary"; }

     
    }
  
}
