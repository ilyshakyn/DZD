using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.DZD.Scripts.Player
{
    internal class LegsAnimation: MonoBehaviour
    {
        [SerializeField] private Animator animator;        
        private MovePlayer player;
        private void Start()
        {
            player = GetComponent<MovePlayer>();
        }
        private void Update()
        {
            UpdateAnimation();
        }
        private void UpdateAnimation()
        {
           
            bool isRunning = Mathf.Abs(player.horizontal) > 0.1f;
            animator.SetBool("IsRunning", isRunning);

            
            animator.SetBool("IsGrounded", player.isGrounded);
        }
    }
}
