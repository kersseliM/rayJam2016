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
        EffetcHandly spawnEff = (EffetcHandly)AdditionalPool.instance.GetObject((int)additionalPool.effPDeth).MainScript;
        spawnEff.Set(transform.position);
        EffetcHandly spawnEff2 = (EffetcHandly)AdditionalPool.instance.GetObject((int)additionalPool.effPDethGlow).MainScript;
        spawnEff2.Set(transform.position);
        EffetcHandly spawnEff3 = (EffetcHandly)AdditionalPool.instance.GetObject((int)additionalPool.effPDethRay).MainScript;
        spawnEff3.Set(transform.position);
        switch(myId)
        {
            case 0:
                AudioCreatureHandly spawnAudio1 = (AudioCreatureHandly)AdditionalPool.instance.GetObject((int)additionalPool.audioP1D).MainScript;
                spawnAudio1.Set(transform.position);
                break;
            case 1:
                AudioCreatureHandly spawnAudio2 = (AudioCreatureHandly)AdditionalPool.instance.GetObject((int)additionalPool.audioP2D).MainScript;
                spawnAudio2.Set(transform.position);
                break;
            case 2:
                AudioCreatureHandly spawnAudio3 = (AudioCreatureHandly)AdditionalPool.instance.GetObject((int)additionalPool.audioP3D).MainScript;
                spawnAudio3.Set(transform.position);
                break;
            case 3:
                AudioCreatureHandly spawnAudio4 = (AudioCreatureHandly)AdditionalPool.instance.GetObject((int)additionalPool.audioP4D).MainScript;
                spawnAudio4.Set(transform.position);
                break;
            default:
                AudioCreatureHandly spawnAudio5 = (AudioCreatureHandly)AdditionalPool.instance.GetObject((int)additionalPool.audioP4D).MainScript;
                spawnAudio5.Set(transform.position);
                break;
        }
        Destroy(gameObject);
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
    public Rigidbody GetRB()
    {
        return myRB;
    }
}
