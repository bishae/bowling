using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;

    private bool _hasFallen = false;

    private void FixedUpdate()
    {
        if (rigidbody.velocity.magnitude > 0.0f)
        {
            rigidbody.velocity = rigidbody.velocity * 0.95f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rigidbody.velocity.magnitude > 0 && !_hasFallen)
        {
            _hasFallen = true;
            Debug.Log("Score");
            GameManager.Instance.Score();
        }
    }
}
