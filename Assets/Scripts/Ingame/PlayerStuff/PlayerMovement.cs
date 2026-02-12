using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
using TMPro;
public class Player : MonoBehaviour
{
    [SerializeField]
    private string _HorizontalAxis = "Horizontal", _verticalAxis = "Vertical";
    [SerializeField]
    public Rigidbody2D _rb2d;
    public EnemyData enemyData;
    public Healthbar healthbar;
    private Vector2 _input;
    public Renderer myRenderer;
    [SerializeField] private TextMeshProUGUI HealthText;
        public float SpeedMult = 1f;
    private void Start()
    {
         myRenderer = GetComponent<Renderer>();
        myRenderer.material.color = new Color (1, 0, 0, 1);
    }
    void FixedUpdate()
    {
        _rb2d.linearVelocity = Vector2.Lerp(_rb2d.linearVelocity, _input*3*SpeedMult*enemyData.bloodlust, 0.1f);    
        }
    void Update()
    {
if(enemyData.StatueDamage && _rb2d.linearVelocity == Vector2.zero){enemyData.StatueDamagee = true;}else{enemyData.StatueDamagee = false;}
        
        float verticalInput = Input.GetAxisRaw(_verticalAxis);
        float HorizontalInput = Input.GetAxisRaw(_HorizontalAxis);
        _input = new Vector2(HorizontalInput, verticalInput);  
    }
  
  public bool isInvincible = false;  
  public float InvincibiltyLength = 1f;
 private IEnumerator BecomeTemporarilyInvincible()
{
if(isInvincible) {
    
yield break;
}
isInvincible = true;
        myRenderer.material.color = Color.gray;
        yield return new WaitForSeconds(InvincibiltyLength);
        myRenderer.material.color = new Color (1, 0, 0, 1);
    
    isInvincible = false;
}
  void OnTriggerStay2D(Collider2D other)
{    
    if (other.IsTouching(GetComponent<Collider2D>())){
    if (other.CompareTag("Enemy")){
            if(isInvincible) return;
            healthbar.GetComponent<Healthbar>().slider.value -= 7.5f+enemyData.GetComponent<EnemyData>().CannonMult;
            healthbar.SetHealth(healthbar.GetComponent<Healthbar>().slider.value);
             if(healthbar.GetComponent<Healthbar>().slider.value <= 0){SceneManager.LoadScene("Lost");}
    HealthText.text = "HP: " + healthbar.GetComponent<Healthbar>().slider.value + "/100";
    StartCoroutine(BecomeTemporarilyInvincible());
    
    }} 
}

}

    //conventions: 
    //  camelCase: typeLikeThisBecauseItMakesItReadableWhileStillBeingAllInOneWord
    //  private variables: private variables are like this _speed (this didnt age well)