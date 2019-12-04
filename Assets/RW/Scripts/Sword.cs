/*
 * Copyright (c) 2019 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using System.Collections;
public class Sword : MonoBehaviour
{
   /* [SerializeField]
    private SwordData swordData; // 1

    private void OnMouseDown() // 2
    {
        Debug.Log(swordData.SwordName); // 3
        Debug.Log(swordData.Description); // 3
        Debug.Log(swordData.Icon.name); // 3
        Debug.Log(swordData.GoldCost); // 3
        Debug.Log(swordData.AttackDamage); // 3
    }*/
    [SerializeField]
    private GameEvent OnSwordSelected; // 1

    private void OnMouseDown()
    {
        OnSwordSelected.Raise(); // 2
        StartCoroutine(slidePanel());
    }

    
    public Transform panel;
    private IEnumerator slidePanel()
    {
        /*
        int slidingDist = 10;
        Vector3 startPosition = new Vector3(panel.position.x, panel.position.y - slidingDist, panel.position.z);
        Vector3 endPosition = panel.position;//new Vector3(panel.position.x, panel.position.y + slidingDist, panel.position.z);
        */
        int slidingDist = 10;
        Vector3 startPosition = new Vector3(panel.position.x, panel.position.y + slidingDist, panel.position.z);
        Vector3 endPosition = panel.position;//new Vector3(panel.position.x, panel.position.y + slidingDist, panel.position.z);
        
        float startTime = Time.time;
        float startSliding = 0f;
        float durationSliding = 0.5f;
        while (startSliding < 1)
        //for (int i = 0; i < 1000;i++ )
        {
            startSliding = ((Time.time - startTime) / durationSliding);
            //Debug.Log(startSliding+" : " + Time.time +" : "+ startTime);
            float tmpSliding = Mathf.Lerp(startPosition.z, endPosition.z, Mathf.SmoothStep(0.0f, 1.0f, (float)startSliding));
            panel.position = Vector3.Lerp(startPosition, endPosition, Mathf.SmoothStep(0.0f, 1.0f, startSliding));
            yield return new WaitForSeconds(0.01f);            
        }
    }

   
}
