using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class karakterHaraketi2 : MonoBehaviour
{
    public float karakterHizi;
    public float ziplamaGucu = 5f;
    public Rigidbody2D rb;
    bool oyunBitti = false;
    bool ziplamaKontrol2;

    void Update()
    {
        if (!oyunBitti)
        {
            karakterHareketi2();

        }
    }

    
    void karakterHareketi2()
    {
        float yatayHareket = 0f;

        // Sadece WASD tu�lar�na izin vermek i�in kontrol ekle
        if (Input.GetKey(KeyCode.D))
        {
            yatayHareket = karakterHizi * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            yatayHareket = -karakterHizi * Time.deltaTime;
        }

        // Sadece W tu�una bas�ld���nda z�plama
        if (Input.GetKeyDown(KeyCode.W))
        {
            Zipla2();
        }

        transform.Translate(yatayHareket, 0, 0);
    }

    void Zipla2()
    {
        rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
        ziplamaKontrol2 = true;
        Invoke("ZiplamaKontrol2", 0.1f);
    }

    void ZiplamaKontrol2()
    {
        ziplamaKontrol2 = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            OyunuBitir2();
        }
    }

    void OyunuBitir2()
    {
        oyunBitti = true;
        rb.velocity = Vector2.zero;
        SceneManager.LoadScene("OyunBitti");
    }
}
