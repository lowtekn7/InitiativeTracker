using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InitiativeTracker.Domain.Abstract;
using InitiativeTracker.Domain.Entities;

namespace InitiativeTracker.Domain.Concrete
{
    public class CharacterDAL : ICharacterRepository
    {
        private SqlConnection sqlCn = null;

        public void OpenConnection()
        {
            sqlCn = new SqlConnection();
            sqlCn.ConnectionString = ConfigurationManager.ConnectionStrings["EFDbContext"].ConnectionString;
            sqlCn.Open();
        }

        public void CloseConnection() { sqlCn.Close(); }

        public IEnumerable<Character> Characters
        {
            get
            {
                OpenConnection();
                List<Character> list = new List<Character>();
                string sql = string.Format("Select * from Characters");
                using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        list.Add(new Character
                        {
                            CharacterID = (int)dr["CharacterID"],
                            Name = (string)dr["Name"],
                            Initiative = (int)dr["Initiative"],
                            Group = (string)dr["Group"]
                        });
                    }
                    dr.Close();
                }
                return list;
            }
            

            
        }

        public Character Get(int id)
        {
            OpenConnection();
            Character character = new Character();
            string sql = string.Format("Select * from Characters where CharacterID='{0}'",
                id);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    character.CharacterID = (int)dr["CharacterID"];
                    character.Name = (string)dr["Name"];
                    character.Initiative = (int)dr["Initiative"];
                    character.Group = (string)dr["Group"];
                }
                dr.Close();
            }
            return character;
        }

        public void Remove(int id)
        {
            OpenConnection();
            string sql = string.Format("Delete from Characters where CharacterID = '{0}'",
                id);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public Character Save(Character item)
        {
            OpenConnection();
            Character storedCharacter = Get(item.CharacterID);
            string sql;
            if (storedCharacter.CharacterID != 0)
            {
                sql = string.Format("UPDATE Characters SET Name='{0}', Initiative='{1}', [Group]='{2}' WHERE CharacterID='{3}'",
                    item.Name, item.Initiative, item.Group, item.CharacterID);
            } else
            {
                sql = string.Format("INSERT INTO Characters (Name,Initiative,[Group]) Values ('{0}','{1}','{2}')",
                item.Name, item.Initiative, item.Group);
            }
            
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn)) { cmd.ExecuteNonQuery(); }
            return item;

        }

        public Character Update(Character item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
