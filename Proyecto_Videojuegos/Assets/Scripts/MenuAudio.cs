using UnityEngine;

public class MenuAudio : MonoBehaviour {

    public AudioClip Button, Bought, NotMoney, Items;
    public AudioSource effectplayer;

    public void playClickSound() {
        effectplayer.PlayOneShot(Button);
    }

    public void playStoreSound(int soundtoPlay)
    {
        if (soundtoPlay == 0)
        {
            effectplayer.PlayOneShot(NotMoney);
        }
        else
        {
            effectplayer.PlayOneShot(Bought);
        }
    }

    public void ItemsSound()
    {
        effectplayer.PlayOneShot(Items);
    }
}
