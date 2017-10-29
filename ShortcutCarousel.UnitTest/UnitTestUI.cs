using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortcutCarousel.UI;
using Microsoft.Practices.Unity;
using ShortcutCarousel.Model;
using System.Threading.Tasks;
using System.Linq;

namespace ShortcutCarousel.UnitTest
{
	[TestClass]
	public class UnitTestUI
	{
		private void Setup()
		{
			UnityContainerHelper.Container = new UnityContainer();
			UnityContainerHelper.Container.RegisterType(
				typeof(ShortcutCarousel.UI.ShortcutCarouselService.IShortcutCarouselService),
				typeof(ShortcutCarouselService),
				new InjectionConstructor());
		}

		[TestMethod]
		public void TestGeneralUIInteraction()
		{
			this.Setup();

			MainWindowVM mainWindowVM = new MainWindowVM(new ConfigDefaultOSUser());
			Assert.IsTrue(mainWindowVM.CarouselVM.StayOnTop == false);
			Assert.IsTrue(mainWindowVM.CarouselVM.AvailableOSUsers.Count == 3);
			Assert.IsTrue(mainWindowVM.CarouselVM.CarouselUserVM.User.OSUser == "usera");
			Assert.IsTrue(mainWindowVM.CarouselVM.AvailableOSUsers.FirstOrDefault(os => os.OSUserName == "usera") != null);
			Assert.IsTrue(mainWindowVM.CarouselVM.AvailableOSUsers.FirstOrDefault(os => os.OSUserName == "usera").IsCurrentOSUser);

			// select a different os user
			Assert.IsTrue(mainWindowVM.CarouselVM.SwitchUserCommand.CanExecute(null));
			mainWindowVM.CarouselVM.SwitchUserCommand.Execute("userb");
			Assert.IsTrue(mainWindowVM.CarouselVM.AvailableOSUsers.FirstOrDefault(os => os.OSUserName == "userb").IsCurrentOSUser);
			Assert.IsTrue(mainWindowVM.CarouselVM.CarouselUserVM.User.OSUser == "userb");
		}
	}

	internal class ShortcutCarouselService : ShortcutCarousel.UI.ShortcutCarouselService.IShortcutCarouselService
	{
		string[] ShortcutCarousel.UI.ShortcutCarouselService.IShortcutCarouselService.GetOSUserList()
		{
			return new string[] { "usera", "userb", "userc" };
		}

		Task<string[]> ShortcutCarousel.UI.ShortcutCarouselService.IShortcutCarouselService.GetOSUserListAsync()
		{
			return null;
		}

		CarouselUser ShortcutCarousel.UI.ShortcutCarouselService.IShortcutCarouselService.GetUser(string osuser)
		{
			if (osuser == "usera")
			{
				return new CarouselUser()
				{
					DatabaseCollection = new CarouselDatabaseCollection(),
					ScriptCollection = new CarouselScriptCollection(),
					LogCollection = new CarouselLogCollection(),
					FolderCollection = new CarouselFolderCollection(),
					OSUser = "usera"
				};
			}
			else if (osuser == "userb")
			{
				return new CarouselUser()
				{
					DatabaseCollection = new CarouselDatabaseCollection(),
					ScriptCollection = new CarouselScriptCollection(),
					LogCollection = new CarouselLogCollection(),
					FolderCollection = new CarouselFolderCollection(),
					OSUser = "userb"
				};
			}
			else
			{
				return null;
			}
		}

		Task<CarouselUser> ShortcutCarousel.UI.ShortcutCarouselService.IShortcutCarouselService.GetUserAsync(string osuser)
		{
			return null;
		}
	}

	internal class ConfigDefaultOSUser : IConfigDefaultOSUser
	{
		string IConfigDefaultOSUser.DefaultOSUSer
		{
			get
			{
				return "usera";
			}
		}
	}
}
