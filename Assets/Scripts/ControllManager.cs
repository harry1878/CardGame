using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControllManager : MonoBehaviour
{
    private Camera mainCamera = null;
    private CardModule Select { get; set; } = null;

    public GameObject menu = null;
    public int cardSize = 0;
    private int releaseNumber = 0; 

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void OnStart()
    {
        releaseNumber = 0;
        Select = null;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit.collider == null) return;
            CardModule m = hit.collider.GetComponent<CardModule>();

            // 선택학 카드가 없을 경우
            if (Select == null)
            {
                Select = m;
                m.RotateAnimation(true);
            }
            //이전에 선택한카드 (Select)와
            //방금 선택한 카드 (m)가 같으면
            else if (Select.Equals(m))
            {
                m.RotateAnimation(false);
                Select = null;
            }
            //선택한 카드와 방금 선택한 카드가 다를 경우
            else
            {
                //Equals , ==
                //색이 같은 경우
                if(Select.CardColor.Equals(m.CardColor))
                {
                    Select.ReleaseAnimation();
                    m.ReleaseAnimation();

                    releaseNumber++;
                    if (cardSize == releaseNumber)
                    {
                        TimerModule module = FindObjectOfType<TimerModule>();
                        module.isUpdate = false;

                        menu.SetActive(true);
                        return;
                    }
                }
                else //색이 다를 경우
                {
                    Select.RotateAnimation(false);
                    m.RotateAnimation(false);
                    
                }
                Select = null;
            }
        }
    }
}
