﻿using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework;
using static Tests.Framework.UrlTester;

namespace Tests.XPack.Security.User.DeleteUser
{
	public class DeleteUserUrlTests : UrlTestsBase
	{
		[U] public override async Task Urls() => await DELETE("/_xpack/security/user/mpdreamz")
			.Fluent(c => c.DeleteUser("mpdreamz"))
			.Request(c => c.DeleteUser(new DeleteUserRequest("mpdreamz")))
			.FluentAsync(c => c.DeleteUserAsync("mpdreamz"))
			.RequestAsync(c => c.DeleteUserAsync(new DeleteUserRequest("mpdreamz")));
	}
}
