using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rapphim1
{
    public partial class Form1 : Form
    {
        private Dictionary<Button, int> seatPrices = new Dictionary<Button, int>();
        private int totalAmount = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeSeats();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void InitializeSeats()
        {
            // Gán giá cho từng hàng ghế
            AssignSeatPrice(A, 25000);
            AssignSeatPrice(B, 25000);
            AssignSeatPrice(C, 23000);
            AssignSeatPrice(D, 25000);
            AssignSeatPrice(E, 13000);
            AssignSeatPrice(F, 25000);
            AssignSeatPrice(G, 25000);
            AssignSeatPrice(H, 25000);
            AssignSeatPrice(I, 25000);
            AssignSeatPrice(J, 30000);
            AssignSeatPrice(K, 25000);
            AssignSeatPrice(L, 25000);
            
            // Gán sự kiện Click cho tất cả các ghế
            foreach (var seat in seatPrices.Keys)
            {
                seat.Click += Seat_Click;
            }
        }

        private void AssignSeatPrice(Button seat, int price)
        {
            seatPrices[seat] = price;
            seat.MouseHover += (s, e) =>
            {
                ToolTip tooltip = new ToolTip();
                tooltip.Show($"Giá vé của hàng ghế này là: {price}đ", seat, 1000);
            };
        }

        private void Seat_Click(object sender, EventArgs e)
        {
            Button seat = sender as Button;

            if (seat.BackColor == Color.Green)
            {
                // Hủy chọn ghế
                seat.BackColor = SystemColors.Control;
                totalAmount -= seatPrices[seat];
            }
            else
            {
                // Chọn ghế
                seat.BackColor = Color.Green;
                totalAmount += seatPrices[seat];
            }

            UpdateTotalAmount();
        }

        private void UpdateTotalAmount()
        {
            lblTotalAmount.Text = $"Thành tiền: {totalAmount}đ";
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn mua những ghế đã chọn không?", "Xác nhận thanh toán", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("Thanh toán thành công!", "Thông báo");
                // Reset ghế và tổng tiền
                foreach (var seat in seatPrices.Keys)
                {
                    if (seat.BackColor == Color.Green)
                    {
                        seat.BackColor = Color.Red;
                    }
                }
                totalAmount = 0;
                UpdateTotalAmount();
            }
        }
    }
}
