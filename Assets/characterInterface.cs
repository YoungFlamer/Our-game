using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface characterInterface
{
    // Start is called before the first frame update
    void TakeDamage(DamageData dd);
    DamageData DealDamage();
}
