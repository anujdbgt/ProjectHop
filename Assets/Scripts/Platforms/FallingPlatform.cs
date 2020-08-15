using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallingPlatform : MonoBehaviour
{
    public float timeToDisappear = 2f;
    public int numberOfBlinks = 4;
    public float timeToReppear = 0.20f;
    public int reapearAfterSecs = 20;

    Tilemap tilemap;
    Rigidbody2D platform;
    Transform parentTransform;
    GameObject player;
    GameObject tileParent;
    Color tilemapColor;

    private void Awake()
    {
    }
    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
        platform = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        tileParent = this.transform.parent.gameObject;
        tilemapColor = tilemap.color;
    }
    private void Update()
    {
        if (!tileParent.activeSelf)
        {
            Debug.Log("Reactivationg the tile");
            StartCoroutine(TileReappear());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && PlayerAbovePlatform())
        {
            StartCoroutine(StartBlinking());
        }
    }

    IEnumerator StartBlinking()
    {
        for (int i = 0; i < numberOfBlinks; i++)
        {
            yield return new WaitForSeconds(timeToDisappear);
            tilemapColor.a = 0;
            tilemap.color = tilemapColor;
            yield return new WaitForSeconds(timeToReppear);
            tilemapColor.a = 1;
            tilemap.color = tilemapColor;
        }
        tileParent.SetActive(false);
    }

    IEnumerator TileReappear()
    {
        yield return new WaitForSeconds(reapearAfterSecs);
        tileParent.SetActive(true);
    }
    bool PlayerAbovePlatform()
    {
        if (player.transform.position.y > this.transform.position.y)
        {
            return true;
        }
        else return false;
    }
    
}
