var player : Transform;
var anim : Animator;
var speed = 0;

function Start()
{
//	transform.renderer.material.color = Color.red;
	anim = GetComponent(Animator);
	startpoint = transform.position;
}

function Update()
{
	transform.LookAt(player);
	var Distance = Vector3.Distance(transform.position,player.position);
	if(Distance <= 10)
	{
		anim.SetFloat("Speed_f", speed);
		transform.Translate(Vector3(0,0,0.3));
	}
	else
	{
		
	}
}