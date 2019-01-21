using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public Texture muted;
    public Texture unmuted;
    public RawImage image;

    private bool isMute = false;

    public void mute()
    {
        Debug.Log("Pressed");

        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;

        if(isMute)
        {
            Debug.Log("muted");
            image.texture = muted;
        } else
        {
            Debug.Log("unmuted");
            image.texture = unmuted;
        }
    }

}
