using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Data.SqlClient;

namespace ThapHanoi_Service
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection conn;
        SqlCommand cmd, cmd1, cmd2;
        string strConnect = @"Data Source=THANHPHI\SQLEXPRESS;Initial Catalog=LVDatabase;Integrated Security=True";
        SqlDataAdapter da;
        DataTable table;

        private ServiceHost HostProxy;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnServer_Click(object sender, EventArgs e)
        {
            string address = "http://localhost:8080/Service";

            HostProxy = new ServiceHost(typeof(Thachdau), new Uri(address));


            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            HostProxy.Description.Behaviors.Add(smb);

            try
            {
                HostProxy.Open();
                labelThongTin.Text = "Server đang chạy tại địa chỉ:\n" + address.ToString();

            }
            catch (AddressAccessDeniedException)
            {
                labelThongTin.Text = "You need to reserve the address for this service";
                HostProxy = null;
            }
            catch (AddressAlreadyInUseException)
            {
                labelThongTin.Text = "Địa chỉ đã được một dịch vụ khác sử dụng";
                HostProxy = null;
            }
            catch (Exception ex)
            {
                labelThongTin.Text = "Có lỗi xảy ra: " + ex.Message.ToString();
                HostProxy = null;
            }
        }
    }
}
