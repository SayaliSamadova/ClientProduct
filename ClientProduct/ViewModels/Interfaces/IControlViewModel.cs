using ClientProduct.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProduct.ViewModels.Interfaces
{
    public interface IControlViewModel
    {
        string Header { get; }
        Situation CurrentSituation { get; }
    }
}
