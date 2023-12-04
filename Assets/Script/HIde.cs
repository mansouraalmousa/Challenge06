using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Hide : MonoBehaviour
{
  

    public GameObject[] game;
        public GameObject[] s;
        private int f;
    [SerializeField] AudioSource audioS;

    public void HideButtons()
        {
       audioS.Play();
            foreach (var item in game)
            {
                Debug.Log(item);
                item.SetActive(false);
                f++;
            }

            if (f >= 2)
            {
                foreach (var item in s)
                {
                    Debug.Log(item);
                    item.SetActive(true);

                }

            }

        }
    }
