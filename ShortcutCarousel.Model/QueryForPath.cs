using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ShortcutCarousel.Model
{
	public class QueryForPath : NotifyPropertyChangedBase
	{
		#region Private fields
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		private IDbConnectionConfig _DbConnectionConfig;
		#endregion

		#region Properties
		private string _SelectFromDual;
		public string SelectFromDual
		{
			get
			{
				return _SelectFromDual;
			}
			set
			{
				if (this._SelectFromDual != value)
				{
					this._SelectFromDual = value;
					this.OnPropertyChanged(@"SelectFromDual");
				}
			}
		}
		#endregion

		protected QueryForPath()
		{

		}

		public QueryForPath(IDbConnectionConfig dbConnectionConfig) : this()
		{
			this._DbConnectionConfig = dbConnectionConfig;
		}

		public string ConnectAndRunQuery()
		{
			string queryResult = null;
			if (queryResult == null)
			{
				queryResult = this.RunQueryWithConnectionString(this._DbConnectionConfig.ConnectionStringPrimary);
			}
			if (queryResult == null)
			{
				queryResult = this.RunQueryWithConnectionString(this._DbConnectionConfig.ConnectionStringSecondary);
			}
			if (queryResult == null)
			{
				queryResult = this.RunQueryWithConnectionString(this._DbConnectionConfig.ConnectionStringTertiary);
			}
			if (queryResult == null)
			{
				queryResult = string.Empty;
				log.Error(@"ConnectAndRunQuery() has not been able to connect to any database.");
			}
			return queryResult;
		}

		private string RunQueryWithConnectionString(string connectionString)
		{
			try
			{
				string stringColumn = null;
				using (OracleConnection oracleConnection = new OracleConnection(connectionString))
				{
					oracleConnection.Open();

					if (oracleConnection.State == ConnectionState.Open)
					{
						stringColumn = this.RunQuery(oracleConnection);
					}
					else
					{
						stringColumn = null;
					}
				}
				return stringColumn;
			}
			catch (Exception ex)
			{
				log.ErrorFormat(@"RunQueryWithConnectionString() has thrown an exception: {0}", ex);
				return null;
			}
		}

		private string RunQuery(OracleConnection oracleConnection)
		{
			string stringColumn = string.Empty;
			using (OracleCommand cmd = new OracleCommand())
			{
				cmd.Connection = oracleConnection;
				cmd.CommandText = string.Format(@"select {0} string_column from dual", this.SelectFromDual);
				cmd.CommandType = CommandType.Text;

				OracleDataReader dr = cmd.ExecuteReader();
				dr.Read();
				stringColumn = dr.GetString(0);
				dr.Close();
			}
			return stringColumn;
		}
	}
}
