using UnityEngine;
using System.Collections;

public class PlayerGuy : MonoBehaviour
{
    public int myId;
    public float kickForce;
    private Rigidbody myRB;
    private float hitTimer;

    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        hitTimer -= Time.deltaTime;
    }
    public void Kill()
    {
        GameManager.instance.SetPlayerDead(myId);
    }
    void OnCollisionEnter(Collision colleisson)
    {
        if (colleisson.gameObject.tag == "Player" && hitTimer <= 0)
        {
            EffetcHandly spawnEff = (EffetcHandly)AdditionalPool.instance.GetObject((int)additionalPool.effBump).MainScript;
            spawnEff.Set(transform.position);
            AudioCreatureHandly spawnAudio = (AudioCreatureHandly)AdditionalPool.instance.GetObject((int)additionalPool.audioPCol).MainScript;
            spawnAudio.Set(transform.position);
            Rigidbody enemyRB = colleisson.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDir = (transform.position - colleisson.gameObject.transform.position);
            enemyRB.AddForce(new Vector3(forceDir.x * myRB.velocity.x, forceDir.y * myRB.velocity.y, forceDir.z * myRB.velocity.z) * kickForce, ForceMode.Impulse);
            hitTimer = 0.25f;
        }
    }
}
