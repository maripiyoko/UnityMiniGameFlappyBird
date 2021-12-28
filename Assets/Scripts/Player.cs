using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity = 2.4f;
    private Rigidbody2D _rigidbody;

    public GameManager gameManager;
    public bool isDead = true;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            _rigidbody.velocity = Vector2.up * velocity;
        }
    }

    public void Alive() {
        isDead = false;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "damage") {
            isDead = true;
            gameManager.GameOver();
        }
        
        if (collision.gameObject.tag == "point") {
            gameManager.increasePoint();
        }
    }
}
