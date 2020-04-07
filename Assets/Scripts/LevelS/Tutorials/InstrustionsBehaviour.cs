using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrustionsBehaviour : MonoBehaviour
{
    public RectTransform rightJump;
    public RectTransform leftJump;

    public bool activated = false;
    private void Start()
    {
        RightJumpSize();
        LeftJumpSize();
    }

    private void Update()
    {
        if (!activated)
        {
            Activate();
        }
    }
    void RightJumpSize()
    {
        rightJump.sizeDelta = new Vector2(Screen.width / 2, rightJump.sizeDelta.y);
        rightJump.position = new Vector3((Screen.width / 4) * 3, rightJump.position.y, rightJump.position.z);
    }
    void LeftJumpSize()
    {
        leftJump.sizeDelta = new Vector2(Screen.width / 2, leftJump.sizeDelta.y);
        leftJump.position = new Vector3( Screen.width / 4, leftJump.position.y, leftJump.position.z);
    }

    void Activate()
    {
        if (!GameState.GamePaused)
        {
            rightJump.gameObject.SetActive(true);
            leftJump.gameObject.SetActive(true);
            activated = true;
        }
    }
}
