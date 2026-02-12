using UnityEngine;

public class SpawnRotation : MonoBehaviour
{
    public GameObject player;
    public int rotationSpeed = 300;

    private Vector3 offset;
    void Start()
    {
          offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         float rotationAmount = rotationSpeed * Time.deltaTime;


        offset = Quaternion.Euler(0f, 0f, rotationAmount) * offset;

        // we moving the position of the weapon to the player's + offset (the distance between them)
        transform.position = player.transform.position + offset;
        rotationSpeed = Random.Range(100, 500);
    }
}
