using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class FrmCDTKHTT : Form
    {
        string[] customerIds, customerNames;
        int[] customerPoints;
        Card[] customerCards;

        enum Card
        {
            KHTT, TVCOOP, VIP
        }
        public FrmCDTKHTT()
        {
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            customerIds = new string[0];
            customerNames = new string[0];
            customerPoints = new int[0];
            customerCards = new Card[0];
        }
        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            //input
            string id = txtCustomerId.Text;
            string customerName = txtCustomerName.Text;
            int cost = Convert.ToInt32(txtCost.Text);

            //process

            //-find customer
            int index = Array.IndexOf(customerIds, id);

            //-calculate point
            index = CalculatePoint(id, Name, cost, index);

            //-check customer card type change
            CheckCustomerCardTypeChange(index);

            //output
            txtCustomerList.Text = OutPut();
        }
        private int CalculatePoint(string id, string name, int cost, int index)
        {
            if (index == -1) //not found
            {
                //add new customer
                Array.Resize(ref customerIds, customerIds.Length + 1);
                customerIds[customerIds.Length - 1] = id;

                Array.Resize(ref customerNames, customerNames.Length + 1);
                customerNames[customerNames.Length - 1] = name;

                Array.Resize(ref customerPoints, customerPoints.Length + 1);
                customerPoints[customerPoints.Length - 1] = cost;

                Array.Resize(ref customerCards, customerCards.Length + 1);
                customerCards[customerCards.Length - 1] = Card.KHTT;

                //update index
                index = customerIds.Length - 1;
            }
            else          // found
            {
                //add point for existing customer
                customerPoints[index] += cost / 10000;
            }
            return index;
        }
        private void CheckCustomerCardTypeChange(int index)
        {
            //Khách Hàng Thân Thiết + 600 ĐMH = Thành Viên Co.opMart
            if (customerCards[index] == Card.KHTT && customerPoints[index] >= 600)
                customerCards[index] = Card.TVCOOP;
            //Thành Viên Co.opMart + 1600 ĐMH = Thành Viên Vip
            if (customerCards[index] == Card.TVCOOP && customerPoints[index] >= 2200)
                customerCards[index] = Card.VIP;
        }
        private string OutPut()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendFormat("{0}Mã Khách Hàng {1}Tên Khách Hàng{1}Điểm Tích Lũy{2}Loại Thẻ{3}",
                new string(' ', 4), new string(' ', 12), new string(' ', 20), Environment.NewLine);
            for (int i = 0; i < customerIds.Length; i++)
            {
                strBuilder.AppendFormat("{0}\t\t{1}\t\t{2}\t{3}{4}", customerIds[i], customerNames[i],
                    customerPoints[i], ToString(customerCards[i]), Environment.NewLine);
            }
            return strBuilder.ToString();
        }
        private string ToString(Card card)
        {
            if (card == Card.KHTT) return " Khách Hàng Thân Thiết";
            else if (card == Card.TVCOOP) return " Thành Viên Co.opMart";
            else if (card == Card.VIP) return " Thành Viên VIP ";
            else return " Loại thẻ không hợp lệ";
        }
    }
}