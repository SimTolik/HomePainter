using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HomePainter
{
    public partial class DoubleBufferedPanel : Panel  //Создан для активации DoubleBuffered. Стандартный не позволял активировать данное св-во.
    {
        public DoubleBufferedPanel() 
        {
            this.DoubleBuffered = true;
        }
    }
}
