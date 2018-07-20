using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 史莱姆的爆炸效果 
/// </summary>
public class Slem_red : MonoBehaviour
{
	[Header("References")]
	//private GameObject gemVisuals;
	public GameObject collectedParticleSystem;
	public CircleCollider2D gemCollider2D;


    [Header("史莱姆在地上滚动的时间")]

    public float SlideTimer = 3f;

    private float durationOfCollectedParticleSystem;


	void Start()
	{
		durationOfCollectedParticleSystem = collectedParticleSystem.GetComponent<ParticleSystem>().main.duration;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag ("Enemy")) {
			GemCollected ();
		}
        else
        {
            StartCoroutine(AutoGem());
        }
       
    }

    IEnumerator AutoGem()
    {
        yield return new WaitForSeconds(SlideTimer);
        GemCollected();
    }
 

	void GemCollected()
	{
        //gemCollider2D.enabled = false;
        transform.gameObject.SetActive(false);
        //collectedParticleSystem.SetActive (true);
        GameObject redObj=Instantiate(collectedParticleSystem, transform.position+new Vector3(0,0,-1),Quaternion.identity);
        redObj.AddComponent<DestroyObject>();
        redObj.GetComponent<DestroyObject>().timer = durationOfCollectedParticleSystem + 0.2f;
        redObj.layer = 1;
        Destroy(gameObject,3f);

     //   Invoke ("DeactivateGemGameObject", durationOfCollectedParticleSystem);


    }

	
}
