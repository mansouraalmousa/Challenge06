using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class GunRycast : MonoBehaviour
{
    public Camera playerc;
    public Transform laser;
    public float Grange = 50f;
    public float Frate = 0.2f;
    public float laserDuration = 0.05f;
    LineRenderer laserline;
    float firetimer;
    [SerializeField] GameObject Player;

    // Start is called before the first frame update
    void Awake()
    {
        laserline = GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        firetimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && firetimer > Frate)
        {
            firetimer = 0;
           
            
            RaycastHit hit;
            if (Physics.Raycast(Player.transform.position,Player.transform.forward, out hit, Grange))
            {
                if (hit.transform.gameObject.tag== "enmey")
                {
                    Destroy(hit.transform.gameObject);
                }
                
            }
           
            StartCoroutine(ShootLaser());
        }
    }
    IEnumerator ShootLaser()
    {
        laserline.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserline.enabled = false;
    }
}
