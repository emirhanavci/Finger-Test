using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Coin : MonoBehaviour
{
    public static Coin instance;
    public bool finish = false;

    private void Start()
    {
        instance = this;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            finish = true;
            SoundManager.instance.PlayCoin();
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(0.9f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
