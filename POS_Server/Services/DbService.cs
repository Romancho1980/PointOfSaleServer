using POS_Server.Context;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Server.Services
{
    public class DbService
    {
        /// _dbContext - экземпляр класса управления БД (EntityFrameWork)
        private ApplicationDbContext _dbContext;

        // В конструктор передаю ссылку на экземпляр БД
        public DbService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Получить всех клиентов из Базы Данных. Данные получаются в виде IEnumerable, т.е. простая коллекция(перечисление)
        /// </summary>
        public IEnumerable<ClientAccount> GetAllClients()
        {
            return _dbContext.clients.Select(x => x).ToList(); // LINQ - выражение
        }

        /// <summary>
        /// Получение из БД только имена и фамилии клиентов. Чтобы добавить их в ListBox
        /// </summary>
        /// <returns>
        /// Возвращается перечисление IEnumerable
        /// </returns>
        public IEnumerable<ClientAccount> GetOnlyNameAndSurnameClients()
        {
            yield return (ClientAccount)_dbContext.clients.Select(c => new
            {
                Name = $"{c.Name} + {c.Surname}"
            });
        }

        /// <summary>
        /// Получить информацию (кортеж) только одного клиента, Id которого совпадает с входным параметром
        /// </summary>
        public ClientAccount GetClientById(int Id)
        {
            return new ClientAccount { Id = Id };
        }


        /// <summary>
        /// Добавляет нового клиента в БД
        /// Входной параметр - экземпляр класса , в котором хранятся данные о клиенте, которые ввели с формы.
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(ClientAccount client)
        {

            // Вызываю метод Add - добавить, для добавления строки (пареметр client) в БД. 
            _dbContext.clients.Add(client);
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return;
            }

            // Сохранить изменения в БД
        }

        /// <summary>
        /// Удалить Клиента из БД
        /// </summary>
        /// <param name="client"></param>
        public void DeleteClient(ClientAccount client)
        {
            var tmp_client = _dbContext.clients.Find(client.Id);

            //Удаляем из БД
            if (tmp_client != null)
                _dbContext.clients.Remove(tmp_client);

            // Созраняем изменения в БД
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Внесение изменений в домены кортежа (т.е. внести изменения в поля клиента)
        /// </summary>
        /// <param name="client"> </param>
        public void UpdateClient(ClientAccount client)
        {
            // Получаем 
            var found_client = _dbContext.clients.Find(client.Id);

            // Если нет клиента с таким Id
            // Выводим ошибку в консоль

            // В тестовом варианте изменяются только имя и номер счёта клиента,
            // а остальные данные остаются без изменений
            found_client.Name = client.Name;
            found_client.Surname = client.Surname;
            found_client.INN = client.INN;
            found_client.City = client.City;
            found_client.Passport = client.Passport;
            found_client.Birthday = client.Birthday;
            found_client.Account = client.Account;
            found_client.Balance = client.Balance;
            found_client.Description = client.Description;


            // Созраняем изменения в БД
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// Получение остатка на счёте клиента
        /// </summary>
        /// <param name="account">Входной параметр аккаунт клиента</param>
        /// <returns></returns>
        public int GetBalanceByAccount(string account)
        {
            return 0;
        }

        /// <summary>
        /// Выполнение "главной" комманды.
        ///   Проверка корректного пин-кода.
        ///   Получение остатка на счёте клиента.
        ///   Проведение операции со счётом клиента,т.е. уменьшение баланса на стоимость товара.
        ///   Проведение операции со счётом "владельца терминала", т.е. увеличение остатка на счёте на стоимость товара, 
        ///   Взятие комиссии "интерес" банка в количестве 5% от стоимости товара. Т.е Владелец Терминала получит на 5% меньше. :)
        /// </summary>
        /// <param name="client_card_account"> Номер счёта клиента</param>
        /// <param name="value"> Сумма, на которую совершается транзакция</param>
        /// <param name="PinCode"> Пин - код </param>
        /// <returns></returns>
        public bool MakePurchase(string client_card_account, int value, string PinCode)
        {
            return true;
        }
    }
}
