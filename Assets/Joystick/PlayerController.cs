using Cinemachine;
using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;


public class PlayerController : MonoBehaviour
{
    public Animator _player_Animator;
    public Transform _cam;
    public float _moveSpeed;
    public CinemachineVirtualCamera _playerCam;
    public VirtualJoystick _joystick;

    private void Start()
    {
        _player_Animator = this.GetComponent<Animator>();
    }

    public void Move(Vector2 inputDirection)
    {
        Vector2 moveInput = inputDirection;
        bool isMove = moveInput.magnitude != 0;
        _player_Animator.SetInteger("ACTION", 1);
        if (isMove)
        {
            Vector3 lookForward = new Vector3(_cam.forward.x, 0f, _cam.forward.z).normalized;
            Vector3 lookRight = new Vector3(_cam.right.x, 0f, _cam.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;
            transform.forward = moveDir;
            transform.position += moveDir * Time.deltaTime * _moveSpeed;
        }
    }

}
