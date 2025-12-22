using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.Common;
using System.Data.OleDb;
using System.Collections;


namespace SGN.Datos
{
 
    public class DataTableHelper
    {

        public bool ColumnEqual(object A, object B)
        {
            if ((A == DBNull.Value) && (B == DBNull.Value))
            {
                return true;
            }
            if ((A == DBNull.Value) || (B == DBNull.Value))
            {
                return false;
            }
            return A.Equals(B);
        }

        public static int GetIndexForField(DataTable table, string fieldName)
        {
            foreach (DataColumn column in table.Columns)
            {
                if (column.ColumnName.ToLower() == fieldName.ToLower())
                {
                    return column.Ordinal;
                }
            }
            return -1;
        }

        public DataTable JoinTables(DataTable table1, DataTable table2, Dictionary<string, string> keyFields, List<string> fieldsTable1, List<string> fieldsTable2)
        {
            DataTable table5;
            bool flag = true;
            try
            {
                DataColumn column;
                DataTable table = new DataTable();
                foreach (string str in fieldsTable1)
                {
                    column = table1.Columns[str];
                    table.Columns.Add(new DataColumn(str, column.DataType));
                }
                foreach (string str in fieldsTable2)
                {
                    column = table2.Columns[str];
                    table.Columns.Add(new DataColumn(str, column.DataType));
                }
                DataTable table3 = table1;
                DataTable table4 = table2;
                foreach (DataRow row2 in table3.Rows)
                {
                    foreach (DataRow row3 in table4.Rows)
                    {
                        flag = true;
                        foreach (KeyValuePair<string, string> pair in keyFields)
                        {
                            if (!this.ColumnEqual(row2[pair.Key], row3[pair.Value]))
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            DataRow row = table.NewRow();
                            foreach (string str in fieldsTable1)
                            {
                                row[str] = row2[str];
                            }
                            foreach (string str in fieldsTable2)
                            {
                                row[str] = row3[str];
                            }
                            table.Rows.Add(row);
                        }
                    }
                }
                table5 = table;
            }
            catch (Exception exception)
            {
                throw new Exception("Ha ocurrido un error al unir las tablas.", exception);
            }
            return table5;
        }

        public DataTable SelectDistinct(DataTable SourceTable, string FieldName)
        {
            DataTable table = new DataTable();
            table.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);
            object a = null;
            foreach (DataRow row in SourceTable.Select("", FieldName))
            {
                if (!((a != null) && this.ColumnEqual(a, row[FieldName])))
                {
                    a = row[FieldName];
                    table.Rows.Add(new object[] { a });
                }
            }
            return table;
        }

