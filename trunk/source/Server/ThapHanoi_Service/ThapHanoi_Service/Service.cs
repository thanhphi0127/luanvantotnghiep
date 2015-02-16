using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThapHanoi_Service
{
    public class Thachdau: IService
    {
        /// <summary>
        /// Kiểm tra sự tồn tại của một tài khoản
        /// </summary>
        /// <param name="tk">tên tài khoản</param>
        /// <param name="mk">mật khẩu</param>
        /// <returns>bool: đúng nếu tài khoản chưa tồn tại trong CSDL và ngược lại</returns>
        public bool KiemTraTaiKhoan(string tk, string mk)
        {
            int count = 0;
            using (TowerHanoiEntities database = new TowerHanoiEntities())
            {
                count = (from x in database.NGUOICHOIs
                         where String.Compare(tk, x.TAIKHOAN.Trim()) == 0 &&
                         String.Compare(mk, x.MATKHAU.Trim()) == 0
                         select x.TAIKHOAN).Count();
            }
            return (count == 1) ? true : false;
        }
    }
}
