using UnityEngine;

public class PitsTireController : MonoBehaviour {

    private void Update() {
        transform.Translate(new Vector3(0.01f, 0f, 0f));
        if (transform.position.x > 9)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Cone") {
            Debug.Log("Choco con un cono");
            Destroy(collision.gameObject);
        }
    }
}
