using UnityEngine;

public class MenuAudio : MonoBehaviour {

    public AudioClip Button;
    public AudioSource effectplayer;

    public void playClickSound() {
        effectplayer.PlayOneShot(Button);
    }
}
