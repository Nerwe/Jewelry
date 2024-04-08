using System.Collections.Generic;

namespace Jewelry.Model
{
    public interface IComboBoxRepository
    {
        IEnumerable<string> GetAllTableNames();
        IEnumerable<string> GetAllFieldsOfTable(string tableName);
        IEnumerable<string> GetAllValuesOfField(string tableName, string fieldName);
        IEnumerable<string> GetDataByFieldValue(string tableName, string fieldName, string fieldValue);
    }
}
