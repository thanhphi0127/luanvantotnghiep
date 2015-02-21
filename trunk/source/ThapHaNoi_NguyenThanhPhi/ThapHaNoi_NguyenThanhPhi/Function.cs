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
using ThapHaNoi_NguyenThanhPhi.Source.Choidon;

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

        /// <summary>
        /// TAO CO SO DU LIEU MOI
        /// </summary>
        public void CreateLocalDatabase()
        {
            using (ThanhTichChoiDonDataContext dataContext = new ThanhTichChoiDonDataContext(Contants.connection))
            {
                if (!dataContext.DatabaseExists())
                {
                    dataContext.CreateDatabase();
                    dataContext.SubmitChanges();

                    CreateTable();
                }
            }

        }

        /// <summary>
        /// KHOI TAO BANG THANH TICH CA NHAN
        /// </summary>
        public void CreateTable()
        {
            using (ThanhTichChoiDonDataContext dataContext = new ThanhTichChoiDonDataContext(Contants.connection))
            {
                IQueryable<ThanhTichChoiDon> queryChoidon3 = from c in dataContext.ttcd where c.SODIA == 1 where c.SOCOC == 3 select c;
                ThanhTichChoiDon ttcdAdd3 = queryChoidon3.FirstOrDefault();
                if (ttcdAdd3 == null)
                {
                    for (int i = 3; i <= 10; i++)
                    {
                        ThanhTichChoiDon ttcd = new ThanhTichChoiDon();
                        ttcd.STT = i - 2;
                        ttcd.SODIA = i;
                        ttcd.SOCOC = 3;
                        ttcd.SOBUOC = 0;
                        ttcd.TENNGUOICHOI = "";
                        ttcd.THOIGIAN = "--:--:--";
                        ttcd.NGAYLAP = "--/--/----";
                        dataContext.ttcd.InsertOnSubmit(ttcd);
                        dataContext.SubmitChanges();
                    }
                }

                IQueryable<ThanhTichChoiDon> queryChoidon4 = from c in dataContext.ttcd where c.SODIA == 1 where c.SOCOC == 4 select c;
                ThanhTichChoiDon ttcdAdd4 = queryChoidon4.FirstOrDefault();
                if (ttcdAdd4 == null)
                {
                    for (int i = 3; i <= 10; i++)
                    {
                        ThanhTichChoiDon ttcd = new ThanhTichChoiDon();
                        ttcd.STT = 10 + i - 2;
                        ttcd.SODIA = i;
                        ttcd.SOCOC = 4;
                        ttcd.SOBUOC = 0;
                        ttcd.TENNGUOICHOI = "";
                        ttcd.THOIGIAN = "--:--:--";
                        ttcd.NGAYLAP = "--/--/----";
                        dataContext.ttcd.InsertOnSubmit(ttcd);
                        dataContext.SubmitChanges();
                    }
                }
            }
        }
        /// <summary>
        /// CAP NHAT BANG THANH TICH CA NHAN
        /// </summary>
        public void UpdateTable(TextBox tennguoichoi, TextBlock thoigian, TextBlock solan, int sodia, int sococ)
        {
            using (ThanhTichChoiDonDataContext dataContext = new ThanhTichChoiDonDataContext(Contants.connection))
            {
                IQueryable<ThanhTichChoiDon> query = from c in dataContext.ttcd where c.SODIA == sodia where c.SOCOC == sococ select c;
                ThanhTichChoiDon updateThanhTich = query.FirstOrDefault();
                int sobuoc = Convert.ToInt32(solan.Text);

                if (updateThanhTich.SOBUOC == 0 || String.Compare(updateThanhTich.THOIGIAN, thoigian.Text) > 0)
                {
                    updateThanhTich.SOBUOC = sobuoc;
                    updateThanhTich.THOIGIAN = thoigian.Text;
                    updateThanhTich.TENNGUOICHOI = tennguoichoi.Text;
                    updateThanhTich.NGAYLAP = setDate(DateTime.Now.Day.ToString()) + "/" + setDate(DateTime.Now.Month.ToString()) +  "/" + DateTime.Now.Year.ToString();
                }
                else if (String.Compare(updateThanhTich.THOIGIAN, thoigian.Text) == 0)
                {
                    if (updateThanhTich.SOBUOC > sobuoc)
                    {
                        //if so buoc thuc te < so buoc trong CSDL
                        updateThanhTich.SOBUOC = sobuoc;
                        updateThanhTich.TENNGUOICHOI = tennguoichoi.Text;
                        updateThanhTich.NGAYLAP = setDate(DateTime.Now.Day.ToString()) + "/" + setDate(DateTime.Now.Month.ToString()) + "/" + DateTime.Now.Year.ToString();
                    }
                }

                dataContext.SubmitChanges();
            }
        }

        string setDate(string stringDate)
        {
            if (Convert.ToInt32(stringDate.ToString()) < 10)
            {
                return ("0" + stringDate.ToString());
            }
            return stringDate;
        }
    }
}
