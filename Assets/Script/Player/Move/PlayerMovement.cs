using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AgentMovement
{
    [SerializeField]
    private Transform _visualSpriteTrm = null;

    private bool _filp = false;

    private float _hori;
    private float _verti;
    private Vector2 _dashDir = Vector2.zero;

    protected override void Update()
    {
        base.Update();

        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = _rigid.velocity.y;

        if(_rigid.velocity.y <= -15f)
        {
            _moveDir = new Vector2(_moveDir.x, -15f);
        }

        _hori = Input.GetAxisRaw("Horizontal");
        _verti = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _filp = _visualSpriteTrm.localScale.x < 0f;
            _dashDir.x = _hori;
            _dashDir.y = _verti;

            if(_filp)
            {
                if(_dashDir == Vector2.zero)
                {
                    Dash(Vector2.left);
                }
                else
                {
                    Dash(_dashDir.normalized);
                }
            }
            else
            {
                if (_dashDir == Vector2.zero)
                {
                    Dash(Vector2.right);
                }
                else
                {
                    Dash(_dashDir.normalized);
                }
            }
        }
    }

    public void DashEnable()
    {
        _dashable = true;
    }
    public void DashDisable()
    {
        _dashable = false;
    }
}
