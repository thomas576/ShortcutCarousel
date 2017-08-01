using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Model
{
	public class CarouselLogItem : CarouselSimpleItemBase
	{
		#region Properties
		private bool _UseQueryForPath;
		public bool UseQueryForPath
		{
			get
			{
				return _UseQueryForPath;
			}
			set
			{
				if (this._UseQueryForPath != value)
				{
					this._UseQueryForPath = value;
					this.OnPropertyChanged(@"UseQueryForPath");
				}
			}
		}

		private string _LogPath;
		public string LogPath
		{
			get
			{
				return _LogPath;
			}
			set
			{
				if (this._LogPath != value)
				{
					this._LogPath = value;
					this.OnPropertyChanged(@"LogPath");
				}
			}
		}

		private QueryForPath _QueryForPath;
		public QueryForPath QueryForPath
		{
			get
			{
				return _QueryForPath;
			}
			set
			{
				if (this._QueryForPath != value)
				{
					this._QueryForPath = value;
					this.OnPropertyChanged(@"QueryForPath");
				}
			}
		}
		#endregion

		protected CarouselLogItem() : base()
		{

		}

		protected CarouselLogItem(IColorConfiguration colorConfig) : base(colorConfig)
		{
			this._UseQueryForPath = false;
		}

		public CarouselLogItem(IColorConfiguration colorConfig, IDbConnectionConfig dbConnectionConfig) : this(colorConfig)
		{
			this._QueryForPath = new QueryForPath(dbConnectionConfig);
		}

		public override void ClickAction()
		{
			if (this.UseQueryForPath)
			{
				string queryResult = this.QueryForPath.ConnectAndRunQuery();
				if (!string.IsNullOrWhiteSpace(queryResult))
				{
					System.Diagnostics.Process.Start(queryResult);
				}
			}
			else
			{
				System.Diagnostics.Process.Start(this.LogPath);
			}	
		}

		protected override bool CanExecuteClickAction()
		{
			return true;
		}
	}
}
