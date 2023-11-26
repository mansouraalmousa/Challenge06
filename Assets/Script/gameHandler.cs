using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class gameHandler : MonoBehaviour
{
    public Slider slider;
  
  
    private float health=100;
    private float maxHealth=100;
   


    private void OnCollisionEnter(Collision collision)
    {
        // Start is called before the first frame update

        
        if (collision.gameObject.CompareTag("enmey"))
        {
            Damage(20);
        }
    }
    // Update is called once per frame

    public void Damage(int damage)
    {
        health -= damage;
        slider.value = health;
        if (health <= 0) { health = 0; }
        if (slider.value <= 0) { Gameover(); }
    }
    public void heal(int heal)
    {
        health += heal;
        slider.value = health;
        if (health >= maxHealth) { health = maxHealth; }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Heal") && slider.value <= 100)
        {
            heal(10);
        }
    }
    void Gameover()
    {
        SceneManager.LoadScene("Gameover");
    }
}

