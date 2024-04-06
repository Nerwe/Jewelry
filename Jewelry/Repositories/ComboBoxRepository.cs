using Jewelry.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Jewelry.Repositories
{
    public class ComboBoxRepository : RepositoryBase, IComboBoxRepository
    {
        public IEnumerable<string> GetAllTableNames()
        {
            List<string> tableNames = new List<string>();

            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand("GetAllTableNames", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object value = reader.GetValue(0);
                            string stringValue = value.ToString();
                            tableNames.Add(stringValue);
                        }
                    }
                }
            }

            return tableNames;
        }

        public IEnumerable<string> GetAllFieldsOfTable(string tableName)
        {
            List<string> fieldNames = new List<string>();

            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand("GetAllFieldsOfTable", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TableName", tableName);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object value = reader.GetValue(0);
                            string stringValue = value.ToString();
                            fieldNames.Add(stringValue);
                        }
                    }
                }
            }

            return fieldNames;
        }

        public IEnumerable<string> GetAllValuesOfField(string tableName, string fieldName)
        {
            List<string> fieldValues = new List<string>();

            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand("GetAllValuesOfField", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TableName", tableName);
                    command.Parameters.AddWithValue("@FieldName", fieldName);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object value = reader.GetValue(0);
                            string stringValue = value.ToString();
                            fieldValues.Add(stringValue);
                        }
                    }
                }
            }

            return fieldValues;
        }
    }
}
