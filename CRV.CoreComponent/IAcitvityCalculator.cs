using System;
using System.Collections.Generic;
using System.Text;
using TrackerActivity.Domain.Activity;

namespace TrackerActivity.Application.Core
{
    public interface IAcitvityCalculator
    {
        void Execute(Session session);
        
    }
}
