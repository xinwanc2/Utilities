using Dapper;
using PhoneBookWeb.Models;
using System.Data;

namespace PhoneBookWeb.Services
{
    public interface IContactService
    {
        Task<bool> CreateContact(BaseContact contact);

        Task<int> UpdateContact(UpdateContact contact);

        Task<Contacts> GetContactById(int id);

        Task<bool> DeleteContact(DeleteContact contact);

        Task<IEnumerable<Contacts>> GetContacts(ContactFilter filter);
    }

    public class ContactService : IContactService
    {
        private readonly IDbConnection _dbConnection;

        public ContactService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> CreateContact(BaseContact contact)
        {
            DynamicParameters parm = new();

            parm.Add("Name", contact.Name);
            parm.Add("PhoneNo", contact.PhoneNo);
            parm.Add("Address", contact.Address);

            return await _dbConnection.ExecuteScalarAsync<bool>("proc_CreateContact", parm, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateContact(UpdateContact contact)
        {
            DynamicParameters parm = new();

            parm.Add("Id", contact.Id);
            parm.Add("Name", contact.Name);
            parm.Add("PhoneNo", contact.PhoneNo);
            parm.Add("Address", contact.Address);

            return await _dbConnection.ExecuteScalarAsync<int>("proc_UpdateContact", parm, commandType: CommandType.StoredProcedure);
        }

        public async Task<Contacts> GetContactById(int id)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<Contacts>("proc_GetContactById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> DeleteContact(DeleteContact contact)
        {
            return await _dbConnection.ExecuteScalarAsync<bool>("proc_DeleteContact", new
            {
                contact.Id
            },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Contacts>> GetContacts(ContactFilter filter)

        {
            DynamicParameters parm = new();

            parm.Add("Name", filter.Name ?? "");
            parm.Add("PhoneNo", filter.PhoneNo ?? "");
            parm.Add("Address", filter.Address ?? "");

            return await _dbConnection.QueryAsync<Contacts>("proc_GetContacts", parm, commandType: CommandType.StoredProcedure);
        }
    }
}
