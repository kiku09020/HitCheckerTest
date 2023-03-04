using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHitChecker : PlayerHitCheckerBase
{

	//--------------------------------------------------

	protected override void HitEnterAction(Collision2D collision)
	{
		player.Rend.color = Color.white;
	}

	protected override void HitExitAction(Collision2D collision)
	{
		player.Rend.color = Color.gray;
	}
}
