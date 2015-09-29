namespace FractalGen.Core.Services.Fractal
{
    public interface IHSVConverter
    {
        /// <summary>
        /// Convert HSV to RGB
        /// h is from 0-360
        /// s,v values are 0-1
        /// r,g,b values are 0-255
        /// Based upon http://ilab.usc.edu/wiki/index.php/HSV_And_H2SV_Color_Space#HSV_Transformation_C_.2F_C.2B.2B_Code_2
        /// </summary>
        void HsvToRgb(double h, double S, double V, out int r, out int g, out int b);
    }
}