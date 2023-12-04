using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class gameHandler : MonoBehaviour
{
    public Slider slider;

    float timer;
    float timer1;
    private float health=100;
    private float maxHealth=100;
    private void Update() {  timer = Time.time;
       
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        float temp = timer;
       // Debug.Log("collider");
       
        if (hit.gameObject.CompareTag("enmey") && temp > 1 + timer1 || (hit.gameObject.CompareTag("boss") && temp > 1 + timer1))
        {
           
            Damage(10);
              timer1 = temp;
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

