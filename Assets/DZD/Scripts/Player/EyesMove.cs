using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


    internal class EyesMove : MonoBehaviour
    {
        public Transform center;   
        public float radius = 1.0f; 

        void Update()
        {
            
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; 

            
            Vector3 direction = (mousePosition - center.position).normalized;

            
            Vector3 newPosition = center.position + direction * radius;

           
            transform.position = newPosition;
        }
    }
