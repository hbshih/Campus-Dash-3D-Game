#pragma strict

var player: Transform;
static var speed : int = 5;
var anim : Animator;

function Start () {
	
}

function Update () {

	var dist : float = Vector3.Distance(player.position,transform.position);

	if(dist<=15 && dist > 3)
	{
		anim.SetBool ("Waving_b", false);
		//transform.Translate (Vector3(0,0,1) * Time.deltaTime*speed);
    	//anim.SetFloat("Speed_f", 10.0);
	}
	
}
