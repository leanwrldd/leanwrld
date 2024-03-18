using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class karakterHaraketi : MonoBehaviour
{
    public float karakterHizi;
    public float ziplamaGucu = 5f;
    public Rigidbody2D rb;
    bool ziplamaKontrol = false;
    bool oyunBitti = false;

    void Update()
    {
        if (!oyunBitti)
        {
            karakterHareketi();

            if (Input.GetKeyDown(KeyCode.Space) && !ziplamaKontrol && Mathf.Approximately(rb.velocity.y, 0))
            {
                Zipla();
            }
        }
    }

    void karakterHareketi()
    {
        float yatayHareket = Input.GetAxis("Horizontal") * karakterHizi * Time.deltaTime;

        // Sadece yön tuþlarýna izin vermek için kontrol ekle
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(yatayHareket, 0, 0);

            if (yatayHareket > 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (yatayHareket < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            Zipla();
        }


    }

    void Zipla()
    {
        rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
        ziplamaKontrol = true;
        Invoke("ZiplamaKontrol", 0.1f);
    }

    void ZiplamaKontrol()
    {
        ziplamaKontrol = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            OyunuBitir();
        }
    }

    void OyunuBitir()
    {
        oyunBitti = true;
        rb.velocity = Vector2.zero;
        SceneManager.LoadScene("OyunBitti");
    }
}
