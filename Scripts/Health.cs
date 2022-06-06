using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private Slider healthSlider;
    Color player;
    [SerializeField] private GameObject panelGameOver;
    public GameObject finishPanel;



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //HEALTH BAR --
            healthSlider.value -= 0.2f;
            animator.SetTrigger("hurt");
            if (healthSlider.value == 0f)
            {
                Die();
                StartCoroutine(Wait());
            }
            if (PlayerMovement.left == true)
            {
                transform.position = new Vector3((transform.position.x) + 1, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3((transform.position.x) - 1, transform.position.y, transform.position.z);
            }
        }
        if (other.gameObject.tag == "Finish")
        {
            Time.timeScale = 0f;
            //Social.ReportProgress("denemeid", 100.0f, (bool success) => {
            // handle success or failure});
            finishPanel.SetActive(true);

        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        animator.SetTrigger("isDie");
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        Die();
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject, 1.5f);
        Time.timeScale = 0f;
        panelGameOver.SetActive(true);
    }
}
