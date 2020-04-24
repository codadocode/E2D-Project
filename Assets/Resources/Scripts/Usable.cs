using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.Scripts
{
    public class Usable : MonoBehaviour
    {
        [SerializeField]
        private UsableGeneric usable;
        public void use()
        {
            this.usable.use();
        }
    }
}
