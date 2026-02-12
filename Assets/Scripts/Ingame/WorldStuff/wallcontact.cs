    using UnityEngine;
    using System.Collections;
    public class WallContact : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
{
    other.transform.position = Vector3.zero;
}
}