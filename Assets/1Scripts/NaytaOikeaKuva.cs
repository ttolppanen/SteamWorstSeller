using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaytaOikeaKuva : MonoBehaviour {

    public Sprite[] kuvat;//Pelaajasta päin 0 indeksi katsoo suoraan silmiin, 1 pelaajasta päin vähän oikealle, mutta kuitenkin näkyy etupuolta jonkun verran jne...
    SpriteRenderer spriteRenderer;
    GameObject pelaaja;
    Transform emo;
    float osienValinenKulma;

    void Start() {
        pelaaja = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        emo = transform.parent;
        osienValinenKulma = 360f / kuvat.Length;
    }

    void Update() {
        Vector3 suuntaPelaajaan = (pelaaja.transform.position - emo.position).normalized;
        float pelaajanJaVihollisenValinenKulma = Mathf.Acos(Vector3.Dot(suuntaPelaajaan, emo.forward)) * Mathf.Rad2Deg;
        if (float.IsNaN(pelaajanJaVihollisenValinenKulma))
        {
            pelaajanJaVihollisenValinenKulma = 0;
        }

        for (int i = 0; i <= kuvat.Length / 2; i++) //äh
        {
            if (pelaajanJaVihollisenValinenKulma < osienValinenKulma * (i + 1) - osienValinenKulma / 2)
            {
                spriteRenderer.sprite = kuvat[i];
                if ((i != 0 && i != kuvat.Length / 2) && KummallaPuolella(suuntaPelaajaan))
                {
                    spriteRenderer.sprite = kuvat[kuvat.Length - i];
                }
                break;
            }
            if (i == kuvat.Length / 2)
            {
                spriteRenderer.sprite = kuvat[i];
            }
        }
    }

    bool KummallaPuolella(Vector3 suuntaPelaajaan) //Onko pelaaja olion vasemmalla vai oikealla puolella, true on oikea puoli
    {
        float pelaajanJaOlionPistetuloSivusta = Vector3.Dot(suuntaPelaajaan, emo.right);
        if (pelaajanJaOlionPistetuloSivusta >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
