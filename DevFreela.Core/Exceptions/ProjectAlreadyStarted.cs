﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Exceptions
{
    internal class ProjectAlreadyStarted : Exception
    {
        public ProjectAlreadyStarted() : base ("Project is already in started status.")
        {
            
        }
    }
}
