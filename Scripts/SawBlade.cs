using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SawBlade : MonoBehaviour
{
    public float rotationSpeed = 180f;

void Update()
{
    transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
}

void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Ball"))
    {
        Debug.Log("Hit Ball!");
        GameManager.Instance.ReduceHealth(1);
        // Visual feedback placeholder: flash effect, animation etc.
    }
}
}