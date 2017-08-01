using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShortcutCarousel.Model
{
	public class CarouselScriptItem : CarouselSimpleItemBase
	{
		#region Properties
		private string _Script;
		public string Script
		{
			get
			{
				return _Script;
			}
			set
			{
				if (this._Script != value)
				{
					this._Script = value;
					this.OnPropertyChanged(@"Script");
				}
			}
		}

		private string _ScriptUsualSource;
		public string ScriptUsualSource
		{
			get
			{
				return _ScriptUsualSource;
			}
			set
			{
				if (this._ScriptUsualSource != value)
				{
					this._ScriptUsualSource = value;
					this.OnPropertyChanged(@"ScriptUsualSource");
				}
			}
		}

		private DateTime _ScriptSourceLastLoad;
		public DateTime ScriptSourceLastLoad
		{
			get
			{
				return _ScriptSourceLastLoad;
			}
			set
			{
				if (this._ScriptSourceLastLoad != value)
				{
					this._ScriptSourceLastLoad = value;
					this.OnPropertyChanged(@"ScriptSourceLastLoad");
				}
			}
		}
		#endregion

		protected CarouselScriptItem() : base()
		{

		}

		public CarouselScriptItem(IColorConfiguration colorConfig) : base(colorConfig)
		{

		}

		public override void ClickAction()
		{
			Clipboard.SetText(this.Script);
		}

		protected override bool CanExecuteClickAction()
		{
			return true;
		}
	}
}
