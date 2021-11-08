using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{

    //config params
    [SerializeField] AudioClip destroyBlockAudio;
    [SerializeField] GameObject blockSparkelVFX;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;

    //state variables
    [SerializeField] int timesHit;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleBlockDistruction();
        }
    }

    private void HandleBlockDistruction()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit == maxHits)
        {
            RemoveBlock();
        }
        else {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite() {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null) {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else {
            Debug.LogError("Block sprite is missing from the array " + gameObject.name);
        }
    }

    private void RemoveBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        TriggerBlockBreakingVFX();
        level.whenBlockDestroyed();
    }

    private void PlayBlockDestroySFX() {
        AudioSource.PlayClipAtPoint(destroyBlockAudio, Camera.main.transform.position);
    }

    public void TriggerBlockBreakingVFX()
    {
        GameObject sparkels = Instantiate(blockSparkelVFX, transform.position, transform.rotation);
        Destroy(sparkels, 2F);
    }
}