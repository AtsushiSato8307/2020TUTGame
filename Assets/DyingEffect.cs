using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DyingEffect : MonoBehaviour
{
    [SerializeField, Tooltip("瀕死時演出")]
    private PostProcessVolume postProcess;

    [Range(0, 1), SerializeField]
    private float maxIntensity;

    [SerializeField, Tooltip("フェード速度")]
    private float fadeSpeed;

    [SerializeField, Tooltip("危険HP")]
    private int warnninghp = 20;

    private Vignette dyingEffect;
    private GameObject player;
    private int playerhp;
    private float fadeValue;

    // Start is called before the first frame update
    void Start()
    {
        fadeValue = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        bool hasDtingEffect = postProcess.profile.TryGetSettings(out dyingEffect);
        dyingEffect.enabled.Override(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            playerhp = player.GetComponent<HitPoint>().currentHitPoint;
            if (playerhp <= warnninghp)
            {
                FadeInEffect(fadeSpeed);
            }
            else
            {
                FadeOutEffect(fadeSpeed);
            }
            dyingEffect.intensity.Override(fadeValue);
        }
    }
    #region フェード処理
    private void FadeInEffect(float FadeSpeed)
    {
        if (fadeValue <= maxIntensity)
        {
            fadeValue += Time.deltaTime * fadeSpeed;
        }
    }
    private void FadeOutEffect(float FadeSpeed)
    {
        if (fadeValue > 0)
        {
            fadeValue -= Time.deltaTime * fadeSpeed;
        }
    }
    #endregion
}

