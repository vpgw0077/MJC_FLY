using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JumpButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI jumpCountTxt = null;
    private CharacterController characterController = null;
    private Button jumpButton = null;


    private void Start()
    {
        characterController = FindObjectOfType<CharacterController>();
        jumpButton = GetComponent<Button>();
        jumpButton.onClick.AddListener(characterController.Jump);
        characterController.JumpEvent += UpdateJumpCount;

        // 게임 시작 시 점프 횟수를 표시하기 위해 한 번만 여기서 횟수 업데이트
        UpdateJumpCount();
    }

    private void UpdateJumpCount()
    {
        jumpCountTxt.text = "x" + characterController.GetJumpCount().ToString();
    }

}