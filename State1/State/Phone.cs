using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StatePatternPhoneApp
{
    public interface IObserver
    {
        void Update(IState state, double balance);
    }

    public abstract class Observable
    {
        private readonly List<IObserver> observers = new();

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        protected void NotifyObservers(IState state, double balance)
        {
            foreach (var observer in observers)
            {
                observer.Update(state, balance);
            }
        }
    }

    public class Phone : Observable
    {
        private IState currentState;

        private double balance;
        public double Balance
        {
            get => balance;
            set
            {
                balance = value;
                NotifyObservers(currentState, balance); 
            }
        }

        public double Probability { get; private set; }
        public string Number { get; private set; }

        public Phone(string number, double balance, double probability)
        {
            Number = number;
            Balance = balance;
            Probability = probability;
            currentState = balance >= 0 ? new WaitingState() : new BlockedState();
        }

        public string GetStateName()
        {
            return currentState.GetType().Name.Replace("State", "");
        }

        public void SetState(IState state)
        {
            currentState = state;
            NotifyObservers(currentState, balance);
        }

        public void Call()
        {
            currentState.Call(this);
        }

        public void AnswerCall()
        {
            currentState.AnswerCall(this);
        }

        public void EndCall()
        {
            currentState.EndCall(this);
        }

        public void Recharge(double amount)
        {
            currentState.Recharge(this, amount);
        }
    }

    public interface IState
    {
        void Call(Phone phone);
        void AnswerCall(Phone phone);
        void EndCall(Phone phone);
        void Recharge(Phone phone, double amount);
    }

    public class WaitingState : IState
    {
        public void Call(Phone phone)
        {
            if (phone.Balance < 0)
            {
                phone.SetState(new BlockedState());
                Console.WriteLine("Баланс отрицательный, телефон заблокирован.");
            }
            else
            {
                Random rand = new Random();
                if (rand.NextDouble() < phone.Probability)
                {
                    phone.SetState(new CallState());
                    Console.WriteLine("Звонок поступил.");
                }
                else
                {
                    Console.WriteLine("Звонок не поступил.");
                }
            }
        }

        public void AnswerCall(Phone phone) => Console.WriteLine("Нет входящего звонка.");
        public void EndCall(Phone phone) => Console.WriteLine("Невозможно завершить звонок, так как нет разговора.");
        public void Recharge(Phone phone, double amount)
        {
            phone.Balance += amount;
            Console.WriteLine($"Баланс пополнен на {amount} единиц.");
        }
    }

    public class CallState : IState
    {
        public void Call(Phone phone) => Console.WriteLine("Уже идёт звонок.");
        public void AnswerCall(Phone phone)
        {
            var conversationState = new ConversationState();
            phone.SetState(conversationState);
            Console.WriteLine("Разговор начался.");
            conversationState.StartBilling(phone);
        }
        public void EndCall(Phone phone) => Console.WriteLine("Звонок не может быть завершён, так как разговор не начался.");
        public void Recharge(Phone phone, double amount)
        {
            phone.Balance += amount;
            Console.WriteLine($"Баланс пополнен на {amount} единиц.");
        }
    }

    public class ConversationState : IState
    {
        private bool isTalking = false;
        public void Call(Phone phone) => Console.WriteLine("Невозможно совершить звонок во время разговора.");
        public void AnswerCall(Phone phone) => Console.WriteLine("Разговор уже идёт.");
        public void EndCall(Phone phone)
        {
            phone.SetState(new WaitingState());
            Console.WriteLine("Разговор завершён.");
        }
        public void Recharge(Phone phone, double amount)
        {
            phone.Balance += amount;
            Console.WriteLine($"Баланс пополнен на {amount} единиц.");
        }

        public async void StartBilling(Phone phone)
        {
            if (isTalking) return;
            isTalking = true;

            while (isTalking)
            {
                await Task.Delay(5000);

                if (!isTalking) break;

                phone.Balance -= 25; 
                Console.WriteLine($"Списано 25 единиц.");

                if (phone.Balance < 0)
                {
                    isTalking = false; 
                    phone.SetState(new BlockedState());
                    Console.WriteLine("Баланс отрицательный, телефон заблокирован.");
                    break;
                }
            }
        }
    }

    public class BlockedState : IState
    {
        public void Call(Phone phone) => Console.WriteLine("Телефон заблокирован, невозможно совершить звонок.");
        public void AnswerCall(Phone phone) => Console.WriteLine("Телефон заблокирован, невозможно ответить на звонок.");
        public void EndCall(Phone phone) => Console.WriteLine("Нет активного разговора.");
        public void Recharge(Phone phone, double amount)
        {
            phone.Balance += amount;
            if (phone.Balance >= 0)
            {
                phone.SetState(new WaitingState());
                Console.WriteLine("Баланс пополнен, телефон разблокирован.");
            }
            else
            {
                Console.WriteLine("Баланс остаётся отрицательным.");
            }
        }
    }
}
