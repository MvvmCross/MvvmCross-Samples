using Cirrious.CrossCore.UI;
using System.Collections.Generic;

namespace FractalGen.Core.Services.Fractal
{
    public interface IColorArrayGenerator
    {
        List<MvxColor> NextColorArray();
    }
}