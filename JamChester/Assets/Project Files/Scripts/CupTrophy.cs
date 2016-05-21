using UnityEngine;
using System.Collections;

public class CupTrophy : GenericTrophy {


    public GameObject liquid_balls;

    public float dot_product_check = 0;
    public float liquid_spawn = 0.1f;
    private float next_spawn = 0;
    private float spawn_count = 0;
    public float ball_life = 0.25f;
    public bool drank = false;

    public override void ChildStartFunctions()
    {
        base.ChildStartFunctions();
        liquid_balls = this.transform.Find("Ball").gameObject;
    }

    public override void ChildUpdateFunctions()
    {
        base.ChildUpdateFunctions();

        if (Vector3.Dot(transform.up, Vector3.down) > 0)
        {
            MakeLiquid();
        }      
    }
    private void MakeLiquid()
    {
        if (spawn_count >  next_spawn)
        {
            next_spawn = liquid_spawn + spawn_count;
            GameObject ball_clone = Instantiate(liquid_balls, liquid_balls.transform.position, Quaternion.identity) as GameObject;
            ball_clone.SetActive(true);

            CupLiquidBits script = ball_clone.GetComponent<CupLiquidBits>();
            script.SetParent(this.gameObject);
            Destroy(ball_clone, ball_life);
        }
        spawn_count += Time.deltaTime;
    }


}
