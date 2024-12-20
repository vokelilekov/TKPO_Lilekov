using System;
using System.Windows.Forms;
using StatePatternPhoneApp;

namespace State
{
    public partial class MainForm : Form, IObserver
    {

        private PhoneController controller;
        private readonly Action updateUI;
        public MainForm()
        {
            InitializeComponent();
            
            var phone = new Phone("123-456-789", 50.0, 0.5);
            controller = new PhoneController(phone, UpdateStateLabel); 
            UpdateStateLabel();
            phone.AddObserver(this);
        }

        private void UpdateStateLabel()
        {
            lblState.Text = $"Текущее состояние: {controller.GetStateName()}";
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

        public void Update(IState state, double balance)
        {
            lblState.Text = $"Текущее состояние: {state.GetType().Name.Replace("State", "")}";
            lblBalance.Text = $"Баланс: {balance} единиц";
            updateUI?.Invoke();

        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
