using UnityEngine;

public class RGB : MonoBehaviour
{
    SpriteRenderer bgColor;
    [SerializeField][Range(0f, 1f)] float lerpTime;

    [SerializeField] Color[] myColors;

    int colorIndex = 0;

    float t = 0f;

    int len;
    void Start()
    {
        bgColor = GetComponent<SpriteRenderer>();
        len = myColors.Length;
    }

    
    void Update()
    {
        bgColor.material.color = Color.Lerp(bgColor.material.color, myColors[colorIndex], lerpTime*Time.deltaTime);

        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        if (t > .9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
    }
}
