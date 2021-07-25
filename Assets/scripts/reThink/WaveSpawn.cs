using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour
{
    public Text WaveCountDown;
    public Transform blueGuy;
    public Transform croco;
    public Transform grenouille;
    public Transform slim;
    public Transform redguy;
    public float TempsEntreWave = 5f;
    private float countDown = 2;
    private int wavenumber=0;
    public Transform StartPoint;
    public float TempsEntreEnemyInAWave = 0.5f;
    private bool newNumber ;
    public Text WaveNumberText;

    private int[][] lesWaves = new int[30][];
    void Start()
    {

        newNumber = true;

        lesWaves[0] = new int[] { 0, 1, 0, 0, 0 };
        lesWaves[1] = new int[] { 1, 0, 2, 0, 1 };
        lesWaves[2] = new int[] { 0, 2, 3, 0, 2 };
        lesWaves[3] = new int[] { 0, 5, 3, 2, 4 };
        lesWaves[4] = new int[] { 0, 20, 0, 0, 0 };
        lesWaves[5] = new int[] { 6, 6, 7, 2, 4 };
        lesWaves[6] = new int[] { 3, 0, 16, 1, 5};
        lesWaves[7] = new int[] { 1, 6, 2, 3, 4 };
        lesWaves[8] = new int[] { 3, 0, 10, 0, 8 };
        lesWaves[9] = new int[] { 0, 15, 9, 0, 12 };
        lesWaves[10] = new int[] { 0, 3, 1, 2, 1 };
        lesWaves[11] = new int[] { 4, 0, 6, 0, 1 };
        lesWaves[12] = new int[] { 0, 7, 3, 0, 9 };
        lesWaves[13] = new int[] { 0, 5, 3, 2, 4 };
        lesWaves[14] = new int[] { 0, 20, 0, 0, 0 };
        lesWaves[15] = new int[] { 6, 6, 7, 2, 4 };
        lesWaves[16] = new int[] { 3, 0, 16, 1, 5 };
        lesWaves[17] = new int[] { 1, 6, 2, 3, 4 };
        lesWaves[18] = new int[] { 3, 0, 10, 0, 8 };
        lesWaves[19] = new int[] { 0, 15, 9, 0, 12 };
        lesWaves[20] = new int[] { 0, 3, 2, 0, 5 };
        lesWaves[21] = new int[] { 2, 0, 6, 1, 1 };
        lesWaves[22] = new int[] { 0, 5, 3, 0, 2 };
        lesWaves[23] = new int[] { 0, 5, 3, 2, 4 };
        lesWaves[24] = new int[] { 0, 20, 0, 0, 0 };
        lesWaves[25] = new int[] { 6, 6, 7, 2, 4 };
        lesWaves[26] = new int[] { 3, 0, 16, 1, 5 };
        lesWaves[27] = new int[] { 1, 6, 2, 3, 4 };
        lesWaves[28] = new int[] { 3, 0, 10, 0, 8 };
        lesWaves[29] = new int[] { 0, 15, 9, 0, 12 };

        WaveNumberText.text = wavenumber.ToString();
    }
    
    void Update()
    {
        if(wavenumber == 11  && newNumber == true)
        {

            enemy e = blueGuy.GetComponent<enemy>();
            e.SetNewHealth(3f);
            e.SetNewSpeed(1.25f);

            Debug.Log(e.GetNewHealth());

            enemy f = croco.GetComponent<enemy>();
            f.SetNewHealth(3f);
            f.SetNewSpeed(1.25f);

            enemy g = slim.GetComponent<enemy>();
            g.SetNewHealth(3f);
            g.SetNewSpeed(1.25f);

            enemy h = redguy.GetComponent<enemy>();
            h.SetNewHealth(3f);
            h.SetNewSpeed(1.25f);

            enemy i = grenouille.GetComponent<enemy>();
            i.SetNewHealth(3f);
            i.SetNewSpeed(1.25f);

            newNumber = false;
        }
        if(wavenumber == 21 && newNumber == false)
        {
            enemy e = blueGuy.GetComponent<enemy>();
            e.SetNewHealth(2f);
            e.SetNewSpeed(1.25f);

            enemy f = croco.GetComponent<enemy>();
            f.SetNewHealth(2f);
            f.SetNewSpeed(1.25f);

            enemy g = slim.GetComponent<enemy>();
            g.SetNewHealth(2f);
            g.SetNewSpeed(1.25f);

            enemy h = redguy.GetComponent<enemy>();
            h.SetNewHealth(2f);
            h.SetNewSpeed(1.25f);

            enemy i = grenouille.GetComponent<enemy>();
            i.SetNewHealth(2f);
            i.SetNewSpeed(1.25f);

            newNumber = true;
        }

        
        if (countDown <= 0)
        {
            wavenumber++;
            WaveNumberText.text = wavenumber.ToString();
            StartCoroutine(newWave());
            countDown = TempsEntreWave;
        }
        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        WaveCountDown.text = string.Format("{0:00.00}", countDown);

        if(PlayerStat.lives <= 0 || wavenumber >= 30)
        {
            wavenumber = 0;
        }

		if (Input.GetKeyDown(KeyCode.Space))
		{
            countDown = 0;
		}
    }

    IEnumerator newWave()
    {
       for (int i= 0; i < lesWaves[wavenumber-1][0]; i++)
            {
                spawnenemy(blueGuy);
                yield return new WaitForSeconds(TempsEntreEnemyInAWave);
            }
            for (int i = 0; i < lesWaves[wavenumber-1][1]; i++)
            {
                spawnenemy(grenouille);
                yield return new WaitForSeconds(TempsEntreEnemyInAWave);
            }

            for (int i = 0; i < lesWaves[wavenumber-1][2]; i++)
            {
                spawnenemy(croco);
                yield return new WaitForSeconds(TempsEntreEnemyInAWave);
            }

            for (int i = 0; i < lesWaves[wavenumber-1][3]; i++)
            {
                spawnenemy(slim);
                yield return new WaitForSeconds(TempsEntreEnemyInAWave);
            }

            for (int i = 0; i < lesWaves[wavenumber-1][4]; i++)
            {
                spawnenemy(redguy); 
                 yield return new WaitForSeconds(TempsEntreEnemyInAWave);
            }
            
        PlayerStat.RoundsSurvived++;
        
       
        
        if (wavenumber%5 == 0)
        {
            TempsEntreWave += 5;
        }
        
    }

    void spawnenemy(Transform enemy)
    {
        Instantiate(enemy, StartPoint.position, StartPoint.rotation);
        
    }

}
