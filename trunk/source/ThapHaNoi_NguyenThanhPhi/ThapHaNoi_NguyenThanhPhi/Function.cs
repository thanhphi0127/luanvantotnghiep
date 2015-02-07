using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Xna.Framework.Media;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using Microsoft.Xna.Framework;
using System.Windows.Resources;
using System.IO;
using System.Linq;
using Microsoft.Phone.Tasks;
using Microsoft.Phone;
using System.Windows.Threading;

namespace ThapHaNoi_NguyenThanhPhi
{
    class Function
    {
        /// <summary>
        /// HAM XOA 1 DIA RA KHOI CANVAS
        /// </summary>
        /// <param name="ContentPanel"></param>
        /// <param name="item"></param>
        /// <param name="targetPanel"></param>
        public void Remove(Canvas _canvas, string numTag)
        {
            var child = (from c in _canvas.Children.OfType<FrameworkElement>()
                         where numTag.Equals(c.Tag)
                         select c).First();

            if (child != null)
            {
                _canvas.Children.Remove(child);
            }
        }
    }
}
