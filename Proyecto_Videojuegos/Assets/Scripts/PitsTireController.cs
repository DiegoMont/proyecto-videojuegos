using UnityEngine;

public class PitsTireController : MonoBehaviour {

    public float velocidad;

    private void Update() {
        transform.Translate(new Vector3(velocidad, 0f, 0f));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Cone") {
            Debug.Log("Choco con un cono");
            Destroy(collision.gameObject);
        }
    }
}
