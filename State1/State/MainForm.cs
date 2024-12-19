using System;
using System.Windows.Forms;
using StatePatternPhoneApp;

namespace State
{
    public partial class MainForm : Form, IObserver
    {
        private readonly PhoneController controller;

        public MainForm()
        {
            InitializeComponent();

            var phone = new Phone("123-456-789", 50.0, 0.5); 
            phone.AddObserver(this); 
            controller = new PhoneController(phone); 

            UpdateView();
        }

        public void Update()
        {
            UpdateView();
        }

        private void UpdateView()
        {
            lblState.Text = $"Состояние: {controller.GetStateName()}";
            lblBalance.Text = $"Баланс: {controller.GetBalance()} единиц";
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            try
            {
                controller.Call();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                controller.AnswerCall();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                controller.EndCall();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecharge_Click(object sender, EventArgs e)
        {
            try
            {
                controller.Recharge(txtRechargeAmount.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
