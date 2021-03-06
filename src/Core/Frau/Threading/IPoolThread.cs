﻿using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Frau.Threading
{
    public interface IPoolThread
    {

        
        void InitThreads();
        void ReportTask(IEnumerable<FrauThread> threads);
        object TaskIsFinished(object[] input);
    }
}
