using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HomePainter
{
    public partial class DoubleBufferedPanel : Panel  //It is created for activation of DoubleBuffered property. Visual Studio didn't allow to activate this by interface "Properties".
    {
        public DoubleBufferedPanel() 
        {
            this.DoubleBuffered = true;
        }
    }
}
