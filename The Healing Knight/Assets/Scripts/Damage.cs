// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class Damage : MonoBehaviour
// {
//     [SerializeField] private float attackDamage = 10f;
//     [SerializeField] private float attackSpeed = 1f;
//     private float canAttack;
//     [SerializeField] private Slider healthSlider;
//     Color player;
//     [SerializeField] private GameObject panel;


//     private void OnCollisionStay2D(Collision2D other)
//     {
//         if (other.gameObject.tag == "Player")
//         {
//             other.gameObject.GetComponent<Health>().UpdateHealth(-attackDamage);
//             //HEALTH BAR --
//             healthSlider.value -= 0.25f;
//             if (healthSlider.value == 0f)
//             {
//                 Time.timeScale = 0f;
//                 //gameover gelecek
//             }
//         }
//     }

// }