        public DataTable SelectDistinct(string TableName, DataTable SourceTable, string FieldName)
        {
            DataTable table = new DataTable(TableName);
            table.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);
            object a = null;
            foreach (DataRow row in SourceTable.Select("", FieldName))
            {
                if (!((a != null) && this.ColumnEqual(a, row[FieldName])))
                {
                    a = row[FieldName];
                    table.Rows.Add(new object[] { a });
                }
            }
            return table;
        }

        public DataTable ToMatrix(DataTable source, string columnHeader, string columnRecords, string columnValues, int initialRecordValue, int finalRecordValue, string defaultValue)
        {
            DataTable table;
            try
            {
                table = new DataTable();
                DataTable table2 = new DataTableHelper().SelectDistinct(source, columnHeader);
                table.Columns.Add(columnRecords);
                foreach (DataRow row2 in table2.Rows)
                {
                    table.Columns.Add(row2[columnHeader].ToString());
                }
                for (int i = initialRecordValue; i <= finalRecordValue; i++)
                {
                    DataRow row = table.NewRow();
                    row[columnRecords] = i;
                    foreach (DataRow row2 in table2.Rows)
                    {
                        string str;
                        DataView view = new DataView(source)
                        {
                            RowFilter = string.Concat(new object[] { columnRecords, " = '", i, "' AND ", columnHeader, " = '", row2[columnHeader].ToString(), "'" })
                        };
                        if (view.Count == 0)
                        {
                            str = defaultValue;
                        }
                        else
                        {
                            str = view[0][columnValues].ToString();
                        }
                        row[row2[columnHeader].ToString()] = str;
                    }
                    table.Rows.Add(row);
                }
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al generar la matriz de valores.");
            }
            return table;
        }
    }

    public abstract class GenericProvider
    {

        protected string connectionString;


        public GenericProvider(string dbConnectionString)
        {
            this.connectionString = dbConnectionString;
        }

        protected abstract void CloseConnection();
        protected string ConvertStatements(ArrayList sqlStoreProcedures)
        {
            return this.ConvertStatements((string[])sqlStoreProcedures.ToArray(typeof(string)));
        }

        protected string ConvertStatements(string[] sqlStoreProcedures)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string str in sqlStoreProcedures)
            {
                this.ValidateStatement(str);
                builder.Append(str);
                builder.Append(";");
            }
            return builder.ToString();
        }

        protected string ConvertStatements(List<string> sqlStoreProcedures)
        {
            return this.ConvertStatements(sqlStoreProcedures.ToArray());
        }

        public abstract int ExecuteNonQuery(DbCommand command);
        public abstract int ExecuteNonQuery(string sqlStoreProcedure);
        public abstract int ExecuteNonQuery(string sqlStoreProcedure, List<SqlParamTranfer> _SqlParamTransfer);



        public abstract object ExecuteScalar(DbCommand command);
        public abstract object ExecuteScalar(string sqlStoreProcedure);
        public abstract object ExecuteScalar(string sqlStoreProcedure, List<SqlParamTranfer> _SqlParamTransfer);



        public abstract DbDataReader ExecuteSelect(string sqlStoreProcedure);
        public virtual int ExecuteTransaction(ArrayList odbcStatements)
        {
            string sqlStoreProcedures = this.ConvertStatements(odbcStatements);
            return this.ExecuteTransaction(sqlStoreProcedures);
        }

        public virtual int ExecuteTransaction(List<string> odbcStatements)
        {
            string sqlStoreProcedures = this.ConvertStatements(odbcStatements);
            return this.ExecuteTransaction(sqlStoreProcedures);
        }

        public abstract int ExecuteTransaction(string sqlStoreProcedures);
        public virtual int ExecuteTransaction(string[] odbcStatements)
        {
            string sqlStoreProcedures = this.ConvertStatements(odbcStatements);
            return this.ExecuteTransaction(sqlStoreProcedures);
        }

        public abstract DbCommand GetCommand();
        public abstract DbParameter GetParameter();
        public virtual DataSet LoadDataSet(ArrayList odbcStatements)
        {
            return this.LoadDataSet((string[])odbcStatements.ToArray(typeof(string)));
        }

        public virtual DataSet LoadDataSet(List<string> odbcStatements)
        {
            return this.LoadDataSet(odbcStatements.ToArray());
        }

        public abstract DataSet LoadDataSet(string[] sqlStoreProcedures);
        public abstract DataSet LoadDataSet(DbCommand command);
        public abstract DataSet LoadDataSet(string sqlStoreProcedure);
        public abstract DataSet LoadDataSet(string sqlStoreProcedure, List<SqlParamTranfer> _SqlParamTransfer);
        protected abstract void OpenConnection();
        public virtual void TestConnection()
        {
            try
            {
                this.OpenConnection();
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public abstract void UpdateDataSet(DataSet data, DbCommand insert);
        protected void ValidateStatement(string sqlStoreProcedure)
        {
            if ((sqlStoreProcedure == null) || (string.Empty == sqlStoreProcedure))
            {
                throw new Exception("La cadena de la sentencia SQL est\x00e1 vac\x00eda o es nula.");
            }
        }

        // Properties
        public string ConnectionString
        {
            get
            {
                return this.connectionString;
            }
        }
    }
   

    public class SqlProvider : GenericProvider
    {


        private SqlConnection connection;


        public SqlProvider(string dbConnectionString)
            : base(dbConnectionString)
        {
        }

        protected override void CloseConnection()
        {
            if ((this.connection != null) && (this.connection.State == ConnectionState.Open))
            {
                this.connection.Close();
            }
        }

        public override int ExecuteNonQuery(DbCommand command)
        {
            int num;
            try
            {
                this.OpenConnection();
                SqlCommand command2 = (SqlCommand)command;
                command2.Connection = this.connection;
                num = command2.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return num;
        }

        public override int ExecuteNonQuery(string sqlStoreProcedure, List<SqlParamTranfer> _SqlParamTransfer)
        {
            int num;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();


                SqlCommand Command = new SqlCommand(sqlStoreProcedure, this.connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandTimeout = 32000;

                foreach (var sqlParameterItem in _SqlParamTransfer)
                {
                    sqlParameterItem.SqlParam.Value = sqlParameterItem.SqlValue;
                    Command.Parameters.AddWithValue(sqlParameterItem.SqlParam.ParameterName, sqlParameterItem.SqlParam.Value);
                }

                num = Command.ExecuteNonQuery();

            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return num;
        }

        public override int ExecuteNonQuery(string sqlStoreProcedure)
        {
            int num;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                num = new SqlCommand { Connection = this.connection, CommandType = CommandType.Text, CommandText = sqlStoreProcedure }.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return num;
        }

        public override object ExecuteScalar(DbCommand command)
        {
            object obj2;
            try
            {
                this.OpenConnection();
                SqlCommand command2 = (SqlCommand)command;
                command2.Connection = this.connection;
                obj2 = command.ExecuteScalar();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return obj2;
        }

        public override object ExecuteScalar(string sqlStoreProcedure, List<SqlParamTranfer> _SqlParamTransfer)
        {
            object obj2;
            try
            {

                SqlCommand Command = new SqlCommand(sqlStoreProcedure, this.connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandTimeout = 32000;

                foreach (var sqlParameterItem in _SqlParamTransfer)
                {
                    sqlParameterItem.SqlParam.Value = sqlParameterItem.SqlValue;
                    Command.Parameters.AddWithValue(sqlParameterItem.SqlParam.ParameterName, sqlParameterItem.SqlParam.Value);
                }


                obj2 = Command.ExecuteScalar();

            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return obj2;
        }

        public override object ExecuteScalar(string sqlStoreProcedure)
        {
            object obj2;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                obj2 = new SqlCommand { Connection = this.connection, CommandType = CommandType.Text, CommandText = sqlStoreProcedure }.ExecuteScalar();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return obj2;
        }

        public override DbDataReader ExecuteSelect(string sqlStoreProcedure)
        {
            DbDataReader reader;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                reader = new SqlCommand { Connection = this.connection, CommandType = CommandType.Text, CommandText = sqlStoreProcedure }.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            return reader;
        }

        public override int ExecuteTransaction(string statements)
        {
            int num = 0;
            try
            {
                this.OpenConnection();
                SqlTransaction transaction = this.connection.BeginTransaction();
                SqlCommand command = new SqlCommand(statements, this.connection, transaction);
                try
                {
                    num = command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
                return num;
            }
            catch (Exception exception2)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception2);
            }
            finally
            {
                this.CloseConnection();
            }
            //return num;
        }

        public override DbCommand GetCommand()
        {
            return new SqlCommand();
        }

        public override DbParameter GetParameter()
        {
            return new SqlParameter();
        }

        public override DataSet LoadDataSet(string[] sqlStoreProcedures)
        {
            DataSet set;
            try
            {
                if ((sqlStoreProcedures == null) || (sqlStoreProcedures.Length == 0))
                {
                    throw new Exception("No hay sentencias SQL por ejecutar.");
                }
                foreach (string str in sqlStoreProcedures)
                {
                    base.ValidateStatement(str);
                }
                this.OpenConnection();
                set = new DataSet();
                foreach (string str in sqlStoreProcedures)
                {
                    SqlCommand selectCommand = new SqlCommand(str, this.connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(set);
                    //set.Tables.Add(dataTable);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return set;
        }

        public override DataSet LoadDataSet(DbCommand command)
        {
            DataSet set;
            try
            {
                this.OpenConnection();
                set = new DataSet();
                SqlCommand selectCommand = (SqlCommand)command;
                selectCommand.Connection = this.connection;
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(set);
                //set.Tables.Add(dataTable);
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return set;
        }

        public override DataSet LoadDataSet(string sqlStoreProcedure)
        {
            DataSet set;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                set = new DataSet();
                SqlCommand selectCommand = new SqlCommand(sqlStoreProcedure, this.connection);
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(set);
                //set.Tables.Add(dataTable);
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return set;
        }

        public override DataSet LoadDataSet(string sqlStoreProcedure, List<SqlParamTranfer> _SqlParamTransfer)
        {
            DataSet ds = new DataSet();
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                DataTable dataTable = new DataTable();

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(sqlStoreProcedure, this.connection);
                SqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlAdapter.SelectCommand.CommandTimeout = 32000;
                foreach (var sqlParameterItem in _SqlParamTransfer)
                {
                    sqlParameterItem.SqlParam.Value = sqlParameterItem.SqlValue;
                    SqlAdapter.SelectCommand.Parameters.AddWithValue(sqlParameterItem.SqlParam.ParameterName, sqlParameterItem.SqlParam.Value);
                }


                SqlAdapter.Fill(ds);
                //ds.Tables.Add(dataTable);

            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return ds;
        }

        protected override void OpenConnection()
        {
            try
            {
                this.connection = new SqlConnection(base.connectionString);
                this.connection.Open();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al abrir la conexi\x00f3n a la base de datos.", exception);
            }
        }

        public override void UpdateDataSet(DataSet data, DbCommand insert)
        {
            try
            {
                this.OpenConnection();
                new SqlDataAdapter { InsertCommand = (SqlCommand)insert }.Update(data);
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }

    public class OracleProvider : GenericProvider
    {

        // Fields
        private SqlConnection connection;

        // Methods
        public OracleProvider(string dbConnectionString)
            : base(dbConnectionString)
        {
        }

        protected override void CloseConnection()
        {
            if ((this.connection != null) && (this.connection.State == ConnectionState.Open))
            {
                this.connection.Close();
            }
        }

        public override int ExecuteNonQuery(DbCommand command)
        {
            int num;
            try
            {
                this.OpenConnection();
                SqlCommand command2 = (SqlCommand)command;
                command2.Connection = this.connection;
                num = command2.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return num;
        }

        public override int ExecuteNonQuery(string sqlStoreProcedure, List<SqlParamTranfer> _SqlParamTransfer)
        {
            int num;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();


                SqlCommand Command = new SqlCommand(sqlStoreProcedure, this.connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandTimeout = 32000;

                foreach (var sqlParameterItem in _SqlParamTransfer)
                {
                    sqlParameterItem.SqlParam.Value = sqlParameterItem.SqlValue;
                    Command.Parameters.AddWithValue(sqlParameterItem.SqlParam.ParameterName, sqlParameterItem.SqlParam.Value);
                }

                num = Command.ExecuteNonQuery();

            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return num;
        }

        public override int ExecuteNonQuery(string sqlStoreProcedure)
        {
            int num;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                num = new SqlCommand { Connection = this.connection, CommandType = CommandType.Text, CommandText = sqlStoreProcedure }.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return num;
        }

        public override object ExecuteScalar(DbCommand command)
        {
            object obj2;
            try
            {
                this.OpenConnection();
                SqlCommand command2 = (SqlCommand)command;
                command2.Connection = this.connection;
                obj2 = command.ExecuteScalar();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return obj2;
        }

        public override object ExecuteScalar(string sqlStoreProcedure, List<SqlParamTranfer> _SqlParamTransfer)
        {
            object obj2;
            try
            {

                SqlCommand Command = new SqlCommand(sqlStoreProcedure, this.connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandTimeout = 32000;

                foreach (var sqlParameterItem in _SqlParamTransfer)
                {
                    sqlParameterItem.SqlParam.Value = sqlParameterItem.SqlValue;
                    Command.Parameters.AddWithValue(sqlParameterItem.SqlParam.ParameterName, sqlParameterItem.SqlParam.Value);
                }


                obj2 = Command.ExecuteScalar();

            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return obj2;
        }

        public override object ExecuteScalar(string sqlStoreProcedure)
        {
            object obj2;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                obj2 = new SqlCommand { Connection = this.connection, CommandType = CommandType.Text, CommandText = sqlStoreProcedure }.ExecuteScalar();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return obj2;
        }

        public override DbDataReader ExecuteSelect(string sqlStoreProcedure)
        {
            DbDataReader reader;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                reader = new SqlCommand { Connection = this.connection, CommandType = CommandType.Text, CommandText = sqlStoreProcedure }.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            return reader;
        }

        public override int ExecuteTransaction(string statements)
        {
            int num = 0;
            try
            {
                this.OpenConnection();
                SqlTransaction transaction = this.connection.BeginTransaction();
                SqlCommand command = new SqlCommand(statements, this.connection, transaction);
                try
                {
                    num = command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
                return num;
            }
            catch (Exception exception2)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception2);
            }
            finally
            {
                this.CloseConnection();
            }
            //return num;
        }

        public override DbCommand GetCommand()
        {
            return new SqlCommand();
        }

        public override DbParameter GetParameter()
        {
            return new SqlParameter();
        }

        public override DataSet LoadDataSet(string[] sqlStoreProcedures)
        {
            DataSet set;
            try
            {
                if ((sqlStoreProcedures == null) || (sqlStoreProcedures.Length == 0))
                {
                    throw new Exception("No hay sentencias SQL por ejecutar.");
                }
                foreach (string str in sqlStoreProcedures)
                {
                    base.ValidateStatement(str);
                }
                this.OpenConnection();
                set = new DataSet();
                foreach (string str in sqlStoreProcedures)
                {
                    SqlCommand selectCommand = new SqlCommand(str, this.connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(set);
                    //set.Tables.Add(dataTable);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return set;
        }

        public override DataSet LoadDataSet(DbCommand command)
        {
            DataSet set;
            try
            {
                this.OpenConnection();
                set = new DataSet();
                SqlCommand selectCommand = (SqlCommand)command;
                selectCommand.Connection = this.connection;
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(set);
                //set.Tables.Add(dataTable);
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return set;
        }

        public override DataSet LoadDataSet(string sqlStoreProcedure)
        {
            DataSet set;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                set = new DataSet();
                SqlCommand selectCommand = new SqlCommand(sqlStoreProcedure, this.connection);
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(set);
                //set.Tables.Add(dataTable);
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return set;
        }

        public override DataSet LoadDataSet(string sqlStoreProcedure, List<SqlParamTranfer> _SqlParamTransfer)
        {
            DataSet ds = new DataSet();
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                DataTable dataTable = new DataTable();

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(sqlStoreProcedure, this.connection);
                SqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlAdapter.SelectCommand.CommandTimeout = 32000;
                foreach (var sqlParameterItem in _SqlParamTransfer)
                {
                    sqlParameterItem.SqlParam.Value = sqlParameterItem.SqlValue;
                    SqlAdapter.SelectCommand.Parameters.AddWithValue(sqlParameterItem.SqlParam.ParameterName, sqlParameterItem.SqlParam.Value);
                }


                SqlAdapter.Fill(ds);
                //ds.Tables.Add(dataTable);

            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return ds;
        }

        protected override void OpenConnection()
        {
            try
            {
                this.connection = new SqlConnection(base.connectionString);
                this.connection.Open();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al abrir la conexi\x00f3n a la base de datos.", exception);
            }
        }

        public override void UpdateDataSet(DataSet data, DbCommand insert)
        {
            try
            {
                this.OpenConnection();
                new SqlDataAdapter { InsertCommand = (SqlCommand)insert }.Update(data);
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }

    public class ODBCProvider : GenericProvider
    {

        // Fields
        private SqlConnection connection;

        // Methods
        public ODBCProvider(string dbConnectionString)
            : base(dbConnectionString)
        {
        }

        protected override void CloseConnection()
        {
            if ((this.connection != null) && (this.connection.State == ConnectionState.Open))
            {
                this.connection.Close();
            }
        }

        public override int ExecuteNonQuery(DbCommand command)
        {
            int num;
            try
            {
                this.OpenConnection();
                SqlCommand command2 = (SqlCommand)command;
                command2.Connection = this.connection;
                num = command2.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return num;
        }

        public override int ExecuteNonQuery(string sqlStoreProcedure, List<SqlParamTranfer> _SqlParamTransfer)
        {
            int num;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();


                SqlCommand Command = new SqlCommand(sqlStoreProcedure, this.connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandTimeout = 32000;

                foreach (var sqlParameterItem in _SqlParamTransfer)
                {
                    sqlParameterItem.SqlParam.Value = sqlParameterItem.SqlValue;
                    Command.Parameters.AddWithValue(sqlParameterItem.SqlParam.ParameterName, sqlParameterItem.SqlParam.Value);
                }

                num = Command.ExecuteNonQuery();

            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return num;
        }

        public override int ExecuteNonQuery(string sqlStoreProcedure)
        {
            int num;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                num = new SqlCommand { Connection = this.connection, CommandType = CommandType.Text, CommandText = sqlStoreProcedure }.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return num;
        }

        public override object ExecuteScalar(DbCommand command)
        {
            object obj2;
            try
            {
                this.OpenConnection();
                SqlCommand command2 = (SqlCommand)command;
                command2.Connection = this.connection;
                obj2 = command.ExecuteScalar();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return obj2;
        }

        public override object ExecuteScalar(string sqlStoreProcedure, List<SqlParamTranfer> _SqlParamTransfer)
        {
            object obj2;
            try
            {

                SqlCommand Command = new SqlCommand(sqlStoreProcedure, this.connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandTimeout = 32000;

                foreach (var sqlParameterItem in _SqlParamTransfer)
                {
                    sqlParameterItem.SqlParam.Value = sqlParameterItem.SqlValue;
                    Command.Parameters.AddWithValue(sqlParameterItem.SqlParam.ParameterName, sqlParameterItem.SqlParam.Value);
                }


                obj2 = Command.ExecuteScalar();

            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return obj2;
        }

        public override object ExecuteScalar(string sqlStoreProcedure)
        {
            object obj2;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                obj2 = new SqlCommand { Connection = this.connection, CommandType = CommandType.Text, CommandText = sqlStoreProcedure }.ExecuteScalar();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return obj2;
        }

        public override DbDataReader ExecuteSelect(string sqlStoreProcedure)
        {
            DbDataReader reader;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                reader = new SqlCommand { Connection = this.connection, CommandType = CommandType.Text, CommandText = sqlStoreProcedure }.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            return reader;
        }

        public override int ExecuteTransaction(string statements)
        {
            int num = 0;
            try
            {
                this.OpenConnection();
                SqlTransaction transaction = this.connection.BeginTransaction();
                SqlCommand command = new SqlCommand(statements, this.connection, transaction);
                try
                {
                    num = command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
                return num;
            }
            catch (Exception exception2)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception2);
            }
            finally
            {
                this.CloseConnection();
            }
            //return num;
        }

        public override DbCommand GetCommand()
        {
            return new SqlCommand();
        }

        public override DbParameter GetParameter()
        {
            return new SqlParameter();
        }

        public override DataSet LoadDataSet(string[] sqlStoreProcedures)
        {
            DataSet set;
            try
            {
                if ((sqlStoreProcedures == null) || (sqlStoreProcedures.Length == 0))
                {
                    throw new Exception("No hay sentencias SQL por ejecutar.");
                }
                foreach (string str in sqlStoreProcedures)
                {
                    base.ValidateStatement(str);
                }
                this.OpenConnection();
                set = new DataSet();
                foreach (string str in sqlStoreProcedures)
                {
                    SqlCommand selectCommand = new SqlCommand(str, this.connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(set);
                    //set.Tables.Add(dataTable);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return set;
        }

        public override DataSet LoadDataSet(DbCommand command)
        {
            DataSet set;
            try
            {
                this.OpenConnection();
                set = new DataSet();
                SqlCommand selectCommand = (SqlCommand)command;
                selectCommand.Connection = this.connection;
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(set);
                //set.Tables.Add(dataTable);
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return set;
        }

        public override DataSet LoadDataSet(string sqlStoreProcedure)
        {
            DataSet set;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                set = new DataSet();
                SqlCommand selectCommand = new SqlCommand(sqlStoreProcedure, this.connection);
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(set);
                //set.Tables.Add(dataTable);
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return set;
        }

        public override DataSet LoadDataSet(string sqlStoreProcedure, List<SqlParamTranfer> _SqlParamTransfer)
        {
            DataSet ds = new DataSet();
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                DataTable dataTable = new DataTable();

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(sqlStoreProcedure, this.connection);
                SqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlAdapter.SelectCommand.CommandTimeout = 32000;
                foreach (var sqlParameterItem in _SqlParamTransfer)
                {
                    sqlParameterItem.SqlParam.Value = sqlParameterItem.SqlValue;
                    SqlAdapter.SelectCommand.Parameters.AddWithValue(sqlParameterItem.SqlParam.ParameterName, sqlParameterItem.SqlParam.Value);
                }


                SqlAdapter.Fill(ds);
                //ds.Tables.Add(dataTable);

            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return ds;
        }

        protected override void OpenConnection()
        {
            try
            {
                this.connection = new SqlConnection(base.connectionString);
                this.connection.Open();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al abrir la conexi\x00f3n a la base de datos.", exception);
            }
        }

        public override void UpdateDataSet(DataSet data, DbCommand insert)
        {
            try
            {
                this.OpenConnection();
                new SqlDataAdapter { InsertCommand = (SqlCommand)insert }.Update(data);
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }

    public class MySQLProvider : GenericProvider
    {


        private SqlConnection connection;


        public MySQLProvider(string dbConnectionString)
            : base(dbConnectionString)
        {
        }

        protected override void CloseConnection()
        {
            if ((this.connection != null) && (this.connection.State == ConnectionState.Open))
            {
                this.connection.Close();
            }
        }

        public override int ExecuteNonQuery(DbCommand command)
        {
            int num;
            try
            {
                this.OpenConnection();
                SqlCommand command2 = (SqlCommand)command;
                command2.Connection = this.connection;
                num = command2.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return num;
        }

        public override int ExecuteNonQuery(string sqlStoreProcedure, List<SqlParamTranfer> _SqlParamTransfer)
        {
            int num;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();


                SqlCommand Command = new SqlCommand(sqlStoreProcedure, this.connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandTimeout = 32000;

                foreach (var sqlParameterItem in _SqlParamTransfer)
                {
                    sqlParameterItem.SqlParam.Value = sqlParameterItem.SqlValue;
                    Command.Parameters.AddWithValue(sqlParameterItem.SqlParam.ParameterName, sqlParameterItem.SqlParam.Value);
                }

                num = Command.ExecuteNonQuery();

            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return num;
        }

        public override int ExecuteNonQuery(string sqlStoreProcedure)
        {
            int num;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                num = new SqlCommand { Connection = this.connection, CommandType = CommandType.Text, CommandText = sqlStoreProcedure }.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return num;
        }

        public override object ExecuteScalar(DbCommand command)
        {
            object obj2;
            try
            {
                this.OpenConnection();
                SqlCommand command2 = (SqlCommand)command;
                command2.Connection = this.connection;
                obj2 = command.ExecuteScalar();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return obj2;
        }

        public override object ExecuteScalar(string sqlStoreProcedure, List<SqlParamTranfer> _SqlParamTransfer)
        {
            object obj2;
            try
            {

                SqlCommand Command = new SqlCommand(sqlStoreProcedure, this.connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandTimeout = 32000;

                foreach (var sqlParameterItem in _SqlParamTransfer)
                {
                    sqlParameterItem.SqlParam.Value = sqlParameterItem.SqlValue;
                    Command.Parameters.AddWithValue(sqlParameterItem.SqlParam.ParameterName, sqlParameterItem.SqlParam.Value);
                }


                obj2 = Command.ExecuteScalar();

            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return obj2;
        }

        public override object ExecuteScalar(string sqlStoreProcedure)
        {
            object obj2;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                obj2 = new SqlCommand { Connection = this.connection, CommandType = CommandType.Text, CommandText = sqlStoreProcedure }.ExecuteScalar();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return obj2;
        }

        public override DbDataReader ExecuteSelect(string sqlStoreProcedure)
        {
            DbDataReader reader;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                reader = new SqlCommand { Connection = this.connection, CommandType = CommandType.Text, CommandText = sqlStoreProcedure }.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar la sentencia SQL.", exception);
            }
            return reader;
        }

        public override int ExecuteTransaction(string statements)
        {
            int num = 0;
            try
            {
                this.OpenConnection();
                SqlTransaction transaction = this.connection.BeginTransaction();
                SqlCommand command = new SqlCommand(statements, this.connection, transaction);
                try
                {
                    num = command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
                return num;
            }
            catch (Exception exception2)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception2);
            }
            finally
            {
                this.CloseConnection();
            }
            //return num;
        }

        public override DbCommand GetCommand()
        {
            return new SqlCommand();
        }

        public override DbParameter GetParameter()
        {
            return new SqlParameter();
        }

        public override DataSet LoadDataSet(string[] sqlStoreProcedures)
        {
            DataSet set;
            try
            {
                if ((sqlStoreProcedures == null) || (sqlStoreProcedures.Length == 0))
                {
                    throw new Exception("No hay sentencias SQL por ejecutar.");
                }
                foreach (string str in sqlStoreProcedures)
                {
                    base.ValidateStatement(str);
                }
                this.OpenConnection();
                set = new DataSet();
                foreach (string str in sqlStoreProcedures)
                {
                    SqlCommand selectCommand = new SqlCommand(str, this.connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(set);
                    //set.Tables.Add(dataTable);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return set;
        }

        public override DataSet LoadDataSet(DbCommand command)
        {
            DataSet set;
            try
            {
                this.OpenConnection();
                set = new DataSet();
                SqlCommand selectCommand = (SqlCommand)command;
                selectCommand.Connection = this.connection;
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(set);
                //set.Tables.Add(dataTable);
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return set;
        }

        public override DataSet LoadDataSet(string sqlStoreProcedure)
        {
            DataSet set;
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                set = new DataSet();
                SqlCommand selectCommand = new SqlCommand(sqlStoreProcedure, this.connection);
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(set);
                //set.Tables.Add(dataTable);
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return set;
        }

        public override DataSet LoadDataSet(string sqlStoreProcedure, List<SqlParamTranfer> _SqlParamTransfer)
        {
            DataSet ds = new DataSet();
            try
            {
                base.ValidateStatement(sqlStoreProcedure);
                this.OpenConnection();
                DataTable dataTable = new DataTable();

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(sqlStoreProcedure, this.connection);
                SqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlAdapter.SelectCommand.CommandTimeout = 32000;
                foreach (var sqlParameterItem in _SqlParamTransfer)
                {
                    sqlParameterItem.SqlParam.Value = sqlParameterItem.SqlValue;
                    SqlAdapter.SelectCommand.Parameters.AddWithValue(sqlParameterItem.SqlParam.ParameterName, sqlParameterItem.SqlParam.Value);
                }


                SqlAdapter.Fill(ds);
                //ds.Tables.Add(dataTable);

            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
            return ds;
        }

        protected override void OpenConnection()
        {
            try
            {
                this.connection = new SqlConnection(base.connectionString);
                this.connection.Open();
            }
            catch (Exception exception)
            {
                throw new Exception("Error al abrir la conexi\x00f3n a la base de datos.", exception);
            }
        }

        public override void UpdateDataSet(DataSet data, DbCommand insert)
        {
            try
            {
                this.OpenConnection();
                new SqlDataAdapter { InsertCommand = (SqlCommand)insert }.Update(data);
            }
            catch (Exception exception)
            {
                throw new Exception("Error al ejecutar las sentencias SQL.", exception);
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }

    public class SqlParamTranfer
    {

        public SqlParameter SqlParam { get; set; }
        public Object SqlValue { get; set; }



        public SqlParamTranfer(SqlParameter _SqlParameter, Object _SqlValue)
        {
            SqlParam = _SqlParameter;
            SqlValue = _SqlValue;

        }

        public SqlParamTranfer()
        {
            SqlParam = null;
            SqlValue = null;

        }

        public void SqlParamTranferFill(SqlParameter _SqlParameter, Object _SqlValue)
        {
            SqlParam = _SqlParameter;
            SqlValue = _SqlValue;

        }

    }

}
