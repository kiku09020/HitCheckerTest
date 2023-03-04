using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
	public class StageHitChecker : PlayerHitCheckerBase {

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
}