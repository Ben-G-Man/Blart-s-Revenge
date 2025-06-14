using UnityEngine;

public class SmokeFadeQuad : MonoBehaviour
{
    private Material matInstance;
    private float lifetime;
    private float fadeTime;
    private float timer;

    public void Init(float totalLifetime, float fadeDuration)
    {
        LineRenderer rend = GetComponent<LineRenderer>();
        matInstance = rend.material; // Create a unique instance of the material
        lifetime = totalLifetime;
        fadeTime = fadeDuration;
        timer = 0f;

        Color color = matInstance.color;
        matInstance.color = new Color(color.r, color.g, color.b, 1f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= (lifetime - fadeTime))
        {
            float t = Mathf.Clamp01((timer - (lifetime - fadeTime)) / fadeTime);
            Color c = matInstance.color;
            matInstance.color = new Color(c.r, c.g, c.b, 1f - t);
        }

        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}