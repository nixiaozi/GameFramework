using GameFramework.Procedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameFrameworkExample
{
    public class ProcedureExample: ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            
        }
    }
}
