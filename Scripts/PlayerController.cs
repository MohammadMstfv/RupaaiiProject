using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = new Vector3(touch.position.x, touch.position.y, 0);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(touchPos);
            worldPos.z = 0f;
            transform.position = Vector3.Lerp(transform.position, worldPos, moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.IncreaseScore();
        }
    }
}