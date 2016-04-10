using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SmallImageInSceneTransitionEffect : MonoBehaviour
{
    RectTransform rekki;
    // Use this for initialization


    // Update is called once per frame
    public float timeToLerp = 2;
    bool canLerp = true;
    float timeStartedLerp;

    public Color co_startColor;
    public Color co_targetColor;

    Color startColor;
    Color targetColor;
    bool isLerpping;
    Image image;


    float startScale = 1;
    float targetScale = 100;


    bool fadeOut;

    void Awake()
    {
        rekki = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        image.color = co_startColor;
        if (rekki.localScale.x >= 89) // Image is big. That means this is fade out transition!!
        {
            fadeOut = true;
        }

    }

    void OnEnable()
    {
        s();
    }

    void s()
    {
        if (!fadeOut)
        {
            StartLerp(co_startColor, co_targetColor, timeToLerp, 0, 100);
        }
        else
        {
            image.color = targetColor;
            StartLerp(co_targetColor, co_startColor, timeToLerp, 100, 0);
        }
    }

    public void StartLerp(Color startLenght, Color targetLenght, float time, float _startScale, float _targetScale)
    {
        timeToLerp = time;
        timeStartedLerp = Time.time;
        startColor = startLenght;
        targetColor = targetLenght;
        isLerpping = true;

        startScale = _startScale;
        targetScale = _targetScale;

        image.color = Color.Lerp(startColor, targetColor, 0); // lets start lerp so image wont flash when starting scale with 1. 
    }

    Vector3 curScale;

    void FixedUpdate()
    {
        if (isLerpping == true)
        {
            float timeSinceStarted = Time.time - timeStartedLerp;
            float percentage = timeSinceStarted / timeToLerp;
            image.color = Color.Lerp(startColor, targetColor, percentage);

            float scale = Mathf.Lerp(startScale, targetScale, percentage);

            Vector3 newScale = Vector3.one * scale;

            rekki.localScale = newScale;

            if (percentage > 1)
            {
                isLerpping = false;
            }
        }
    }
}

