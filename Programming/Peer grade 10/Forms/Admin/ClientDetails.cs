﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clients
{
    public partial class ClientDetails : Form
    {
        /// <summary>
        /// Поля класса
        /// </summary>
        public Client client;
        public int paidSum = 0;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="client"></param>
        public ClientDetails(Client client)
        {
            InitializeComponent();
            this.client = client;
            MainTextBox.Text = client.fullName;

            LoginBox.Text = client.login;
            PasswordBox.Text = client.password;
            NameBox.Text = client.fullName;
            AddressBox.Text = client.address;
            TelephoneBox.Text = client.phoneNumber;

            UpdateData();
        }

        /// <summary>
        /// Обновление DataGrid
        /// </summary>
        private void UpdateData()
        {
            Orders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 25, 26);
            Orders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Orders.DefaultCellStyle.BackColor = Color.FromArgb(25, 25, 26);
            Orders.DefaultCellStyle.ForeColor = Color.White;
            Orders.DefaultCellStyle.SelectionBackColor = Color.FromArgb(50, 50, 50);
            Orders.EnableHeadersVisualStyles = false;
            Orders.RowHeadersVisible = false;

            Orders.Columns.Add("ID", "ID");
            Orders.Columns.Add("Товары", "Товары");
            Orders.Columns.Add("Время", "Время");
            Orders.Columns.Add("Статус", "Статус");
            Orders.Columns.Add("Покупатель", "Покупатель");
            foreach (Order order in Welcome.shop.orders)
            {
                if (order.client == client)
                {
                    Orders.Rows.Add(order.GetValues());
                    if (order.status.HasFlag(Status.Paid))
                        paidSum += order.GetTotalSum();
                }
            }
            PaidBox.Text = paidSum.ToString();
        }

        /// <summary>
        /// Кнопка назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
