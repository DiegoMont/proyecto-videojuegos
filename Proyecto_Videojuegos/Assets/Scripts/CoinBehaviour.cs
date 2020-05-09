using UnityEngine;

public class CoinBehaviour : MonoBehaviour {
    
    void Update() {
        transform.Rotate(new Vector3(0f, -1.5f, 0f));
    }
}
