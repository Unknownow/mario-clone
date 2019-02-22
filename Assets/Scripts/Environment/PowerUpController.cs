using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : EnemyMovement
{
    public bool isMushroom; //Kiem tra xem day la nam hay sao

    new void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Border"))
        {
            Destroy(gameObject);
            return;
        }
        if (collision.transform.CompareTag("Player"))
        {
            if (isMushroom)
            {
                collision.gameObject.GetComponent<PlayerMovement>().changeToBigger();
                collision.gameObject.GetComponent<PlayerStatus>().isBigger = true;
            }
            else
            {
                collision.gameObject.GetComponent<PlayerMovement>().makeFabulous();
                collision.gameObject.GetComponent<PlayerStatus>().isFabulous = true;
            }
            //Lam tro con bo gi day voi player
            //Neu la nam thi tang trong
            //Neu la sao thi tro nen fabulous
            Destroy(this.gameObject);
        }
        
    }
}
