using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Configuration;
using System.Configuration;

    /// <summary>
    /// Data helper class
    /// </summary>
public class DataHelper
{
    #region Methods

    internal static string GetConnectionString(string ConnectionStringName)
    {
        //string connectionString = null;

        //ConnectionStringSettings settings = WebConfigurationManager.ConnectionStrings[ConnectionStringName];
        //if (settings != null)
        //{
        //    connectionString = settings.ConnectionString;
        //}

        string ConnectionString = ConfigurationSettings.AppSettings[ConnectionStringName];
        return ConnectionString;
    }

    /// <summary>
    /// Creates a connection to a data soruce
    /// </summary>
    /// <param name="ConnectionString">Connection string</param>
    /// <returns>Database instance</returns>
    //public static Database CreateConnection(string ConnectionString)
    //{
    //    SqlDatabase db = new SqlDatabase(ConnectionString);
    //    return db;
    //}

    /// <summary>
    /// Gets a boolean value of a data reader by a column name
    /// </summary>
    /// <param name="rdr">Data reader</param>
    /// <param name="columnName">Column name</param>
    /// <returns>A boolean value</returns>
    public static bool GetBoolean(IDataReader rdr, string columnName)
    {
        int index = rdr.GetOrdinal(columnName);
        if (rdr.IsDBNull(index))
        {
            return false;
        }
        return Convert.ToBoolean(rdr[index]);
    }

    /// <summary>
    /// Gets a byte array of a data reader by a column name
    /// </summary>
    /// <param name="rdr">Data reader</param>
    /// <param name="columnName">Column name</param>
    /// <returns>A byte array</returns>
    public static byte[] GetBytes(IDataReader rdr, string columnName)
    {
        int index = rdr.GetOrdinal(columnName);
        if (rdr.IsDBNull(index))
        {
            return null;
        }
        return (byte[])rdr[index];
    }

    /// <summary>
    /// Gets a datetime value of a data reader by a column name
    /// </summary>
    /// <param name="rdr">Data reader</param>
    /// <param name="columnName">Column name</param>
    /// <returns>A date time</returns>
    public static DateTime GetDateTime(IDataReader rdr, string columnName)
    {
        int index = rdr.GetOrdinal(columnName);
        if (rdr.IsDBNull(index))
        {
            return DateTime.MinValue;
        }
        return (DateTime)rdr[index];
    }
    /// <summary>
    /// Gets an UTC datetime value of a data reader by a column name
    /// </summary>
    /// <param name="rdr">Data reader</param>
    /// <param name="columnName">Column name</param>
    /// <returns>A date time</returns>
    public static DateTime GetUtcDateTime(IDataReader rdr, string columnName)
    {
        int index = rdr.GetOrdinal(columnName);
        if (rdr.IsDBNull(index))
        {
            return DateTime.MinValue;
        }
        return DateTime.SpecifyKind((DateTime)rdr[index], DateTimeKind.Utc);
    }
    /// <summary>
    /// Gets a nullable datetime value of a data reader by a column name
    /// </summary>
    /// <param name="rdr">Data reader</param>
    /// <param name="columnName">Column name</param>
    /// <returns>A date time if exists; otherwise, null</returns>
    public static DateTime? GetNullableDateTime(IDataReader rdr, string columnName)
    {
        int index = rdr.GetOrdinal(columnName);
        if (rdr.IsDBNull(index))
        {
            return null;
        }
        return (DateTime)rdr[index];
    }

    /// <summary>
    /// Gets a nullable UTC datetime value of a data reader by a column name
    /// </summary>
    /// <param name="rdr">Data reader</param>
    /// <param name="columnName">Column name</param>
    /// <returns>A date time if exists; otherwise, null</returns>
    public static DateTime? GetNullableUtcDateTime(IDataReader rdr, string columnName)
    {
        int index = rdr.GetOrdinal(columnName);
        if (rdr.IsDBNull(index))
        {
            return null;
        }
        return DateTime.SpecifyKind((DateTime)rdr[index], DateTimeKind.Utc);
    }

    /// <summary>
    /// Gets a decimal value of a data reader by a column name
    /// </summary>
    /// <param name="rdr">Data reader</param>
    /// <param name="columnName">Column name</param>
    /// <returns>A decimal value</returns>
    public static decimal GetDecimal(IDataReader rdr, string columnName)
    {
        int index = rdr.GetOrdinal(columnName);
        if (rdr.IsDBNull(index))
        {
            return decimal.Zero;
        }
        return Convert.ToDecimal(rdr[index]);
    }

    public static decimal GetDecimalNullable(IDataReader rdr, string columnName)
    {
        int index = rdr.GetOrdinal(columnName);
        if (rdr.IsDBNull(index))
        {
            return -1;
        }
        return Convert.ToDecimal(rdr[index]);
    }

    /// <summary>
    /// Gets a double value of a data reader by a column name
    /// </summary>
    /// <param name="rdr">Data reader</param>
    /// <param name="columnName">Column name</param>
    /// <returns>A double value</returns>
    public static double GetDouble(IDataReader rdr, string columnName)
    {
        int index = rdr.GetOrdinal(columnName);
        if (rdr.IsDBNull(index))
        {
            return 0.0;
        }
        return (double)rdr[index];
    }

    /// <summary>
    /// Gets a GUID value of a data reader by a column name
    /// </summary>
    /// <param name="rdr">Data reader</param>
    /// <param name="columnName">Column name</param>
    /// <returns>A GUID value</returns>
    public static Guid GetGuid(IDataReader rdr, string columnName)
    {
        int index = rdr.GetOrdinal(columnName);
        if (rdr.IsDBNull(index))
        {
            return Guid.Empty;
        }
        return (Guid)rdr[index];
    }

    /// <summary>
    /// Gets an integer value of a data reader by a column name
    /// </summary>
    /// <param name="rdr">Data reader</param>
    /// <param name="columnName">Column name</param>
    /// <returns>An integer value</returns>
    public static int GetInt(IDataReader rdr, string columnName)
    {
        int index = rdr.GetOrdinal(columnName);
        if (rdr.IsDBNull(index))
        {
            return 0;
        }
        return (int)rdr[index];
    }

    /// <summary>
    /// Gets a nullable integer value of a data reader by a column name
    /// </summary>
    /// <param name="rdr">Data reader</param>
    /// <param name="columnName">Column name</param>
    /// <returns>A nullable integer value</returns>
    public static int? GetNullableInt(IDataReader rdr, string columnName)
    {
        int index = rdr.GetOrdinal(columnName);
        if (rdr.IsDBNull(index))
        {
            return null;
        }
        return (int)rdr[index];
    }

    /// <summary>
    /// Gets a string of a data reader by a column name
    /// </summary>
    /// <param name="rdr">Data reader</param>
    /// <param name="columnName">Column name</param>
    /// <returns>A string value</returns>
    public static string GetString(IDataReader rdr, string columnName)
    {
        int index = rdr.GetOrdinal(columnName);
        if (rdr.IsDBNull(index))
        {
            return string.Empty;
        }
        return (string)rdr[index];
    }

    /// <summary>
    /// This is to check wheather a Coloumn exists in datareader or not
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="ColoumnName"></param>
    /// <returns></returns>
    public static bool IsColoumnExists(IDataReader dataReader, string ColoumnName)
    {
        DataTable dt = dataReader.GetSchemaTable();
        bool isExists = false;
        string strExpr = "ColumnName='" + ColoumnName + "'";
        DataRow[] dr = dt.Select(strExpr);
        if (dr.Length > 0)
            isExists = true;
        dr = null;
        dt = null;
        return isExists;
    }
    #endregion
}
