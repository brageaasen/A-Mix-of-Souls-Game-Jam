using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public Text text;
    [SerializeField] private string fadeText;

    private float fadeTime;
    private bool fading;

    // Start is called before the first frame update
    void Start()
    {
        this.text.CrossFadeAlpha(0, 0.0f, false);
        this.fadeTime = 0f;
        this.fading = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FadeIn()
    {
        this.text.CrossFadeAlpha(1, 0.5f, false);
        this.fadeTime += Time.deltaTime;

        if (this.text.color.a == 1 && this.fadeTime > 1.5f)
        {
            this.fading = false;
            this.fadeTime = 0f;
        }
    }

    void FadeOut()
    {
        this.text.CrossFadeAlpha(0, 0.5f, false);
        this.fadeTime += Time.deltaTime;

        //this.text.CrossFadeAlpha(0, 0.5f, false);  

        if (this.text.color.a == 0 && this.fadeTime > 1.5f)
        {
            this.fading = false;
            this.fadeTime = 0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.fading = true;

            // Text to be displayed
            this.text.text = this.fadeText;

            FadeIn();
        }
    }

    // Fade out
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            this.fading = true;
            FadeOut();
        }
    }
}
