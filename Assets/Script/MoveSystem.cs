using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * https://www.youtube.com/watch?v=uk_E_cGrlQcs
 */

public class MoveSystem : MonoBehaviour
{
    public GameObject correctForm;
    bool moving;
    bool finish;

    float startPosX;
    float startPosY;

    Vector3 resetPos;

    // Start is called before the first frame update
    void Start()
    {
        resetPos = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
		if (!finish)
		{
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
            }
        }
    }

	private void OnMouseDown()
	{
        Debug.Log("OnMouseDown() 실행: "+ gameObject.name);

		if (Input.GetMouseButtonDown(0))
		{
            Debug.Log("Input.GetMouseButtonDown(0) 실행: " + gameObject.name);

            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
            Debug.Log("moving = " + moving);
		}
	}

	private void OnMouseUp()
	{
        Debug.Log("OnMouseUp() 실행: " + gameObject.name);

        moving = false;
        Debug.Log("moving = " + moving);

        if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 0.5f &&
            Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 0.5f)
		{
            this.transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z);
            finish = true;
		}
		else
		{
            this.transform.localPosition = new Vector3(resetPos.x, resetPos.y, resetPos.z);

        }
	}
}
