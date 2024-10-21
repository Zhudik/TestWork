using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public TMP_Text m_TextMeshPro;
    private int items = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            items++;
            m_TextMeshPro.text = $"{items}/3";
        }
        if(items == 3)
        {
            m_TextMeshPro.text = "гар";
        }
    }
}
