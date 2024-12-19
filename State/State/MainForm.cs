using StatePatternPhoneApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace State
{
    public partial class MainForm : Form
    {
        private Phone phone;
        public MainForm()
        {
            InitializeComponent();
            phone = new Phone("123-456-789", 50.0, 0.5);
            UpdateStateLabel();
        }

        private void UpdateStateLabel()
        {
            lblState.Text = $"Текущее состояние: {phone.GetStateName()}"; 
            lblBalance.Text = $"Баланс: {phone.Balance} единиц";  
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            phone.Call();
            UpdateStateLabel();
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            phone.AnswerCall();
            UpdateStateLabel();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            phone.EndCall();
            UpdateStateLabel();
        }

        private void btnRecharge_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtRechargeAmount.Text, out double amount))
            {
                phone.Recharge(amount);
                UpdateStateLabel();
            }
            else
            {
                MessageBox.Show("Введите корректную сумму для пополнения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
