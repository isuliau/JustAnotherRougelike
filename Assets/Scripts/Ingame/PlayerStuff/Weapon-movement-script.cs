using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public float rangeDivide = 1f;
    public GameObject player;
    public PopUpChooser popUpChooser;

    private Vector3 offset;

    void Start()
    {
    // this should be the distance to from the player to the weapon (I think??)
        offset = transform.position - player.transform.position;
        
    }

    void Update()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Rotate the offset, NOT the transform
        offset = Quaternion.Euler(0f, 0f, rotationAmount) * offset;

        // we moving the position of the weapon to the player's + offset (the distance between them)
        transform.position = player.transform.position + offset / rangeDivide;
    }
}
