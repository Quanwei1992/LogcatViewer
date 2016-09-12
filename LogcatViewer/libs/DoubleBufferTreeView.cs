using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


public class DoubleBufferTreeView : TreeView
{
    public DoubleBufferTreeView()
    {
        SetStyle(ControlStyles.DoubleBuffer |

          ControlStyles.OptimizedDoubleBuffer |
          // ControlStyles.UserPaint |

          ControlStyles.AllPaintingInWmPaint, true);

        UpdateStyles();
    }
}
